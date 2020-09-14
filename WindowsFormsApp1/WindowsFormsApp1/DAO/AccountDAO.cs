using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return AccountDAO.instance;
            }
            private set { AccountDAO.instance = value; }
        }
        private AccountDAO()// hàm dựng
        {

        }
        public bool Login(string username, string password)
        {
            //string query = "select * from account where UserName = '"+username+"' and Password = '"+password+"'";
            string query = "sp_Login @UserName , @Password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[]{username , password });
            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account where UserName = '" + username +"'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool UpdateAccount(string username, string displayname, string password, string newpass)
        {
             int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @UserName , @DisplayName , @PassWord , @NewPassWord ", new object[] {  username , displayname , password , newpass });
             return result > 0;
        }

    }
}
