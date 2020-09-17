using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApp1.DAO;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        public Account loginAccount;// cho phép ko dc xóa tài khoản hiện đang login

        public fAdmin()
        {
            InitializeComponent();
            // Lưu ý để trên các hàm hiển thị
            dataGVFood.DataSource = foodList;
            dataGVAccount.DataSource = accountList;
            LoadDataTimePickerDate();
            LoadListFood();
            LoadCategory();
            LoadAccount();
            AddFoodBinding();
            AddAccountBinding();
        }
        #region DoanhThu

        //Hàm set lại ngày từ đầu tháng tới cuối tháng
        void LoadDataTimePickerDate()
        {
            DateTime today = DateTime.Now;
            dateTimePKFormDate.Value = new DateTime(today.Year, today.Month, 1);
            dateTPKToDate.Value = dateTimePKFormDate.Value.AddMonths(1).AddDays(-1);
        }

        private void btnViewbill_Click(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDate(dateTimePKFormDate.Value, dateTPKToDate.Value);
        }

        #endregion


        #region ThucAn
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void AddFoodBinding()
        {
            // kĩ thuật Data Binding
            //  giá trị trong txbFoodName sẽ thay đổi dựa vào sự thay đổi của thuộc tính Name
            //trong cái dataGVFood.DataSource
            txbFoodName.DataBindings.Add(new Binding("Text", dataGVFood.DataSource, "name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dataGVFood.DataSource, "id", true, DataSourceUpdateMode.Never));
            numericFoodPrice.DataBindings.Add(new Binding("Value", dataGVFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
       
        void LoadCategory()
        {
            cbCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cbCategory.DisplayMember = "Name";
        }

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listfood = new List<Food>();
            listfood = FoodDAO.Instance.GetListFoodByName(name);
            return listfood;
        }

        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGVFood.SelectedCells.Count > 0)
                {
                    int id = (int)dataGVFood.SelectedCells[0].OwningRow.Cells["idCategory"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryByID(id);
                    cbCategory.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbCategory.Items)
                    {
                        if (item.Id == category.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbCategory.SelectedIndex = index;
                }
            }
            catch
            {
                
            }
             
        }

        private void btEditFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);
            string name = txbFoodName.Text;
            int categoryId = (cbCategory.SelectedItem as Category).Id;
            float price = (float)numericFoodPrice.Value;
            
            if(FoodDAO.Instance.UpdateFood(id, name, categoryId,price))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật không thành công", "Thông báo");
            }    
        }

        private void btAddFood_Click(object sender, EventArgs e)
        {
            
            string name = txbFoodName.Text;
            int categoryId = (cbCategory.SelectedItem as Category).Id;
            float price = (float)numericFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryId, price))
            {
                MessageBox.Show("Thêm thông tin thức ăn thành công", "Thông báo");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Lỗi thêm thức ăn không thành công", "Thông báo");
            }
        }
        private void btDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(id);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa thông tin thức ăn thành công", "Thông báo");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());               
            }
            else
            {
                MessageBox.Show("Lỗi xóa không thành công", "Thông báo");
            }
        }

        private void btShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btFindFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource =  SearchFoodByName(tbSearchFoodName.Text);
        }

        #endregion


        #region DanhMuc
        private void btnShowDmuc_Click(object sender, EventArgs e)
        {

        }





        #endregion

        #region Account
        
        void AddAccountBinding()
        {
            txbUserAccount.DataBindings.Add(new Binding("Text", dataGVAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisAccount.DataBindings.Add(new Binding("Text", dataGVAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDownType.DataBindings.Add(new Binding("Value", dataGVAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        private void btnXemAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnSuaAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserAccount.Text;
            string displayname = txbDisAccount.Text;
            int type = Convert.ToInt32(numericUpDownType.Text);
            if (AccountDAO.Instance.UpdateAccount(username, displayname, type))
            {
                MessageBox.Show("Đã sửa tài khoản thành công", "Thông báo");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Lỗi sửa tài khoản", "Thông báo");
            }
        }

        private void btnXoaAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserAccount.Text;
            if(loginAccount.UserName.Equals(username))
            {
                MessageBox.Show("Không được xóa tài khoản hiện đang đăng nhập ", "Thông báo");
            }    
            
            else if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Đã xóa tài khoản thành công", "Thông báo");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Lỗi xóa tài khoản", "Thông báo");
            }
        }

        private void btnThemAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserAccount.Text;
            string displayname = txbDisAccount.Text;
            int type =Convert.ToInt32(numericUpDownType.Text);
            if(AccountDAO.Instance.InsertAccount(username, displayname, type))
            {
                MessageBox.Show("Đã thêm tài khoản thành công", "Thông báo");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Lỗi thêm tài khoản", "Thông báo");
            }    
        }

        private void btnSetPass_Click(object sender, EventArgs e)
        {
            string username = txbUserAccount.Text;
            if (AccountDAO.Instance.ResetAccount(username))
            {
                MessageBox.Show("Đặt lại mật khẩu tài khoản thành công", "Thông báo");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Lỗi đặt lại mật khẩu tài khoản", "Thông báo");
            }
        }

        #endregion



        #region Events
        private event EventHandler insertFood;
        public  event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }



        #endregion

        
    }
}
