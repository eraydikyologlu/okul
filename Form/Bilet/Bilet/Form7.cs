using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilet
{
    public partial class sifreUnuttumForm : Form
    {
        public sifreUnuttumForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userEmail = epostarecoveryTextBox.Text;

            // TODO: Implement logic to generate and send a new password to the user's email.

            MessageBox.Show("Yeni bir şifre e-posta adresinize gönderildi.", "Şifre Kurtarma", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
