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

        public fAdmin()
        {
            InitializeComponent();
            // Lưu ý để trên các hàm hiển thị
            dataGVFood.DataSource = foodList;
            LoadDataTimePickerDate();
            LoadListFood();
            LoadCategory();
            AddFoodBinding();           
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

        private void txbFoodID_TextChanged(object sender, EventArgs e)
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

        #endregion




        #region DanhMuc
        private void btnShowDmuc_Click(object sender, EventArgs e)
        {

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
