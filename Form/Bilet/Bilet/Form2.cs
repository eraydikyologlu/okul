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

        public string Eposta
        {
            get { return eposta; }
            private set { eposta = value; }
        }
        private GirisForm girisForm;


        public FutbolForm(GirisForm girisForm)
        {
            InitializeComponent();
            this.girisForm = girisForm;

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





        private void BtnBiletSatinAl_Click(object sender, EventArgs e)
        {
            
            string eposta = girisForm.Eposta;
            //MessageBox.Show("Eposta: " + eposta);
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


                        if (secilenEtkinlik == "1")
                        {
                            string connectionString = "Host=localhost;Port=5432;Database=passo;Username=postgres;Password=admin";
                            

                            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                            {

                               connection.Open();

                                // Kullanıcının giriş yaptığı e-posta
                                
                                 // Burada eposta değişkenini kullanın, eğer bu değişken farklı bir yerden geliyorsa

                                for (int kullaniciid = 1; kullaniciid <= 10; kullaniciid++)
                                {
                                    // PostgreSQL sorgusu
                                    string sorgu = "SELECT eposta FROM kullanicilar WHERE kullaniciid = @kullaniciid";
                                                                            

                                    using (NpgsqlCommand command = new NpgsqlCommand(sorgu, connection))
                                    {
                                        command.CommandText = sorgu;

                                        command.Parameters.AddWithValue("@kullaniciid", kullaniciid);
                                        command.ExecuteNonQuery();

                                        using (NpgsqlDataReader reader = command.ExecuteReader())
                                        {
                                            if (reader.Read()) // Eğer veri varsa
                                            {
                                                string veritabaniEposta = reader["eposta"].ToString();

                                                // E-postaları karşılaştır
                                                if (eposta.Equals(veritabaniEposta, StringComparison.OrdinalIgnoreCase))
                                                {
                                                    MessageBox.Show("Giriş başarılı Kullanici id ve eposta: " + kullaniciid + eposta, "bilgi");




                                                    // Eğer e-postalar eşitse, istediğiniz işlemleri gerçekleştirebilirsiniz.
                                                    // Örneğin, bu e-posta değişkenini kullanabilirsiniz:
                                                    // string kullanilanEposta = girisEposta;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Kullanıcı ID {kullaniciid} ile giriş başarısız!");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Kullanıcı ID {kullaniciid} bulunamadı.");
                                            }
                                            

                                        }

                                    }
                                        
                                }
                                connection.Close();
                            }


                            // Kullanıcıya bilgi verir.


                            label1.Text = "Seçilen Tribün: Doğu Tribün Üst";
                            label3.Text = "Bilet fiyatı = 1100TL";


                        }
                        else if (secilenEtkinlik == "2")
                        {
                            biletsorgu = "UPDATE kullanicilar SET tribunid = @tribunid, tribun_ad = 'Doğu tribün alt'";
                            NpgsqlCommand kmt = new NpgsqlCommand(biletsorgu, baglanti);
                            
                            // Parametreleri ayarlar.
                            kmt.Parameters.AddWithValue("@tribunid", tribunid);



                            // Sorguyu çalıştırır.
                            try
                            {
                                kmt.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Hata mesajını yakalar.
                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Kullanıcı bilet kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();









                            label1.Text = "Seçilen Tribün: Doğu Tribünü alt";
                            label3.Text = "Bilet fiyatı = 1250TL";
                        }
                        else if (secilenEtkinlik == "3")
                        {
                            biletsorgu = "UPDATE kullanicilar SET tribunid = @tribunid, tribun_ad = 'Batı tribün üst'";
                            NpgsqlCommand kmt = new NpgsqlCommand(biletsorgu, baglanti);
                            //String eposta = this.Eposta;
                            // Parametreleri ayarlar.
                            kmt.Parameters.AddWithValue("@tribunid", tribunid);



                            // Sorguyu çalıştırır.
                            try
                            {
                                kmt.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Hata mesajını yakalar.
                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Kullanıcı bilet kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();
                            label1.Text = "Seçilen Tribün: Batı Tribünü üst";
                            label3.Text = "Bilet fiyatı = 750TL";
                        }
                        else if (secilenEtkinlik == "4")
                        {
                            


                            // Sorguyu çalıştırır.
                            try
                            {
                               // kmt.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Hata mesajını yakalar.
                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Kullanıcı bilet kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();

                            label1.Text = "Seçilen Tribün: Batı Tribünü alt";
                            label3.Text = "Bilet fiyatı = 600";
                        }
                        else if (secilenEtkinlik == "5")
                        {
                            biletsorgu = "UPDATE kullanicilar SET tribunid = @tribunid, tribun_ad = 'Kuzey tribün üst'";

                            NpgsqlCommand kmt = new NpgsqlCommand(biletsorgu, baglanti);

                            // Parametreleri ayarlar.
                            kmt.Parameters.AddWithValue("@tribunid", tribunid);



                            // Sorguyu çalıştırır.
                            try
                            {
                                kmt.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Hata mesajını yakalar.
                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Kullanıcı bilet kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();

                            label1.Text = "Seçilen Tribün: Kuzey Tribün üst";
                            label3.Text = "Bilet fiyatı = 800";
                        }
                        else if (secilenEtkinlik == "6")
                        {
                            biletsorgu = "UPDATE kullanicilar SET tribunid = @tribunid, tribun_ad = 'Kuzey tribün alt'";
                            NpgsqlCommand kmt = new NpgsqlCommand(biletsorgu, baglanti);

                            // Parametreleri ayarlar.
                            kmt.Parameters.AddWithValue("@tribunid", tribunid);



                            // Sorguyu çalıştırır.
                            try
                            {
                                kmt.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Hata mesajını yakalar.
                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Kullanıcı bilet kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();

                            label1.Text = "Seçilen Tribün: Kuzey Tribünü alt";
                            label3.Text = "Bilet fiyatı = 600";
                        }
                        else if (secilenEtkinlik == "7")
                        {
                            biletsorgu = "UPDATE kullanicilar SET tribunid = @tribunid, tribun_ad = 'Güney tribün üst'";
                            NpgsqlCommand kmt = new NpgsqlCommand(biletsorgu, baglanti);

                            // Parametreleri ayarlar.
                            kmt.Parameters.AddWithValue("@tribunid", tribunid);



                            // Sorguyu çalıştırır.
                            try
                            {
                                kmt.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Hata mesajını yakalar.
                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Kullanıcı bilet kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();

                            label1.Text = "Seçilen Tribün: Güney Tribünü üst";
                            label3.Text = "Bilet fiyatı = 600";
                        }
                        else if (secilenEtkinlik == "8")
                        {
                            biletsorgu = "UPDATE kullanicilar SET tribunid = @tribunid, tribun_ad = 'Güney tribün alt'";
                            NpgsqlCommand kmt = new NpgsqlCommand(biletsorgu, baglanti);

                            // Parametreleri ayarlar.
                            kmt.Parameters.AddWithValue("@tribunid", tribunid);



                            // Sorguyu çalıştırır.
                            try
                            {
                                kmt.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Hata mesajını yakalar.
                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Kullanıcı bilet kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();

                            label1.Text = "Seçilen Tribün: Güney Tribünü alt";
                            label3.Text = "Bilet fiyatı = 600";
                        }
                        else if (secilenEtkinlik == "9")
                        {
                            biletsorgu = "UPDATE kullanicilar SET tribunid = @tribunid, tribun_ad = 'Misafir tribün'";
                            NpgsqlCommand kmt = new NpgsqlCommand(biletsorgu, baglanti);

                            // Parametreleri ayarlar.
                            kmt.Parameters.AddWithValue("@tribunid", tribunid);



                            // Sorguyu çalıştırır.
                            try
                            {
                                kmt.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Hata mesajını yakalar.
                                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            MessageBox.Show("Kullanıcı bilet kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();

                            label1.Text = "Seçilen Tribün: Misafir Tribünü";
                            label3.Text = "Bilet fiyatı = 600";
                        }
                        NpgsqlDataAdapter dada = new NpgsqlDataAdapter(biletsorgu, baglanti);
                        DataSet dsds = new DataSet();
                        dada.Fill(dsds);

                        if (dsds.Tables.Count > 0)
                        {
                            dataGridView1.DataSource = dsds.Tables[0];
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

        private void BtnBilgileriGöster_Click(object sender, EventArgs e)
        {
            int tribunid = int.Parse(TribunIDcomboBox1.Text);
            baglanti.Open();
            NpgsqlCommand comut = new NpgsqlCommand("SELECT eposta FROM kullanicilar WHERE eposta = @eposta",baglanti);
            comut.Parameters.AddWithValue("@eposta", Eposta);
            String ePosta = girisForm.Eposta;
            Bilgiler.Text = "E-posta: " + ePosta;
            bilgiler2.Text = "Tribün ID: " + tribunid;

            comut.ExecuteNonQuery();
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
    }
}
