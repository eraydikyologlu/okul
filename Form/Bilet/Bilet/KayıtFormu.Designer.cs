namespace Bilet
{
    partial class KayıtFormu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ePostaTextBox2 = new System.Windows.Forms.TextBox();
            this.SifretextBox3 = new System.Windows.Forms.TextBox();
            this.kytbutton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(173, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Posta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(173, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre";
            // 
            // ePostaTextBox2
            // 
            this.ePostaTextBox2.Location = new System.Drawing.Point(318, 122);
            this.ePostaTextBox2.Name = "ePostaTextBox2";
            this.ePostaTextBox2.Size = new System.Drawing.Size(185, 22);
            this.ePostaTextBox2.TabIndex = 2;
            // 
            // SifretextBox3
            // 
            this.SifretextBox3.Location = new System.Drawing.Point(318, 200);
            this.SifretextBox3.Name = "SifretextBox3";
            this.SifretextBox3.Size = new System.Drawing.Size(185, 22);
            this.SifretextBox3.TabIndex = 3;
            this.SifretextBox3.TextChanged += new System.EventHandler(this.SifretextBox3_TextChanged);
            // 
            // kytbutton2
            // 
            this.kytbutton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kytbutton2.Location = new System.Drawing.Point(318, 271);
            this.kytbutton2.Name = "kytbutton2";
            this.kytbutton2.Size = new System.Drawing.Size(169, 37);
            this.kytbutton2.TabIndex = 4;
            this.kytbutton2.Text = "KAYIT OL";
            this.kytbutton2.UseVisualStyleBackColor = true;
            this.kytbutton2.Click += new System.EventHandler(this.kytbutton2_Click);
            // 
            // KayıtFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kytbutton2);
            this.Controls.Add(this.SifretextBox3);
            this.Controls.Add(this.ePostaTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KayıtFormu";
            this.Text = "KayıtFormu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ePostaTextBox2;
        private System.Windows.Forms.TextBox SifretextBox3;
        private System.Windows.Forms.Button kytbutton2;
    }
}