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
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select * from gstribun", baglanti);
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

            // Eğer seçilen öğe bir DataRowView öğesi ise, metnini bir string değişkenine dönüştürün
            if (secilenOge is DataRowView)
            {
                string secilenTribun = ((DataRowView)secilenOge).Row["macid"].ToString();

                if (!string.IsNullOrEmpty(secilenTribun))
                {
                    Dictionary<string, string> sorgular = new Dictionary<string, string>
            {
                { "1", "select * from beşiktaştribunnormal" },
                { "2", "select * from fenerbahçetribunnormal" },
                { "3", "select * from gstribunnormal" },
                { "4", "select * from samsunspor" },
                { "5", "select * from adanademirspor" },
                { "6", "select * from adanaspor" },
                { "7", "SELECT * FROM altay" },
                { "8", "SELECT * FROM bandırmaspor" },
                { "9", "SELECT * FROM boluspor" },
                { "10", "SELECT * FROM corumfk" },
                { "11", "SELECT * FROM beşiktaştribunderbi" },
                { "12", "SELECT * FROM kayserispor" },
                { "13", "SELECT * FROM ankaragücü" },
                { "14", "SELECT * FROM genclerbirligi" },
                { "15", "SELECT * FROM kocaelispor" },
                { "16", "SELECT * FROM gstribunderbi" },
                { "17", "SELECT * FROM sivasspor" },
                { "18", "SELECT * FROM fenerbahçetribunderbi" },
                { "19", "SELECT * FROM giresunspor" },
                { "20", "SELECT * FROM göztepe" },
                { "21", "SELECT * FROM keciören" },
                { "22", "SELECT * FROM manisa" },
                { "23", "SELECT * FROM sakaryaspor" },
                { "24", "SELECT * FROM gstribunnormal" },
            };

                    if (sorgular.TryGetValue(secilenTribun, out string sorgu))
                    {
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        labelSecilenTakim.Text = "Seçilen Takım: ";
                        labelTakimIsmi.Text = GetTakimIsmi(secilenTribun);
                    }
                    else
                    {
                        // Tanımlanmayan bir etkinlik tipi durumunda hata mesajı gösterin
                        MessageBox.Show("Tanımsız Maç: " + secilenTribun);
                    }
                }
            }
        }

        private string GetTakimIsmi(string secilenTribun)
        {
            switch (secilenTribun)
            {
                case "1":
                case "11":
                case "16":
                case "24":
                    return "Beşiktaş";
                case "2":
                case "18":
                    return "Fenerbahçe";
                case "3":
                case "8":
                    return "Galatasaray";
                case "4":
                    return "Samsunspor";
                case "5":
                    return "Adana Demirspor";
                case "6":
                    return "Adanaspor";
                case "7":
                    return "Altay";
                case "9":
                    return "Bandırmaspor";
                case "10":
                    return "Boluspor";
                case "12":
                    return "Çorum FK";
                case "13":
                    return "Ankaragücü";
                case "14":
                    return "Gençlerbirliği";
                case "15":
                    return "Kocaelispor";
                case "17":
                    return "Sivasspor";
                case "19":
                    return "Giresunspor";
                case "20":
                    return "Göztepe";
                case "21":
                    return "Keciören";
                case "22":
                    return "Manisa";
                case "23":
                    return "Sakaryaspor";
                default:
                    return "Bilinmeyen Takım";
            }
        }



        private void BtnBilgileriGöster_Click(object sender, EventArgs e)
        {
            int tribunid = int.Parse(TribunIDcomboBox1.Text);
            baglanti.Open();

            // Kullanıcının belirli tribündeki bilet bilgilerini sorgula
            NpgsqlCommand comut = new NpgsqlCommand("SELECT b.eposta, g.tribunad, b.biletsayisi,m.evsahibi\r\nFROM biletalanlar b\r\nJOIN gstribun g ON b.tribunid = g.tribunid\r\nJOIN maclar m ON b.macid = m.macid", baglanti);

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
            string sorgu = "select * from Maclar";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }


        }

        

        private void BiletSilBtn_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            int tribunid = int.Parse(TribunIDcomboBox1.Text);
            int macid = int.Parse(macIDcomboBox1.Text);
            // Kullanıcının belirli tribundaki bileti var mı kontrol et
            NpgsqlCommand kontrolKomut = new NpgsqlCommand("SELECT COUNT(*) FROM biletalanlar WHERE kullaniciid = @kullaniciID AND tribunid = @tribunid AND macid = @macid", baglanti);
            kontrolKomut.Parameters.AddWithValue("@kullaniciID", kullaniciId);
            kontrolKomut.Parameters.AddWithValue("@tribunid", tribunid);
            kontrolKomut.Parameters.AddWithValue("@macid",macid);


            int biletSayisi = Convert.ToInt32(kontrolKomut.ExecuteScalar());

            if (biletSayisi > 0)
            {
                // Bilet varsa silme işlemi gerçekleştir
                NpgsqlCommand silKomut = new NpgsqlCommand("DELETE FROM biletalanlar WHERE kullaniciid = @kullaniciID AND tribunid = @tribunid AND macid = @macid", baglanti);
                silKomut.Parameters.AddWithValue("@kullaniciID", kullaniciId);
                silKomut.Parameters.AddWithValue("@tribunid", tribunid);
                silKomut.Parameters.AddWithValue("@macid", macid);

                silKomut.ExecuteNonQuery();
                MessageBox.Show("Bilet silme işlemi başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Bilet yoksa hata mesajı göster
                MessageBox.Show("Kullanıcının belirtilen tribünde bilet bulunamadığı için silme işlemi gerçekleştirilemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
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
                        string guncelleSorgu = "UPDATE biletalanlar SET biletsayisi = @biletsayisi WHERE kullaniciid = @kullaniciid AND tribunid = @tribunid AND macid = @macid";
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
            // Bilet güncelleme işlemi için gerekli parametreleri buraya ekleyin
            int KullaniciId = kullaniciId; // Kullanıcı ID'si
            int tribunid = int.Parse(TribunIDcomboBox1.Text);    // Tribun ID'si
            int macid = int.Parse(macIDcomboBox1.Text);       // Maç ID'si
            int yeniBiletSayisi = int.Parse(BiletSayisitextBox1.Text); // Yeni bilet sayısı

            // Bilet güncelleme metotunu çağırın
            BiletGuncelle(KullaniciId, tribunid, macid, yeniBiletSayisi);
        }


        private void BiletSatınAl_Click(object sender, EventArgs e)
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
                                if (alinanBiletSayisi + biletsayisi > 3)
                                {
                                    MessageBox.Show("Toplam bilet sayısı 3'ten fazla olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Eğer aynı kombinasyon ile kayıt varsa, güncelleme yap
                                
                            }


                            // Eğer aynı kombinasyon ile kayıt yoksa, yeni bir kayıt ekle
                            string ekleSorgu = "INSERT INTO biletalanlar (kullaniciid, eposta, tribunid, biletsayisi, macid) VALUES (@kullaniciid, @eposta, @tribunID, @biletsayisi, @macid)";
                            using (NpgsqlCommand kmt2 = new NpgsqlCommand(ekleSorgu, baglanti))
                            {
                                kmt2.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                                kmt2.Parameters.AddWithValue("@eposta", eposta);
                                kmt2.Parameters.AddWithValue("@tribunID", tribunid);
                                kmt2.Parameters.AddWithValue("@biletsayisi", biletsayisi);
                                kmt2.Parameters.AddWithValue("@macid",macid);



                                kmt2.ExecuteNonQuery();
                            }

                            MessageBox.Show("Bilet satın alındı!");

                        }  
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
            bakiyeLabel.Text = "Bakiye: ";
            bakiyeBurdaLabel.Text = BakiyeYukletextBox.Text;

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
                NpgsqlCommand updateBakiyeCommand = new NpgsqlCommand("UPDATE users SET bakiye = @EnteredBakiye WHERE kullaniciid = @UserId", connection);
                updateBakiyeCommand.Parameters.AddWithValue("@EnteredBakiye", girilenBakiye);
                updateBakiyeCommand.Parameters.AddWithValue("@UserId", userId);
                updateBakiyeCommand.ExecuteNonQuery();

                connection.Close();
            }

            // If all validations pass, you can proceed with saving the card details or any other necessary actions.
            // ...

            MessageBox.Show("Bakiye tanımlama başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }
    }
}
