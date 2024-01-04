using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

                NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select * from futbol", baglanti);
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
                string secilenEtkinlik = ((DataRowView)secilenOge).Row["macid"].ToString();

                if (!string.IsNullOrEmpty(secilenEtkinlik))
                {
                    // Seçilen etkinlik tipine göre uygun formu açın
                    switch (secilenEtkinlik)
                    {
                        case "1":
                            string sorgu = "select * from gstribun";
                            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sorgu, baglanti);
                            DataSet ds1 = new DataSet();
                            da1.Fill(ds1);
                            dataGridView1.DataSource = ds1.Tables[0];
                            break;
                        case "2":
                            string sorgu2 = "select * from barcatribun";
                            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                            DataSet ds2 = new DataSet();
                            da2.Fill(ds2);
                            dataGridView1.DataSource = ds2.Tables[0];
                            break;
                        case "3":
                            string sorgu3 = "select * from manchestertribun";
                            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(sorgu3, baglanti);
                            DataSet ds3 = new DataSet();
                            da3.Fill(ds3);
                            dataGridView1.DataSource = ds3.Tables[0];
                            break;
                        case "4":
                            string sorgu4 = "select * from barcatribun";
                            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(sorgu4, baglanti);
                            DataSet ds4 = new DataSet();
                            da4.Fill(ds4);
                            dataGridView1.DataSource = ds4.Tables[0];
                            break;
                        case "5":
                            string sorgu5 = "select * from barcatribun";
                            NpgsqlDataAdapter da5 = new NpgsqlDataAdapter(sorgu5, baglanti);
                            DataSet ds5 = new DataSet();
                            da5.Fill(ds5);
                            dataGridView1.DataSource = ds5.Tables[0];
                            break;



                        default:
                            // Tanımlanmayan bir etkinlik tipi durumunda hata mesajı gösterin
                            MessageBox.Show("Tanımsız Maç: " + secilenEtkinlik);
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
            NpgsqlCommand comut = new NpgsqlCommand("SELECT * FROM biletalanlar WHERE kullaniciid = @kullaniciid", baglanti);
            comut.Parameters.AddWithValue("@kullaniciid", kullaniciId);

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



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from futbol";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }


        }

        private void macIDcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BiletSilBtn_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            int tribunid = int.Parse(TribunIDcomboBox1.Text);

            // Kullanıcının belirli tribundaki bileti var mı kontrol et
            NpgsqlCommand kontrolKomut = new NpgsqlCommand("SELECT COUNT(*) FROM biletalanlar WHERE kullaniciid = @kullaniciID AND tribunid = @tribunid", baglanti);
            kontrolKomut.Parameters.AddWithValue("@kullaniciID", kullaniciId);
            kontrolKomut.Parameters.AddWithValue("@tribunid", tribunid);

            int biletSayisi = Convert.ToInt32(kontrolKomut.ExecuteScalar());

            if (biletSayisi > 0)
            {
                // Bilet varsa silme işlemi gerçekleştir
                NpgsqlCommand silKomut = new NpgsqlCommand("DELETE FROM biletalanlar WHERE kullaniciid = @kullaniciID AND tribunid = @tribunid", baglanti);
                silKomut.Parameters.AddWithValue("@kullaniciID", kullaniciId);
                silKomut.Parameters.AddWithValue("@tribunid", tribunid);
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

        private void BiletGuncelleBtn_Click(object sender, EventArgs e)
        {

        }

        private void BiletSatınAl_Click(object sender, EventArgs e)
        {
            
                string eposta = girisForm.Eposta;
                try
                {
                    baglanti.Open();
                    object secilenOge = TribunIDcomboBox1.SelectedItem;

                    if (secilenOge is DataRowView)
                    {
                        string secilenEtkinlik = ((DataRowView)secilenOge).Row["tribunid"].ToString();
                        string biletsorgu = "";

                        if (!string.IsNullOrEmpty(secilenEtkinlik))
                        {
                            int tribunid = int.Parse(TribunIDcomboBox1.Text);
                            int biletsayisi = int.Parse(BiletSayisitextBox1.Text);

                            if (secilenEtkinlik == "1" || secilenEtkinlik == "2" || secilenEtkinlik == "3" || secilenEtkinlik == "4" || secilenEtkinlik == "5" || secilenEtkinlik == "6" || secilenEtkinlik == "7" || secilenEtkinlik == "8" || secilenEtkinlik == "9")
                            {
                                // Kullanıcının belirlediği tribünden daha önce aldığı bilet sayısını kontrol et
                                string kontrolSorgu = "SELECT biletsayisi FROM biletalanlar WHERE kullaniciid = @kullaniciid AND tribunid = @tribunid";
                                using (NpgsqlCommand kontrolCommand = new NpgsqlCommand(kontrolSorgu, baglanti))
                                {
                                    kontrolCommand.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                                    kontrolCommand.Parameters.AddWithValue("@tribunid", tribunid);

                                    int alinanBiletSayisi = Convert.ToInt32(kontrolCommand.ExecuteScalar());

                                    // Toplam bilet sayısını kontrol et
                                    if (alinanBiletSayisi + biletsayisi > 3)
                                    {
                                        MessageBox.Show("Toplam bilet sayısı 3'ten fazla olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }

                                    // Eğer aynı kombinasyon ile kayıt varsa, güncelleme yap
                                    if (alinanBiletSayisi > 0)
                                    {
                                        string guncelleSorgu = "UPDATE biletalanlar SET biletsayisi = biletsayisi + @biletsayisi WHERE kullaniciid = @kullaniciid AND tribunid = @tribunid";
                                        using (NpgsqlCommand guncelleCommand = new NpgsqlCommand(guncelleSorgu, baglanti))
                                        {
                                            guncelleCommand.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                                            guncelleCommand.Parameters.AddWithValue("@tribunid", tribunid);
                                            guncelleCommand.Parameters.AddWithValue("@biletsayisi", biletsayisi);
                                            guncelleCommand.ExecuteNonQuery();
                                        }

                                        MessageBox.Show("Bilet sayısı güncellendi!");
                                        return;
                                    }
                                }

                                // Eğer aynı kombinasyon ile kayıt yoksa, yeni bir kayıt ekle
                                string ekleSorgu = "INSERT INTO biletalanlar (kullaniciid, eposta, tribunid, tribun_ad, biletsayisi) VALUES (@kullaniciid, @eposta, @tribunID,'Doğu tribun üst', @biletsayisi)";
                                using (NpgsqlCommand kmt = new NpgsqlCommand(ekleSorgu, baglanti))
                                {
                                    kmt.Parameters.AddWithValue("@kullaniciid", kullaniciId);
                                    kmt.Parameters.AddWithValue("@eposta", eposta);
                                    kmt.Parameters.AddWithValue("@tribunid", tribunid);
                                    kmt.Parameters.AddWithValue("@biletsayisi", biletsayisi);
                                    kmt.ExecuteNonQuery();
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
    }
}
