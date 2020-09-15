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

namespace WindowsFormsApp1
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadDataTimePickerDate();
            //LoadListFood();
        }   
        //Hàm set lại ngày từ đầu tháng tới cuối tháng
        void LoadDataTimePickerDate()
        {
            DateTime today = DateTime.Now;
            dateTimePKFormDate.Value = new DateTime(today.Year, today.Month, 1);
            dateTPKToDate.Value = dateTimePKFormDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListFood()
        {
            dataGVFood.DataSource = FoodDAO.Instance.GetListFood();
        }
        private void btnViewbill_Click(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDate(dateTimePKFormDate.Value, dateTPKToDate.Value);
        }

        private void btEditFood_Click(object sender, EventArgs e)
        {

        }

        private void btAddFood_Click(object sender, EventArgs e)
        {

        }

        private void btnShowDmuc_Click(object sender, EventArgs e)
        {

        }

        private void btShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
    }
}
