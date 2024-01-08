using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;


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





            if (GirisYap(Eposta, sifre, out int kullaniciId))
            {
                MessageBox.Show("Giriş başarılı!");
                this.Hide();
                FutbolForm futbolForm = new FutbolForm(this, kullaniciId);
                futbolForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Giriş başarısız. E-posta veya şifrenizi kontrol edin.");
            }
        }
        private bool GirisYap(String Eposta, string sifre, out int kullaniciId)
        {
            kullaniciId = -1; // Default değer atanıyor.

            string connectionString = "Host=localhost;Username=postgres;Password=admin;Database=passo";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM users WHERE Eposta = @Eposta AND sifre = @Sifre";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Eposta", Eposta);
                    command.Parameters.AddWithValue("@Sifre", sifre);

                    int kullaniciSayisi = Convert.ToInt32(command.ExecuteScalar());

                    if (kullaniciSayisi > 0)
                    {
                        // Kullanıcı doğrulandı, kullanıcı ID'sini alabilirsiniz.
                        string query2 = "SELECT kullaniciid FROM users WHERE Eposta = @Eposta";
                        using (NpgsqlCommand command2 = new NpgsqlCommand(query2, connection))
                        {
                            command2.Parameters.AddWithValue("@Eposta", Eposta);

                            // ExecuteScalar kullanarak kullanıcı ID'sini al
                            object result = command2.ExecuteScalar();

                            if (result != null)
                            {
                                kullaniciId = Convert.ToInt32(result);
                                return true;
                            }
                        }
                    }
                }

                return false;
            }


        }

        private void SifretextBox2_TextChanged(object sender, EventArgs e)
        {
            SifretextBox2.PasswordChar = '*';

        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email && (email.EndsWith("gmail.com") || email.EndsWith("outlook.com"));
            }
            catch (FormatException)
            {
                return false;
            }
        }


        private static List<char> turkishCharacters = new List<char> { 'ğ', 'ü', 'ş', 'ı', 'ö', 'ç', 'Ğ', 'Ü', 'Ş', 'İ', 'Ö', 'Ç' };

        private bool ContainsTurkishCharacters(string text)
        {
            foreach (char c in text)
            {
                if (turkishCharacters.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }




        private void BtnKayıt_Click(object sender, EventArgs e)
        {
            
            
            KayıtFormu kayıt = new KayıtFormu();
            kayıt.ShowDialog();
        }



        private void sifreunuttumLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifreUnuttumForm passwordRecoveryForm = new sifreUnuttumForm();
            passwordRecoveryForm.ShowDialog();
        }

        private void ePostaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GirisForm_Load(object sender, EventArgs e)
        {

        }
    }
}



        

        
   