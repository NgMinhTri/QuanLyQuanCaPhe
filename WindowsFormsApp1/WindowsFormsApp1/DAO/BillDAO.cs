using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class BillDAO
    {
        //tạo singleton
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return BillDAO.instance;
            }
            private set { BillDAO.instance = value; }
        }
        private BillDAO()// hàm dựng
        {

        }

        public int GetUnCheckBillByTableID(int id)
         {
            DataTable data= DataProvider.Instance.ExecuteQuery("Select * from Bill where idTable = " + id + " and status = 0 ");
            if(data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
         }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery(" exec USP_InsertBill @idTable", new object[]{id});
        }
        public int GetMaxBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("");
            }
            catch
            {
                return 1;
            }
        }
        public void CheckOut(int id, int discount)
        {
            string query = "update Bill set status = 1, " + "discount =" + discount + " where id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

    }
}
