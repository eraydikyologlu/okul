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

namespace Bilet
{
    public partial class KayıtFormu : Form
    {
        public KayıtFormu()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localhost;port=5432;Database=passo;user ID = postgres; password=admin");


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



        private void kytbutton2_Click(object sender, EventArgs e)
        {
            string Eposta = ePostaTextBox2.Text;
            string sifre = SifretextBox3.Text;
            baglanti.Open();

            if (!string.IsNullOrEmpty(Eposta) && !string.IsNullOrEmpty(sifre))
            {
                if (!IsValidEmail(Eposta))
                {
                    MessageBox.Show("Geçersiz e-posta adresi! Lütfen gmail veya outlook kullanın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ContainsTurkishCharacters(sifre))
                {
                    MessageBox.Show("Şifre Türkçe karakter içermemelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ContainsTurkishCharacters(Eposta))
                {
                    MessageBox.Show("E-posta Türkçe karakter içermemelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // E-posta adresini kontrol et
                    NpgsqlCommand checkCommand = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE Eposta = @Eposta", baglanti);
                    checkCommand.Parameters.AddWithValue("@Eposta", Eposta);

                    int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingCount > 0)
                    {
                        MessageBox.Show("Bu e-posta adresi zaten kullanımda.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // E-posta adresi veritabanında yoksa kaydı yap
                        NpgsqlCommand insertCommand = new NpgsqlCommand("INSERT INTO users (Eposta, sifre, bakiye) VALUES (@Eposta, @sifre, @bakiye)", baglanti);
                        insertCommand.Parameters.AddWithValue("@Eposta", Eposta);
                        insertCommand.Parameters.AddWithValue("@sifre", sifre);
                        insertCommand.Parameters.AddWithValue("@bakiye", 0); // Set default bakiye to 0

                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Kullanıcı kaydı başarılı bir şekilde gerçekleşti.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("E-posta veya şifre boş kalamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
        }

        private void SifretextBox3_TextChanged(object sender, EventArgs e)
        {
            SifretextBox3.PasswordChar = '*';
        }
    }
   
    
}
