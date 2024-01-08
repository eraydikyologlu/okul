namespace Bilet
{
    partial class GirisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ePostaTextBox1 = new System.Windows.Forms.TextBox();
            this.SifretextBox2 = new System.Windows.Forms.TextBox();
            this.BtnGiris = new System.Windows.Forms.Button();
            this.BtnKayıt = new System.Windows.Forms.Button();
            this.sifreunuttumLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(256, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-posta";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label2.Location = new System.Drawing.Point(259, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre";
            // 
            // ePostaTextBox1
            // 
            this.ePostaTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ePostaTextBox1.Location = new System.Drawing.Point(385, 114);
            this.ePostaTextBox1.Name = "ePostaTextBox1";
            this.ePostaTextBox1.Size = new System.Drawing.Size(422, 22);
            this.ePostaTextBox1.TabIndex = 2;
            this.ePostaTextBox1.TextChanged += new System.EventHandler(this.ePostaTextBox1_TextChanged);
            // 
            // SifretextBox2
            // 
            this.SifretextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SifretextBox2.Location = new System.Drawing.Point(385, 179);
            this.SifretextBox2.Name = "SifretextBox2";
            this.SifretextBox2.Size = new System.Drawing.Size(422, 22);
            this.SifretextBox2.TabIndex = 3;
            this.SifretextBox2.TextChanged += new System.EventHandler(this.SifretextBox2_TextChanged);
            // 
            // BtnGiris
            // 
            this.BtnGiris.Location = new System.Drawing.Point(385, 262);
            this.BtnGiris.Name = "BtnGiris";
            this.BtnGiris.Size = new System.Drawing.Size(157, 57);
            this.BtnGiris.TabIndex = 4;
            this.BtnGiris.Text = "Giriş";
            this.BtnGiris.UseVisualStyleBackColor = true;
            this.BtnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // BtnKayıt
            // 
            this.BtnKayıt.Location = new System.Drawing.Point(671, 262);
            this.BtnKayıt.Name = "BtnKayıt";
            this.BtnKayıt.Size = new System.Drawing.Size(136, 57);
            this.BtnKayıt.TabIndex = 5;
            this.BtnKayıt.Text = "Kayıt Ol";
            this.BtnKayıt.UseVisualStyleBackColor = true;
            this.BtnKayıt.Click += new System.EventHandler(this.BtnKayıt_Click);
            // 
            // sifreunuttumLabel
            // 
            this.sifreunuttumLabel.AutoSize = true;
            this.sifreunuttumLabel.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.sifreunuttumLabel.LinkColor = System.Drawing.Color.Blue;
            this.sifreunuttumLabel.Location = new System.Drawing.Point(502, 214);
            this.sifreunuttumLabel.Name = "sifreunuttumLabel";
            this.sifreunuttumLabel.Size = new System.Drawing.Size(96, 16);
            this.sifreunuttumLabel.TabIndex = 6;
            this.sifreunuttumLabel.TabStop = true;
            this.sifreunuttumLabel.Text = "Şifremi unuttum";
            this.sifreunuttumLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.sifreunuttumLabel_LinkClicked);
            // 
            // GirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1021, 614);
            this.Controls.Add(this.sifreunuttumLabel);
            this.Controls.Add(this.BtnKayıt);
            this.Controls.Add(this.BtnGiris);
            this.Controls.Add(this.SifretextBox2);
            this.Controls.Add(this.ePostaTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GirisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Sayfası";
            this.Load += new System.EventHandler(this.GirisForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ePostaTextBox1;
        private System.Windows.Forms.TextBox SifretextBox2;
        private System.Windows.Forms.Button BtnGiris;
        private System.Windows.Forms.Button BtnKayıt;
        private System.Windows.Forms.LinkLabel sifreunuttumLabel;
    }
}