using Npgsql;
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
    public partial class GirisForm : Form
    {
        public string Eposta { get; private set; }
        public GirisForm()
        {
            InitializeComponent();

        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost;port=5432;Database=passo;user ID = postgres; password=admin");




        private void BtnGiris_Click(object sender, EventArgs e)
        {
            Eposta = ePostaTextBox1.Text;
            string sifre = SifretextBox2.Text;

            



            if (GirisYap(Eposta, sifre))
            {
                MessageBox.Show("Giriş başarılı!");
                this.Hide();
                FutbolForm futbolForm = new FutbolForm(this);
                futbolForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Giriş başarısız. E-posta veya şifrenizi kontrol edin.");
            }
        }
        private bool GirisYap(String Eposta, string sifre)
        {
            string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=passo";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM kullanicilar WHERE Eposta = @Eposta AND sifre = @Sifre";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Eposta", Eposta);
                    command.Parameters.AddWithValue("@Sifre", sifre);

                    int kullaniciSayisi = Convert.ToInt32(command.ExecuteScalar());

                    return kullaniciSayisi > 0;
                }
            }
        }

        private void SifretextBox2_TextChanged(object sender, EventArgs e)
        {
            SifretextBox2.PasswordChar = '*';

        }

        private void BtnKayıt_Click(object sender, EventArgs e)
        {
            Eposta = ePostaTextBox1.Text;
            string sifre = SifretextBox2.Text;
            baglanti.Open();
            if(!string.IsNullOrEmpty(Eposta) || !string.IsNullOrEmpty(sifre))
            {
                NpgsqlCommand command = new NpgsqlCommand("insert into kullanicilar (Eposta,sifre) values(@Eposta,@sifre)", baglanti);
                command.Parameters.AddWithValue("@Eposta", Eposta);
                command.Parameters.AddWithValue("@sifre", sifre);
                command.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("E-posta veya şifre boş kalamaz!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            baglanti.Close();
        }

        private void sifreunuttumLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifreUnuttumForm passwordRecoveryForm = new sifreUnuttumForm();
            passwordRecoveryForm.ShowDialog();
        }

        private void ePostaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



        

        
   