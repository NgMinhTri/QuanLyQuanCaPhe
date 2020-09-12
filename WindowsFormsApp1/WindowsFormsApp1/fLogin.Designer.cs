namespace WindowsFormsApp1
{
    partial class fLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btThoat = new System.Windows.Forms.Button();
            this.btdn = new System.Windows.Forms.Button();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.labelMK = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.lableTenDN = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btThoat);
            this.panel1.Controls.Add(this.btdn);
            this.panel1.Controls.Add(this.txbPassWord);
            this.panel1.Controls.Add(this.labelMK);
            this.panel1.Controls.Add(this.txbUserName);
            this.panel1.Controls.Add(this.lableTenDN);
            this.panel1.Location = new System.Drawing.Point(12, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 254);
            this.panel1.TabIndex = 0;
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Location = new System.Drawing.Point(413, 148);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(132, 55);
            this.btThoat.TabIndex = 5;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btdn
            // 
            this.btdn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btdn.Location = new System.Drawing.Point(261, 148);
            this.btdn.Name = "btdn";
            this.btdn.Size = new System.Drawing.Size(135, 55);
            this.btdn.TabIndex = 4;
            this.btdn.Text = "Đăng nhập";
            this.btdn.UseVisualStyleBackColor = true;
            this.btdn.Click += new System.EventHandler(this.btdn_Click);
            // 
            // txbPassWord
            // 
            this.txbPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassWord.Location = new System.Drawing.Point(261, 81);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(284, 34);
            this.txbPassWord.TabIndex = 3;
            this.txbPassWord.Text = "1712833";
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // labelMK
            // 
            this.labelMK.AutoSize = true;
            this.labelMK.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelMK.Location = new System.Drawing.Point(22, 81);
            this.labelMK.Name = "labelMK";
            this.labelMK.Size = new System.Drawing.Size(145, 35);
            this.labelMK.TabIndex = 2;
            this.labelMK.Text = "Mật khẩu";
            // 
            // txbUserName
            // 
            this.txbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.Location = new System.Drawing.Point(261, 32);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(284, 34);
            this.txbUserName.TabIndex = 1;
            this.txbUserName.Text = "1712833";
            // 
            // lableTenDN
            // 
            this.lableTenDN.AutoSize = true;
            this.lableTenDN.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lableTenDN.Location = new System.Drawing.Point(12, 30);
            this.lableTenDN.Name = "lableTenDN";
            this.lableTenDN.Size = new System.Drawing.Size(226, 35);
            this.lableTenDN.TabIndex = 0;
            this.lableTenDN.Text = "Tên đăng nhập";
            // 
            // fLogin
            // 
            this.AcceptButton = this.btdn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btThoat;
            this.ClientSize = new System.Drawing.Size(591, 290);
            this.Controls.Add(this.panel1);
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Label labelMK;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label lableTenDN;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btdn;
    }
}

