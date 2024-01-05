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
                    // Seçilen etkinlik tipine göre uygun formu açın
                    switch (secilenTribun)
                    {
                        case "1":
                            string sorgu = "select * from beşiktaştribunnormal";
                            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sorgu, baglanti);
                            DataSet ds1 = new DataSet();
                            da1.Fill(ds1);
                            dataGridView1.DataSource = ds1.Tables[0];
                            break;
                        case "2":
                            string sorgu2 = "select * from fenerbahçetribunnormal";
                            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                            DataSet ds2 = new DataSet();
                            da2.Fill(ds2);
                            dataGridView1.DataSource = ds2.Tables[0];
                            break;
                        case "3":
                            string sorgu3 = "select * from gstribunnormal";
                            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
                            DataSet ds3 = new DataSet();
                            da3.Fill(ds3);
                            dataGridView1.DataSource = ds3.Tables[0];
                            break;
                        case "4":
                            string sorgu4 = "select * from samsunspor";
                            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, baglanti);
                            DataSet ds4 = new DataSet();
                            da4.Fill(ds4);
                            dataGridView1.DataSource = ds4.Tables[0];
                            break;
                        case "5":
                            string sorgu5 = "select * from adanademirspor";
                            NpgsqlDataAdapter da5 = new NpgsqlDataAdapter(sorgu5, baglanti);
                            DataSet ds5 = new DataSet();
                            da5.Fill(ds5);
                            dataGridView1.DataSource = ds5.Tables[0];
                            break;
                        case "6":
                            string sorgu6 = "select * from adanaspor";
                            NpgsqlDataAdapter da6 = new NpgsqlDataAdapter(sorgu6, baglanti);
                            DataSet ds6 = new DataSet();
                            da6.Fill(ds6);
                            dataGridView1.DataSource = ds6.Tables[0];
                            break;
                        case "7":
                            string sorgu7 = "SELECT * FROM altay"; // sorgu5'yi sorgu7 olarak değiştirildi
                            NpgsqlDataAdapter da7 = new NpgsqlDataAdapter(sorgu7, baglanti); // da5'i da7 olarak değiştirildi
                            DataSet ds7 = new DataSet();
                            da7.Fill(ds7);
                            dataGridView1.DataSource = ds7.Tables[0];
                            break;

                        case "8":
                            string sorgu8 = "SELECT * FROM bandırmaspor";
                            NpgsqlDataAdapter da8 = new NpgsqlDataAdapter(sorgu8, baglanti);
                            DataSet ds8 = new DataSet();
                            da8.Fill(ds8);
                            dataGridView1.DataSource = ds8.Tables[0];
                            break;

                        case "9":
                            string sorgu9 = "SELECT * FROM boluspor";
                            NpgsqlDataAdapter da9 = new NpgsqlDataAdapter(sorgu9, baglanti);
                            DataSet ds9 = new DataSet();
                            da9.Fill(ds9);
                            dataGridView1.DataSource = ds9.Tables[0];
                            break;

                        case "10":
                            string sorgu10 = "SELECT * FROM corumfk";
                            NpgsqlDataAdapter da10 = new NpgsqlDataAdapter(sorgu10, baglanti);
                            DataSet ds10 = new DataSet();
                            da10.Fill(ds10);
                            dataGridView1.DataSource = ds10.Tables[0];
                            break;

                        case "11":
                            string sorgu11 = "SELECT * FROM besiktastribunderbi";
                            NpgsqlDataAdapter da11 = new NpgsqlDataAdapter(sorgu11, baglanti);
                            DataSet ds11 = new DataSet();
                            da11.Fill(ds11);
                            dataGridView1.DataSource = ds11.Tables[0];
                            break;

                        case "12":
                            string sorgu12 = "SELECT * FROM kayserispor";
                            NpgsqlDataAdapter da12 = new NpgsqlDataAdapter(sorgu12, baglanti);
                            DataSet ds12 = new DataSet();
                            da12.Fill(ds12);
                            dataGridView1.DataSource = ds12.Tables[0];
                            break;

                        case "13":
                            string sorgu13 = "SELECT * FROM ankaragücü";
                            NpgsqlDataAdapter da13 = new NpgsqlDataAdapter(sorgu13, baglanti);
                            DataSet ds13 = new DataSet();
                            da13.Fill(ds13);
                            dataGridView1.DataSource = ds13.Tables[0];
                            break;

                        case "14":
                            string sorgu14 = "SELECT * FROM genclerbirligi";
                            NpgsqlDataAdapter da14 = new NpgsqlDataAdapter(sorgu14, baglanti);
                            DataSet ds14 = new DataSet();
                            da14.Fill(ds14);
                            dataGridView1.DataSource = ds14.Tables[0];
                            break;

                        case "15":
                            string sorgu15 = "SELECT * FROM kocaelispor";
                            NpgsqlDataAdapter da15 = new NpgsqlDataAdapter(sorgu15, baglanti);
                            DataSet ds15 = new DataSet();
                            da15.Fill(ds15);
                            dataGridView1.DataSource = ds15.Tables[0];
                            break;

                        case "16":
                            string sorgu16 = "SELECT * FROM gstribunderbi";
                            NpgsqlDataAdapter da16 = new NpgsqlDataAdapter(sorgu16, baglanti);
                            DataSet ds16 = new DataSet();
                            da16.Fill(ds16);
                            dataGridView1.DataSource = ds16.Tables[0];
                            break;

                        case "17":
                            string sorgu17 = "SELECT * FROM sivasspor";
                            NpgsqlDataAdapter da17 = new NpgsqlDataAdapter(sorgu17, baglanti);
                            DataSet ds17 = new DataSet();
                            da17.Fill(ds17);
                            dataGridView1.DataSource = ds17.Tables[0];
                            break;

                        case "18":
                            string sorgu18 = "SELECT * FROM fenerbahçetribunderbi";
                            NpgsqlDataAdapter da18 = new NpgsqlDataAdapter(sorgu18, baglanti);
                            DataSet ds18 = new DataSet();
                            da18.Fill(ds18);
                            dataGridView1.DataSource = ds18.Tables[0];
                            break;

                        case "19":
                            string sorgu19 = "SELECT * FROM giresunspor";
                            NpgsqlDataAdapter da19 = new NpgsqlDataAdapter(sorgu19, baglanti);
                            DataSet ds19 = new DataSet();
                            da19.Fill(ds19);
                            dataGridView1.DataSource = ds19.Tables[0];
                            break;

                        case "20":
                            string sorgu20 = "SELECT * FROM göztepe";
                            NpgsqlDataAdapter da20 = new NpgsqlDataAdapter(sorgu20, baglanti);
                            DataSet ds20 = new DataSet();
                            da20.Fill(ds20);
                            dataGridView1.DataSource = ds20.Tables[0];
                            break;

                        case "21":
                            string sorgu21 = "SELECT * FROM keciören";
                            NpgsqlDataAdapter da21 = new NpgsqlDataAdapter(sorgu21, baglanti);
                            DataSet ds21 = new DataSet();
                            da21.Fill(ds21);
                            dataGridView1.DataSource = ds21.Tables[0];
                            break;

                        case "22":
                            string sorgu22 = "SELECT * FROM manisa";
                            NpgsqlDataAdapter da22 = new NpgsqlDataAdapter(sorgu22, baglanti);
                            DataSet ds22 = new DataSet();
                            da22.Fill(ds22);
                            dataGridView1.DataSource = ds22.Tables[0];
                            break;

                        case "23":
                            string sorgu23 = "SELECT * FROM sakaryaspor";
                            NpgsqlDataAdapter da23 = new NpgsqlDataAdapter(sorgu23, baglanti);
                            DataSet ds23 = new DataSet();
                            da23.Fill(ds23);
                            dataGridView1.DataSource = ds23.Tables[0];
                            break;


                        case "24":
                            string sorgu24 = "SELECT * FROM gstribunnormal";
                            NpgsqlDataAdapter da24 = new NpgsqlDataAdapter(sorgu24, baglanti);
                            DataSet ds24 = new DataSet();
                            da24.Fill(ds24);
                            dataGridView1.DataSource = ds24.Tables[0];
                            break;




                        default:
                            // Tanımlanmayan bir etkinlik tipi durumunda hata mesajı gösterin
                            MessageBox.Show("Tanımsız Maç: " + secilenTribun);
                            break;
                    }
                }
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
    }
}
