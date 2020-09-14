using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }

        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void UpdateAccount()
        {
            string displayname = txbDisplayName.Text;
            string password = txbPassword.Text;
            string newpass = txbNewPass.Text;
            string reenterpass = txbTypeAgain.Text;
            string username = txbUserName.Text;
            if (!newpass.Equals(reenterpass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới", "Thông báo");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(username, displayname, password, newpass))//lưu ý theo thứ tự biến trong hàm
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    if (updateAccount1 != null)
                    updateAccount1(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(username)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu", "Thông báo");
                }
            }
        }

        public void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;


        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }
        // vì đã tồn tại 1 hàm trong lớp này với tên là UpdateAccount 
        //Nên phải tạo lại  tên khác ko dc trùng
        //tao Events
        private event EventHandler<AccountEvent> updateAccount1;
        public event EventHandler<AccountEvent> UpdateAccount1
        {
            add { updateAccount1 += value; }
            remove { updateAccount1 -= value;  }
        }
    }
    public class AccountEvent:EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }
        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
