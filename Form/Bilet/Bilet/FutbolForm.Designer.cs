namespace Bilet
{
    partial class FutbolForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMacListele = new System.Windows.Forms.Button();
            this.TribunIDcomboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnBilgileriGöster = new System.Windows.Forms.Button();
            this.labelBlok = new System.Windows.Forms.Label();
            this.Bilgiler = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bilgiler2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.macIDcomboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BiletSilBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BiletSayisitextBox1 = new System.Windows.Forms.TextBox();
            this.BiletSatınAl = new System.Windows.Forms.Button();
            this.textBox1Arama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DerbiGosterBtn = new System.Windows.Forms.Button();
            this.labelSecilenTakim = new System.Windows.Forms.Label();
            this.labelTakimIsmi = new System.Windows.Forms.Label();
            this.BtnBakiyeTanımla = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.KartNumarasiTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.KartSahibiTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CVCTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BakiyeYukletextBox = new System.Windows.Forms.TextBox();
            this.tanimlananbakiyelabel = new System.Windows.Forms.Label();
            this.mevcutbakiyelabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(822, 337);
            this.dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(1108, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tribün ID";
            // 
            // BtnMacListele
            // 
            this.BtnMacListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnMacListele.Location = new System.Drawing.Point(1131, 258);
            this.BtnMacListele.Name = "BtnMacListele";
            this.BtnMacListele.Size = new System.Drawing.Size(215, 35);
            this.BtnMacListele.TabIndex = 6;
            this.BtnMacListele.Text = "Tribün Listele";
            this.BtnMacListele.UseVisualStyleBackColor = true;
            this.BtnMacListele.Click += new System.EventHandler(this.BtnTribunListele_Click);
            // 
            // TribunIDcomboBox1
            // 
            this.TribunIDcomboBox1.FormattingEnabled = true;
            this.TribunIDcomboBox1.Location = new System.Drawing.Point(1206, 52);
            this.TribunIDcomboBox1.Name = "TribunIDcomboBox1";
            this.TribunIDcomboBox1.Size = new System.Drawing.Size(109, 24);
            this.TribunIDcomboBox1.TabIndex = 7;
            // 
            // BtnBilgileriGöster
            // 
            this.BtnBilgileriGöster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBilgileriGöster.Location = new System.Drawing.Point(1124, 321);
            this.BtnBilgileriGöster.Name = "BtnBilgileriGöster";
            this.BtnBilgileriGöster.Size = new System.Drawing.Size(215, 40);
            this.BtnBilgileriGöster.TabIndex = 10;
            this.BtnBilgileriGöster.Text = "Bilgilerimi Göster";
            this.BtnBilgileriGöster.UseVisualStyleBackColor = true;
            this.BtnBilgileriGöster.Click += new System.EventHandler(this.BtnBilgileriGöster_Click);
            // 
            // labelBlok
            // 
            this.labelBlok.AutoSize = true;
            this.labelBlok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBlok.Location = new System.Drawing.Point(1119, 81);
            this.labelBlok.Name = "labelBlok";
            this.labelBlok.Size = new System.Drawing.Size(0, 22);
            this.labelBlok.TabIndex = 14;
            // 
            // Bilgiler
            // 
            this.Bilgiler.AutoSize = true;
            this.Bilgiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Bilgiler.Location = new System.Drawing.Point(1159, 9);
            this.Bilgiler.Name = "Bilgiler";
            this.Bilgiler.Size = new System.Drawing.Size(0, 39);
            this.Bilgiler.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(853, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 39);
            this.label4.TabIndex = 16;
            // 
            // bilgiler2
            // 
            this.bilgiler2.AutoSize = true;
            this.bilgiler2.Location = new System.Drawing.Point(859, 132);
            this.bilgiler2.Name = "bilgiler2";
            this.bilgiler2.Size = new System.Drawing.Size(0, 16);
            this.bilgiler2.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(862, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 37);
            this.button1.TabIndex = 18;
            this.button1.Text = "Maçları Listele";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // macIDcomboBox1
            // 
            this.macIDcomboBox1.FormattingEnabled = true;
            this.macIDcomboBox1.Location = new System.Drawing.Point(965, 53);
            this.macIDcomboBox1.Name = "macIDcomboBox1";
            this.macIDcomboBox1.Size = new System.Drawing.Size(109, 24);
            this.macIDcomboBox1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(835, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Maç seç (ID)";
            // 
            // BiletSilBtn
            // 
            this.BiletSilBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BiletSilBtn.Location = new System.Drawing.Point(974, 386);
            this.BiletSilBtn.Name = "BiletSilBtn";
            this.BiletSilBtn.Size = new System.Drawing.Size(212, 32);
            this.BiletSilBtn.TabIndex = 21;
            this.BiletSilBtn.Text = "Bileti Sil";
            this.BiletSilBtn.UseVisualStyleBackColor = true;
            this.BiletSilBtn.Click += new System.EventHandler(this.BiletSilBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(835, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Bilet sayısı";
            // 
            // BiletSayisitextBox1
            // 
            this.BiletSayisitextBox1.Location = new System.Drawing.Point(965, 132);
            this.BiletSayisitextBox1.Name = "BiletSayisitextBox1";
            this.BiletSayisitextBox1.Size = new System.Drawing.Size(100, 22);
            this.BiletSayisitextBox1.TabIndex = 25;
            // 
            // BiletSatınAl
            // 
            this.BiletSatınAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BiletSatınAl.Location = new System.Drawing.Point(865, 321);
            this.BiletSatınAl.Name = "BiletSatınAl";
            this.BiletSatınAl.Size = new System.Drawing.Size(209, 40);
            this.BiletSatınAl.TabIndex = 26;
            this.BiletSatınAl.Text = "Bilet Satın Al";
            this.BiletSatınAl.UseVisualStyleBackColor = true;
            this.BiletSatınAl.Click += new System.EventHandler(this.BiletSatınAl_Click);
            // 
            // textBox1Arama
            // 
            this.textBox1Arama.Location = new System.Drawing.Point(1186, 122);
            this.textBox1Arama.Name = "textBox1Arama";
            this.textBox1Arama.Size = new System.Drawing.Size(129, 22);
            this.textBox1Arama.TabIndex = 27;
            this.textBox1Arama.TextChanged += new System.EventHandler(this.textBox1Arama_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1113, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Ara";
            // 
            // DerbiGosterBtn
            // 
            this.DerbiGosterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DerbiGosterBtn.Location = new System.Drawing.Point(1166, 174);
            this.DerbiGosterBtn.Name = "DerbiGosterBtn";
            this.DerbiGosterBtn.Size = new System.Drawing.Size(173, 40);
            this.DerbiGosterBtn.TabIndex = 30;
            this.DerbiGosterBtn.Text = "Derbileri Göster";
            this.DerbiGosterBtn.UseVisualStyleBackColor = true;
            this.DerbiGosterBtn.Click += new System.EventHandler(this.DerbiGosterBtn_Click);
            // 
            // labelSecilenTakim
            // 
            this.labelSecilenTakim.AutoSize = true;
            this.labelSecilenTakim.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSecilenTakim.Location = new System.Drawing.Point(781, 435);
            this.labelSecilenTakim.Name = "labelSecilenTakim";
            this.labelSecilenTakim.Size = new System.Drawing.Size(0, 38);
            this.labelSecilenTakim.TabIndex = 31;
            // 
            // labelTakimIsmi
            // 
            this.labelTakimIsmi.AutoSize = true;
            this.labelTakimIsmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTakimIsmi.Location = new System.Drawing.Point(1065, 435);
            this.labelTakimIsmi.Name = "labelTakimIsmi";
            this.labelTakimIsmi.Size = new System.Drawing.Size(0, 38);
            this.labelTakimIsmi.TabIndex = 32;
            // 
            // BtnBakiyeTanımla
            // 
            this.BtnBakiyeTanımla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBakiyeTanımla.Location = new System.Drawing.Point(460, 422);
            this.BtnBakiyeTanımla.Name = "BtnBakiyeTanımla";
            this.BtnBakiyeTanımla.Size = new System.Drawing.Size(167, 38);
            this.BtnBakiyeTanımla.TabIndex = 33;
            this.BtnBakiyeTanımla.Text = "Tanımla";
            this.BtnBakiyeTanımla.UseVisualStyleBackColor = true;
            this.BtnBakiyeTanımla.Click += new System.EventHandler(this.BtnBakiyeTanımla_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(196, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 32);
            this.label3.TabIndex = 34;
            this.label3.Text = "Bakiye Tanımla";
            // 
            // KartNumarasiTextBox
            // 
            this.KartNumarasiTextBox.Location = new System.Drawing.Point(165, 394);
            this.KartNumarasiTextBox.Name = "KartNumarasiTextBox";
            this.KartNumarasiTextBox.Size = new System.Drawing.Size(227, 22);
            this.KartNumarasiTextBox.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(12, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 25);
            this.label7.TabIndex = 36;
            this.label7.Text = "Kart Numarası: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(12, 435);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 25);
            this.label8.TabIndex = 37;
            this.label8.Text = "Kart Sahibi";
            // 
            // KartSahibiTextBox
            // 
            this.KartSahibiTextBox.Location = new System.Drawing.Point(165, 438);
            this.KartSahibiTextBox.Name = "KartSahibiTextBox";
            this.KartSahibiTextBox.Size = new System.Drawing.Size(227, 22);
            this.KartSahibiTextBox.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(12, 475);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 25);
            this.label9.TabIndex = 39;
            this.label9.Text = "CVC";
            // 
            // CVCTextBox
            // 
            this.CVCTextBox.Location = new System.Drawing.Point(164, 475);
            this.CVCTextBox.Name = "CVCTextBox";
            this.CVCTextBox.Size = new System.Drawing.Size(115, 22);
            this.CVCTextBox.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(411, 368);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 25);
            this.label10.TabIndex = 41;
            this.label10.Text = "Bakiye Yükle:";
            // 
            // BakiyeYukletextBox
            // 
            this.BakiyeYukletextBox.Location = new System.Drawing.Point(548, 372);
            this.BakiyeYukletextBox.Name = "BakiyeYukletextBox";
            this.BakiyeYukletextBox.Size = new System.Drawing.Size(115, 22);
            this.BakiyeYukletextBox.TabIndex = 42;
            // 
            // tanimlananbakiyelabel
            // 
            this.tanimlananbakiyelabel.AutoSize = true;
            this.tanimlananbakiyelabel.Font = new System.Drawing.Font("Microsoft Yi Baiti", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tanimlananbakiyelabel.Location = new System.Drawing.Point(456, 463);
            this.tanimlananbakiyelabel.Name = "tanimlananbakiyelabel";
            this.tanimlananbakiyelabel.Size = new System.Drawing.Size(0, 23);
            this.tanimlananbakiyelabel.TabIndex = 44;
            // 
            // mevcutbakiyelabel
            // 
            this.mevcutbakiyelabel.AutoSize = true;
            this.mevcutbakiyelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mevcutbakiyelabel.Location = new System.Drawing.Point(835, 204);
            this.mevcutbakiyelabel.Name = "mevcutbakiyelabel";
            this.mevcutbakiyelabel.Size = new System.Drawing.Size(0, 25);
            this.mevcutbakiyelabel.TabIndex = 45;
            // 
            // FutbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 549);
            this.Controls.Add(this.mevcutbakiyelabel);
            this.Controls.Add(this.tanimlananbakiyelabel);
            this.Controls.Add(this.BakiyeYukletextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CVCTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.KartSahibiTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.KartNumarasiTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnBakiyeTanımla);
            this.Controls.Add(this.labelTakimIsmi);
            this.Controls.Add(this.labelSecilenTakim);
            this.Controls.Add(this.DerbiGosterBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1Arama);
            this.Controls.Add(this.BiletSatınAl);
            this.Controls.Add(this.BiletSayisitextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BiletSilBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.macIDcomboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bilgiler2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Bilgiler);
            this.Controls.Add(this.labelBlok);
            this.Controls.Add(this.BtnBilgileriGöster);
            this.Controls.Add(this.TribunIDcomboBox1);
            this.Controls.Add(this.BtnMacListele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.DoubleBuffered = true;
            this.Name = "FutbolForm";
            this.Text = "Futbol";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnMacListele;
        private System.Windows.Forms.ComboBox TribunIDcomboBox1;
        private System.Windows.Forms.Button BtnBilgileriGöster;
        private System.Windows.Forms.Label labelBlok;
        private System.Windows.Forms.Label Bilgiler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label bilgiler2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox macIDcomboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BiletSilBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BiletSayisitextBox1;
        private System.Windows.Forms.Button BiletSatınAl;
        private System.Windows.Forms.TextBox textBox1Arama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DerbiGosterBtn;
        private System.Windows.Forms.Label labelSecilenTakim;
        private System.Windows.Forms.Label labelTakimIsmi;
        private System.Windows.Forms.Button BtnBakiyeTanımla;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KartNumarasiTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox KartSahibiTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CVCTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox BakiyeYukletextBox;
        private System.Windows.Forms.Label tanimlananbakiyelabel;
        private System.Windows.Forms.Label mevcutbakiyelabel;
    }
}