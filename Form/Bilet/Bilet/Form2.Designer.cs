﻿namespace Bilet
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
            this.BtnBiletSatinAl = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnMacListele = new System.Windows.Forms.Button();
            this.TribunIDcomboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnBilgileriGöster = new System.Windows.Forms.Button();
            this.labelBlok = new System.Windows.Forms.Label();
            this.Bilgiler = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bilgiler2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.macIDcomboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(822, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnBiletSatinAl
            // 
            this.BtnBiletSatinAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBiletSatinAl.Location = new System.Drawing.Point(859, 299);
            this.BtnBiletSatinAl.Name = "BtnBiletSatinAl";
            this.BtnBiletSatinAl.Size = new System.Drawing.Size(215, 73);
            this.BtnBiletSatinAl.TabIndex = 1;
            this.BtnBiletSatinAl.Text = "Bilet Satın Al";
            this.BtnBiletSatinAl.UseVisualStyleBackColor = true;
            this.BtnBiletSatinAl.Click += new System.EventHandler(this.BtnBiletSatinAl_Click);
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
            this.BtnMacListele.Location = new System.Drawing.Point(1131, 220);
            this.BtnMacListele.Name = "BtnMacListele";
            this.BtnMacListele.Size = new System.Drawing.Size(215, 73);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(115, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seçilen Tribün";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(559, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Bilet Fiyatı";
            // 
            // BtnBilgileriGöster
            // 
            this.BtnBilgileriGöster.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnBilgileriGöster.Location = new System.Drawing.Point(1131, 299);
            this.BtnBilgileriGöster.Name = "BtnBilgileriGöster";
            this.BtnBilgileriGöster.Size = new System.Drawing.Size(215, 73);
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
            this.button1.Location = new System.Drawing.Point(862, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 73);
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
            this.macIDcomboBox1.SelectedIndexChanged += new System.EventHandler(this.macIDcomboBox1_SelectedIndexChanged);
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
            // FutbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 549);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.macIDcomboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bilgiler2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Bilgiler);
            this.Controls.Add(this.labelBlok);
            this.Controls.Add(this.BtnBilgileriGöster);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TribunIDcomboBox1);
            this.Controls.Add(this.BtnMacListele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnBiletSatinAl);
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
        private System.Windows.Forms.Button BtnBiletSatinAl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnMacListele;
        private System.Windows.Forms.ComboBox TribunIDcomboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnBilgileriGöster;
        private System.Windows.Forms.Label labelBlok;
        private System.Windows.Forms.Label Bilgiler;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label bilgiler2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox macIDcomboBox1;
        private System.Windows.Forms.Label label5;
    }
}