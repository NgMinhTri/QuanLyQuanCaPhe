using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MenuDAO();
                return MenuDAO.instance;
            }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO()// hàm dựng
        {

        }
        public List<Menu> GetListMenuByTable(int id)
        {
            string query = "select f.name, bi.count, f.price, f.price*bi.count as totalPrice from BillInfo as bi, Bill as b,Food as f where bi.idBill = b.id and bi.idFood = f.id and b.status = 0 and b.idTable =" + id;
                
            List<Menu> listmenu = new List<Menu>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}
