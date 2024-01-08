using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bilet.FutbolForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bilet
{
    public partial class FutbolForm : Form
    {
        NpgsqlConnection baglanti;
        private string eposta;
        private int kullaniciId; // Yeni eklenen kullaniciId özelliği

        public string Eposta
        {
            get { return eposta; }
            private set { eposta = value; }
        }

        public class BiletBilgisi
        {
            public int KullaniciId { get; set; }
            public string Eposta { get; set; }
            public int TribunId { get; set; }
            public string TribunAd { get; set; }
            public int BiletSayisi { get; set; }
        }

        public int KullaniciId // Yeni eklenen kullaniciId özelliği
        {
            get { return kullaniciId; }
            private set { kullaniciId = value; }
        }
        private GirisForm girisForm;


        public FutbolForm(GirisForm girisForm, int kullaniciId)
        {
            InitializeComponent();
            this.girisForm = girisForm;
            this.KullaniciId = kullaniciId;

            baglanti = new NpgsqlConnection("Host=localhost;Port=5432;Database=passo;Username=postgres;Password=admin");


            Console.WriteLine($"birinciForm.Eposta: {girisForm.Eposta}");
            eposta = girisForm.Eposta;
            MessageBox.Show("E:posta: " + eposta);


        }



        private void Form2_Load(object sender, EventArgs e)
        {

            
            try
            {
                baglanti.Open();
                int mevcutBakiye = GetKalanBakiye();
                mevcutbakiyelabel.Text = "Mevcut Bakiye: " + mevcutBakiye.ToString() + " TL";
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select * from tribunler", baglanti);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                TribunIDcomboBox1.DisplayMember = "tribunid";
                TribunIDcomboBox1.ValueMember = "tribunad";
                TribunIDcomboBox1.DataSource = dt2;

                NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select * from maclar", baglanti);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                macIDcomboBox1.DisplayMember = "macid";
                macIDcomboBox1.ValueMember = "evsahibitakim";
                macIDcomboBox1.DataSource = dt3;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }




        }

        private void BtnTribunListele_Click(object sender, EventArgs e)
        {
            object secilenOge = macIDcomboBox1.SelectedItem;

            if (secilenOge is DataRowView)
            {
                string secilenMacID = ((DataRowView)secilenOge).Row["macid"].ToString();

                if (!string.IsNullOrEmpty(secilenMacID))
                {
                    string sorgu;

                    // Check if the selected macID is 11, 16, 18, or 24
                    int macID = Convert.ToInt32(secilenMacID);
                    if (macID == 9 || macID == 13 || macID == 15 || macID == 20)
                    {
                        // Use derbisorgu for specific macID values
                        sorgu = "SELECT d.tribunid,tribunler.tribunad, d.biletfiyati " +
                                "FROM derbi_tribunler d " +
                                "JOIN tribunler ON d.tribunid = tribunler.tribunid " +
                                "WHERE d.evsahibiid = @macID";
                    }
                    else
                    {
                        // Use the default sorgu for other macID values
                        sorgu = "SELECT tribunler.tribunid,tribunler.tribunad, biletfiyatlari.biletfiyati " +
                                "FROM biletfiyatlari " +
                                "JOIN takimlar ON biletfiyatlari.takimid = takimlar.takimid " +
                                "JOIN tribunler ON biletfiyatlari.tribunid = tribunler.tribunid " +
                                "WHERE takimlar.takimid = @macID";
                    }

                    NpgsqlCommand cmd = new NpgsqlCommand(sorgu, baglanti);
                    cmd.Parameters.AddWithValue("@macID", Convert.ToInt32(secilenMacID));

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    labelSecilenTakim.Text = "Seçilen Takım: ";
                    labelTakimIsmi.Text = GetTakimIsmi(secilenMacID);
                }
                else
                {
                    MessageBox.Show("Tanımsız Maç: " + secilenMacID);
                }
            }
        }



        private string GetTakimIsmi(string macid)
        {
            if (macid == "1" || macid == "9")
                return "Beşiktaş";
            else if (macid == "2" || macid == "15")
                return "Fenerbahçe";
            else if (macid == "3" || macid == "13" || macid == "20")
                return "Galatasaray";
            else if (macid == "4")
                return "Samsunspor";
            else if (macid == "5")
                return "Adana Demirspor";
            else if (macid == "6")
                return "Altay";
            else if (macid == "7")
                return "Bandırmaspor";
            else if (macid == "8")
                return "Boluspor";
            else if (macid == "10")
                return "Ankaragücü";
            else if (macid == "11")
                return "Gençlerbirliği";
            else if (macid == "12")
                return "Kocaelispor";
            else if (macid == "14")
                return "Sivasspor";
            else if (macid == "16")
                return "Giresunspor";
            else if (macid == "19")
                return "Sakaryaspor";
            else if (macid == "18")
                return "Keçiörengücü FK";
            else if (macid == "17")
                return "Göztepe";
            else
                return "Bilinmeyen Takım";
        }


        private void BtnBilgileriGöster_Click(object sender, EventArgs e)
        {
            int tribunid = int.Parse(TribunIDcomboBox1.Text);
            baglanti.Open();

            // Kullanıcının belirli tribündeki bilet bilgilerini sorgula
            NpgsqlCommand comut = new NpgsqlCommand("SELECT m.macid,b.eposta,t.tribunid,t.tribunad, b.biletsayisi,m.evsahibi\r\nFROM biletalanlar b\r\nJOIN tribunler t ON b.tribunid = t.tribunid\r\nJOIN maclar m ON b.macid = m.macid", baglanti);

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(comut);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                // Bilet bilgilerini göster
                dataGridView1.DataSource = dataTable; // DataGridView kullanarak tablo şeklinde gösterme
            }
            else
            {
                // Kullanıcının belirtilen tribünde bilet bulunamadığı için hata mesajı göster
                MessageBox.Show("Kullanıcının belirtilen tribünde bilet bulunamadığı için bilgiler gösterilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from maclar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }


        }


        private int GetBiletFiyati(int tribunid)
        {
            // Tribun fiyatını al
            int macid = int.Parse(macIDcomboBox1.Text);
            NpgsqlCommand getPriceKomut = new NpgsqlCommand("SELECT biletfiyati FROM biletfiyatlari WHERE tribunid = @tribunid AND takimid = @takimid LIMIT 1", baglanti);
            getPriceKomut.Parameters.AddWithValue("@tribunid", tribunid);
            getPriceKomut.Parameters.AddWithValue("@takimid", macid);


            object result = getPriceKomut.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
        }





        private void BiletGuncelle(int KullaniciId, int tribunid, int macid, int yeniBiletSayisi)
        {
            try
            {
                baglanti.Open();

                // Kullanıcının belirlediği tribünden daha önce aldığı bilet sayısını kontrol et
                string kontrolSorgu = "SELECT biletsayisi FROM biletalanlar WHERE kullaniciid = @kullaniciid AND tribunid = @tribunid AND macid = @macid";

                using (NpgsqlCommand kontrolCommand = new NpgsqlCommand(kontrolSorgu, baglanti))
                {
                    kontrolCommand.Parameters.AddWithValue("@kullaniciid", KullaniciId);
                    kontrolCommand.Parameters.AddWithValue("@tribunid", tribunid);
                    kontrolCommand.Parameters.AddWithValue("@macid", macid);

                    int alinanBiletSayisi = Convert.ToInt32(kontrolCommand.ExecuteScalar());

                    // Eğer aynı kombinasyon ile kayıt varsa, güncelleme yap

                    if (yeniBiletSayisi > 3)
                    {
                        MessageBox.Show("Toplam bilet sayısı 3'ten fazla olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (alinanBiletSayisi > 0)
                    {
                        string guncelleSorgu = "UPDATE biletalanlar SET biletsayisi = biletsayisi + @biletsayisi WHERE kullaniciid = @kullaniciid AND tribunid = @tribunid AND macid = @macid";
                        using (NpgsqlCommand guncelleCommand = new NpgsqlCommand(guncelleSorgu, baglanti))
                        {
                            guncelleCommand.Parameters.AddWithValue("@kullaniciid", KullaniciId);
                            guncelleCommand.Parameters.AddWithValue("@tribunid", tribunid);
                            guncelleCommand.Parameters.AddWithValue("@macid", macid);
                            guncelleCommand.Parameters.AddWithValue("@biletsayisi", yeniBiletSayisi);
                            guncelleCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Bilet sayısı güncellendi!");
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void BiletGuncelleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Bilet güncelleme işlemi için gerekli parametreleri buraya ekleyin
                int KullaniciId = kullaniciId; // Kullanıcı ID'si

                // Tribun ID'si kontrolü
                if (!int.TryParse(TribunIDcomboBox1.Text, out int tribunid))
                {
                    MessageBox.Show("Geçerli bir Tribun ID'si giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Maç ID'si kontrolü
                if (!int.TryParse(macIDcomboBox1.Text, out int macid))
                {
                    MessageBox.Show("Geçerli bir Maç ID'si giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Yeni bilet sayısı kontrolü
                if (!int.TryParse(BiletSayisitextBox1.Text, out int yeniBiletSayisi))
                {
                    MessageBox.Show("Geçerli bir Bilet Sayısı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Bilet güncelleme metotunu çağırın
                BiletGuncelle(KullaniciId, tribunid, macid, yeniBiletSayisi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }


        private int GetKalanBakiye()
        {
            string connectionString = "server=localhost;port=5432;Database=passo;user ID=postgres;password=admin";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Kullanıcının kalan bakiyesini al
                NpgsqlCommand getBakiyeCommand = new NpgsqlCommand("SELECT bakiye FROM users WHERE kullaniciid = @kullaniciid", connection);
                getBakiyeCommand.Parameters.AddWithValue("@kullaniciid", kullaniciId); // Replace with the actual eposta
                int kalanBakiye = Convert.ToInt32(getBakiyeCommand.ExecuteScalar());

                connection.Close();

                return kalanBakiye;
            }
        }


        private void DerbiGosterBtn_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from derbitablo";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void textBox1Arama_TextChanged(object sender, EventArgs e)
        {
            string arananMetin = textBox1Arama.Text;

            string query = "SELECT * FROM Maclar WHERE LOWER(evsahibi) LIKE '%" + arananMetin.ToLower() + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void BtnBakiyeTanımla_Click(object sender, EventArgs e)
        {
            
            string kartNumarasi = KartNumarasiTextBox.Text;
            string kartSahibi = KartSahibiTextBox.Text;
            string cvc = CVCTextBox.Text;
            int kalanBakiye = GetKalanBakiye();
            

            if (kartNumarasi.Length != 12)
            {
                MessageBox.Show("Kart numarası 12 haneli olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (kartSahibi.Any(char.IsDigit) || kartSahibi.Any(char.IsPunctuation))
            {
                MessageBox.Show("Kart sahibi isminde özel karakter veya sayı bulunmamalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] kartSahibiParts = kartSahibi.Split(' ');
            if (kartSahibiParts.Length > 3)
            {
                MessageBox.Show("Kart sahibi ismi geçerli değil. Lütfen ad ve soyadı ayrı ayrı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            


            if (cvc.Length != 3)
            {
                MessageBox.Show("CVC numarası 3 haneli olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(BakiyeYukletextBox.Text))
            {
                MessageBox.Show("Bakiye Girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(BakiyeYukletextBox.Text, out int enteredBakiye) || enteredBakiye > 10000)
            {
                MessageBox.Show("Bakiye en fazla 10,000 TL olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tanimlananbakiyelabel.Text = "Tanımlanan Bakiye: " + enteredBakiye.ToString() + " TL";



            string connectionString = "server=localhost;port=5432;Database=passo;user ID = postgres; password=admin";
            int girilenBakiye = int.Parse(BakiyeYukletextBox.Text);
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Get the user's ID based on their eposta (replace 'your_email' with the actual email)
                NpgsqlCommand getUserIdCommand = new NpgsqlCommand("SELECT kullaniciid FROM users WHERE eposta = @Eposta", connection);
                getUserIdCommand.Parameters.AddWithValue("@Eposta", eposta); // Replace with the actual eposta
                int userId = Convert.ToInt32(getUserIdCommand.ExecuteScalar());

                // Update the bakiye column for the user
                NpgsqlCommand updateBakiyeCommand = new NpgsqlCommand("UPDATE users SET bakiye = bakiye + @EnteredBakiye WHERE kullaniciid = @UserId", connection);
                updateBakiyeCommand.Parameters.AddWithValue("@EnteredBakiye", girilenBakiye);
                updateBakiyeCommand.Parameters.AddWithValue("@UserId", userId);
                updateBakiyeCommand.ExecuteNonQuery();

                connection.Close();
                
            }

            // If all validations pass, you can proceed with saving the card details or any other necessary actions.
            // ...
            mevcutbakiyelabel.Text = "Mevcut Bakiye: " + (kalanBakiye + girilenBakiye).ToString() + " TL";
            MessageBox.Show("Bakiye tanımlama başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void BiletIadebutton_Click(object sender, EventArgs e)
        {
            int tribunid = int.Parse(TribunIDcomboBox1.Text);
            int macid = int.Parse(macIDcomboBox1.Text);

            baglanti.Open();

            if (string.IsNullOrEmpty(BiletSayisitextBox1.Text) || !int.TryParse(BiletSayisitextBox1.Text, out int biletSayisiToDelete))
            {
                MessageBox.Show("Geçerli bir bilet sayısı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
                return;
            }

            // Kullanıcının belirli tribundaki bileti var mı kontrol et
            NpgsqlCommand kontrolKomut = new NpgsqlCommand("SELECT biletsayisi FROM biletalanlar WHERE kullaniciid = @kullaniciID AND tribunid = @tribunid AND macid = @macid", baglanti);
            kontrolKomut.Parameters.AddWithValue("@kullaniciID", kullaniciId);
            kontrolKomut.Parameters.AddWithValue("@tribunid", tribunid);
            kontrolKomut.Parameters.AddWithValue("@macid", macid);

            int mevcutBiletSayisi = Convert.ToInt32(kontrolKomut.ExecuteScalar());

            if (mevcutBiletSayisi >= biletSayisiToDelete)
            {
                int kalanBakiye = GetKalanBakiye();

                // Bilet varsa silme işlemi gerçekleştir
                NpgsqlCommand silKomut = new NpgsqlCommand("UPDATE biletalanlar SET biletsayisi = biletsayisi - @biletSayisiToDelete " +
                                                            "WHERE kullaniciid = @kullaniciid AND tribunid = @tribunid AND macid = @macid", baglanti);
                silKomut.Parameters.AddWithValue("@biletSayisiToDelete", biletSayisiToDelete);
                silKomut.Parameters.AddWithValue("@kullaniciID", kullaniciId);
                silKomut.Parameters.AddWithValue("@tribunid", tribunid);
                silKomut.Parameters.AddWithValue("@macid", macid);

                int silinenBiletSayisi = silKomut.ExecuteNonQuery();

                // İade işlemini gerçekleştir
                if (biletSayisiToDelete > 0)
                {
                    // İade işlemini gerçekleştir
                    int ticketPrice = GetBiletFiyati(tribunid); // Tribun fiyatını al
                    int refundAmount = biletSayisiToDelete * ticketPrice;

                    // Kullanıcının bakiyesini güncelle
                    using (NpgsqlCommand updateBakiyeKomut = new NpgsqlCommand("UPDATE users SET bakiye = bakiye + @refundAmount WHERE kullaniciid = @kullaniciId", baglanti))
                    {
                        updateBakiyeKomut.Parameters.AddWithValue("@refundAmount", refundAmount);
                        updateBakiyeKomut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                        updateBakiyeKomut.ExecuteNonQuery();
                    }

                    mevcutbakiyelabel.Text = "Mevcut Bakiye: " + (kalanBakiye + refundAmount).ToString() + " TL";
                    NpgsqlCommand temizleKomut = new NpgsqlCommand("DELETE FROM biletalanlar WHERE biletsayisi = 0 AND kullaniciid = @kullaniciid", baglanti);
                    temizleKomut.Parameters.AddWithValue("@kullaniciid", kullaniciId);

                    temizleKomut.ExecuteNonQuery();
                    MessageBox.Show($"{biletSayisiToDelete} bilet başarıyla iade edildi. İade miktarı: {refundAmount} TL", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Bilet yoksa hata mesajı göster
                    MessageBox.Show($"Kullanıcının belirtilen tribünde yeterli bilet bulunamadığı için iade işlemi gerçekleştirilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Bilet yoksa hata mesajı göster
                MessageBox.Show($"Kullanıcının belirtilen tribünde yeterli bilet bulunamadığı için iade işlemi gerçekleştirilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
        }


        private void BiletSatınAl_Click_1(object sender, EventArgs e)
        {
            string eposta = girisForm.Eposta;
            try
            {
                baglanti.Open();
                object secilenTribunOge = TribunIDcomboBox1.SelectedItem;
                object secilenMacOge = macIDcomboBox1.SelectedItem;


                if (secilenTribunOge is DataRowView && secilenMacOge is DataRowView)
                {
                    string secilenTribun = ((DataRowView)secilenTribunOge).Row["tribunid"].ToString();
                    string secilenMac = ((DataRowView)secilenMacOge).Row["macid"].ToString();

                    if (!string.IsNullOrEmpty(secilenTribun) && !string.IsNullOrEmpty(secilenMac))
                    {
                        int tribunid = int.Parse(secilenTribun);
                        int biletsayisi = int.Parse(BiletSayisitextBox1.Text);
                        int macid = int.Parse(secilenMac);

                        if (secilenTribun == "1" || secilenTribun == "2" || secilenTribun == "3" || secilenTribun == "4" || secilenTribun == "5" || secilenTribun == "6" || secilenTribun == "7" || secilenTribun == "8" || secilenTribun == "9")
                        {
                            // Kullanıcının belirlediği tribünden daha önce aldığı bilet sayısını kontrol et

                            string kontrolSorgu = "SELECT biletsayisi FROM biletalanlar WHERE kullaniciid = @kullaniciid AND tribunid = @tribunid AND macid = @macid";

                            using (NpgsqlCommand kontrolCommand = new NpgsqlCommand(kontrolSorgu, baglanti))
                            {

                                kontrolCommand.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                                kontrolCommand.Parameters.AddWithValue("@tribunid", tribunid);
                                kontrolCommand.Parameters.AddWithValue("@macid", macid);


                                int alinanBiletSayisi = Convert.ToInt32(kontrolCommand.ExecuteScalar());


                                // Toplam bilet sayısını kontrol et
                                if (alinanBiletSayisi > 3 || biletsayisi > 3)
                                {
                                    MessageBox.Show("Toplam bilet sayısı 3'ten fazla olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (!int.TryParse(BiletSayisitextBox1.Text, out int yeniBiletSayisi))
                                {
                                    MessageBox.Show("Geçerli bir Bilet Sayısı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (string.IsNullOrEmpty(BiletSayisitextBox1.Text))
                                {
                                    MessageBox.Show("Bilet sayısı girmelisiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (biletsayisi < 1)
                                {
                                    MessageBox.Show("Bilet sayısı 1'den küçük olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Toplam bilet sayısını kontrol et
                                if (alinanBiletSayisi > 0)
                                {
                                    
                                    // Calculate the difference in ticket count
                                    int ticketCountDifference = yeniBiletSayisi - alinanBiletSayisi;

                                    if (ticketCountDifference > 0)
                                    {
                                        // If increasing the ticket count, deduct the corresponding amount from the user's balance
                                        int ticketPrice = GetBiletFiyati(tribunid);
                                        int deductionAmount = ticketCountDifference * ticketPrice;

                                        if (deductionAmount > GetKalanBakiye())
                                        {
                                            MessageBox.Show("Yetersiz bakiye! Bilet sayısını azaltın veya bakiyenizi artırın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }

                                        // Update the user's balance
                                        NpgsqlCommand updateBakiyeKomut = new NpgsqlCommand("UPDATE users SET bakiye = bakiye - @deductionAmount WHERE kullaniciid = @kullaniciId", baglanti);
                                        updateBakiyeKomut.Parameters.AddWithValue("@deductionAmount", deductionAmount);
                                        updateBakiyeKomut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                        updateBakiyeKomut.ExecuteNonQuery();
                                        mevcutbakiyelabel.Text = "Mevcut Bakiye: " + GetKalanBakiye().ToString();
                                    }
                                    else if (ticketCountDifference < 0)
                                    {
                                        // If decreasing the ticket count, add the corresponding amount to the user's balance
                                        int ticketPrice = GetBiletFiyati(tribunid);
                                        int additionAmount = Math.Abs(ticketCountDifference) * ticketPrice;

                                        // Update the user's balance
                                        NpgsqlCommand updateBakiyeKomut = new NpgsqlCommand("UPDATE users SET bakiye = bakiye + @additionAmount WHERE kullaniciid = @kullaniciId", baglanti);
                                        updateBakiyeKomut.Parameters.AddWithValue("@additionAmount", additionAmount);
                                        updateBakiyeKomut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                        updateBakiyeKomut.ExecuteNonQuery();
                                        mevcutbakiyelabel.Text = "Mevcut Bakiye: " + GetKalanBakiye().ToString();
                                    }

                                    // Update the ticket count
                                    string guncelleSorgu = "UPDATE biletalanlar SET biletsayisi = @biletsayisi WHERE kullaniciid = @kullaniciid AND tribunid = @tribunid AND macid = @macid";
                                    using (NpgsqlCommand guncelleCommand = new NpgsqlCommand(guncelleSorgu, baglanti))
                                    {
                                        guncelleCommand.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                                        guncelleCommand.Parameters.AddWithValue("@tribunid", tribunid);
                                        guncelleCommand.Parameters.AddWithValue("@macid", macid);
                                        guncelleCommand.Parameters.AddWithValue("@biletsayisi", yeniBiletSayisi);
                                        guncelleCommand.ExecuteNonQuery();
                                    }

                                    MessageBox.Show("Bilet sayısı güncellendi!");
                                }

                                if (alinanBiletSayisi + biletsayisi > 3)
                                {
                                    
                                    return;
                                }

                                if (alinanBiletSayisi < 1)
                                {
                                    
                                    string ekleSorgu = "INSERT INTO biletalanlar (kullaniciid, eposta, tribunid, biletsayisi, macid) VALUES (@kullaniciid, @eposta, @tribunID, @biletsayisi, @macid)";
                                    using (NpgsqlCommand kmt2 = new NpgsqlCommand(ekleSorgu, baglanti))
                                    {
                                        kmt2.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                                        kmt2.Parameters.AddWithValue("@eposta", eposta);
                                        kmt2.Parameters.AddWithValue("@tribunID", tribunid);
                                        kmt2.Parameters.AddWithValue("@biletsayisi", biletsayisi);
                                        kmt2.Parameters.AddWithValue("@macid", macid);



                                        kmt2.ExecuteNonQuery();
                                    }
                                    int kalanBakiye = GetKalanBakiye();
                                    //bakiyeLabel.Text = "Kalan Bakiye: " + kalanBakiye.ToString() + " TL";
                                    mevcutbakiyelabel.Text = "Mevcut Bakiye: " + kalanBakiye.ToString();
                                    MessageBox.Show("Bilet satın alındı!");
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hata", ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        
        

    }
}
