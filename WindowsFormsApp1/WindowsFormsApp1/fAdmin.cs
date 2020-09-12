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
            LoadAccountList();
        }
        void LoadAccountList()
        {

            ////string query = "exec usp_GetAccountByUserName  @UserName";         
            ////DataProvider provider = new DataProvider();
            ////dataGVAccount.DataSource = provider.ExecuteQuery(query, new object[]{ "1712833"});

            string query = "exec usp_GetAccountByUserName  @UserName";
            dataGVAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { "1712833" });


        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
