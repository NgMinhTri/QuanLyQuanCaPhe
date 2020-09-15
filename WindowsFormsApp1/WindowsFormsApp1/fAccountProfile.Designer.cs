namespace WindowsFormsApp1
{
    partial class fAccountProfile
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
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.TenDN = new System.Windows.Forms.Label();
            this.TenHienThi = new System.Windows.Forms.Label();
            this.txbDisplayName = new System.Windows.Forms.TextBox();
            this.MK = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.MKmoi = new System.Windows.Forms.Label();
            this.txbNewPass = new System.Windows.Forms.TextBox();
            this.NhapLaiMK = new System.Windows.Forms.Label();
            this.txbTypeAgain = new System.Windows.Forms.TextBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btCapNhat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbUserName
            // 
            this.txbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.Location = new System.Drawing.Point(256, 46);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.ReadOnly = true;
            this.txbUserName.Size = new System.Drawing.Size(360, 30);
            this.txbUserName.TabIndex = 3;
            // 
            // TenDN
            // 
            this.TenDN.AutoSize = true;
            this.TenDN.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TenDN.Location = new System.Drawing.Point(45, 46);
            this.TenDN.Name = "TenDN";
            this.TenDN.Size = new System.Drawing.Size(205, 32);
            this.TenDN.TabIndex = 2;
            this.TenDN.Text = "Tên đăng nhập";
            // 
            // TenHienThi
            // 
            this.TenHienThi.AutoSize = true;
            this.TenHienThi.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TenHienThi.Location = new System.Drawing.Point(51, 105);
            this.TenHienThi.Name = "TenHienThi";
            this.TenHienThi.Size = new System.Drawing.Size(162, 32);
            this.TenHienThi.TabIndex = 2;
            this.TenHienThi.Text = "Tên hiển thị";
            // 
            // txbDisplayName
            // 
            this.txbDisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDisplayName.Location = new System.Drawing.Point(256, 105);
            this.txbDisplayName.Name = "txbDisplayName";
            this.txbDisplayName.Size = new System.Drawing.Size(360, 30);
            this.txbDisplayName.TabIndex = 3;
            // 
            // MK
            // 
            this.MK.AutoSize = true;
            this.MK.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.MK.Location = new System.Drawing.Point(51, 163);
            this.MK.Name = "MK";
            this.MK.Size = new System.Drawing.Size(130, 32);
            this.MK.TabIndex = 2;
            this.MK.Text = "Mật khẩu";
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(256, 163);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(360, 30);
            this.txbPassword.TabIndex = 3;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // MKmoi
            // 
            this.MKmoi.AutoSize = true;
            this.MKmoi.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.MKmoi.Location = new System.Drawing.Point(51, 232);
            this.MKmoi.Name = "MKmoi";
            this.MKmoi.Size = new System.Drawing.Size(186, 32);
            this.MKmoi.TabIndex = 2;
            this.MKmoi.Text = "Mật khẩu mới";
            // 
            // txbNewPass
            // 
            this.txbNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewPass.Location = new System.Drawing.Point(256, 232);
            this.txbNewPass.Name = "txbNewPass";
            this.txbNewPass.Size = new System.Drawing.Size(360, 30);
            this.txbNewPass.TabIndex = 3;
            this.txbNewPass.UseSystemPasswordChar = true;
            // 
            // NhapLaiMK
            // 
            this.NhapLaiMK.AutoSize = true;
            this.NhapLaiMK.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NhapLaiMK.Location = new System.Drawing.Point(51, 296);
            this.NhapLaiMK.Name = "NhapLaiMK";
            this.NhapLaiMK.Size = new System.Drawing.Size(117, 32);
            this.NhapLaiMK.TabIndex = 2;
            this.NhapLaiMK.Text = "Nhập lại";
            // 
            // txbTypeAgain
            // 
            this.txbTypeAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTypeAgain.Location = new System.Drawing.Point(256, 296);
            this.txbTypeAgain.Name = "txbTypeAgain";
            this.txbTypeAgain.Size = new System.Drawing.Size(360, 30);
            this.txbTypeAgain.TabIndex = 3;
            this.txbTypeAgain.UseSystemPasswordChar = true;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.Location = new System.Drawing.Point(496, 362);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(112, 54);
            this.btExit.TabIndex = 7;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btCapNhat
            // 
            this.btCapNhat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCapNhat.Location = new System.Drawing.Point(345, 362);
            this.btCapNhat.Name = "btCapNhat";
            this.btCapNhat.Size = new System.Drawing.Size(118, 54);
            this.btCapNhat.TabIndex = 6;
            this.btCapNhat.Text = "Cập nhật";
            this.btCapNhat.UseVisualStyleBackColor = false;
            this.btCapNhat.Click += new System.EventHandler(this.btCapNhat_Click);
            // 
            // fAccountProfile
            // 
            this.AcceptButton = this.btCapNhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(640, 434);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btCapNhat);
            this.Controls.Add(this.txbTypeAgain);
            this.Controls.Add(this.txbNewPass);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbDisplayName);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.NhapLaiMK);
            this.Controls.Add(this.MKmoi);
            this.Controls.Add(this.MK);
            this.Controls.Add(this.TenHienThi);
            this.Controls.Add(this.TenDN);
            this.Name = "fAccountProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin cá nhân";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Label TenDN;
        private System.Windows.Forms.Label TenHienThi;
        private System.Windows.Forms.TextBox txbDisplayName;
        private System.Windows.Forms.Label MK;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label MKmoi;
        private System.Windows.Forms.TextBox txbNewPass;
        private System.Windows.Forms.Label NhapLaiMK;
        private System.Windows.Forms.TextBox txbTypeAgain;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btCapNhat;
    }
}