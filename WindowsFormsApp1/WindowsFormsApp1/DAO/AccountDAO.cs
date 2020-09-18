using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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


            //mã hóa MD5: từ mk hiện tại chuyển thành mảng byte, rồi dùng MD5 biến mảng đó
            //thành 1  mnagr byte khác dc băm ra
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);// băm theo mã máy
            string haspass = "";
            foreach (byte item in hashData)
            {
                haspass += item;
            }
            string query = "sp_Login @UserName , @Password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[]{username , password});
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

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select UserName, DisplayName, type from account");
        }

        public bool InsertAccount(string username, string displayname, int type)
        {
            string query = string.Format("insert into account(UserName, DisplayName, type) values( N'{0}', N'{1}', {2})", username, displayname, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(string username, string displayname, int type)
        {
            string query = string.Format("update account set DisplayName = N'{0}', type = {1} where UserName ={2}", displayname, type, username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string username)
        {
            string query = string.Format("delete account where UserName = " + username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetAccount(string username)
        {
            string query = string.Format("update account set Password = N'0' where UserName = " + username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
