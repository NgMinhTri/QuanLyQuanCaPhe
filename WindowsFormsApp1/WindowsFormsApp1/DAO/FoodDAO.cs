using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAO();
                return FoodDAO.instance;
            }
            private set { FoodDAO.instance = value; }
        }
        private FoodDAO()// hàm dựng
        {

        }
        public List<Food> GetFoodByIdCategory(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from Food where idCategory = "+id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
        public DataTable GetListFood()
        {
            return DataProvider.Instance.ExecuteQuery("USP_GetListFood");
        }

        public bool InsertFood( string name, int idCategory, float price)
        {
            string query = string.Format("insert into Food(name, idCategory, price) values( N'{0}', {1}, {2})",name, idCategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateFood(int idfood, string name, int idCategory, float price)
        {
            string query = string.Format("update Food set name = N'{0}', idCategory = {1}, price = {2} where id ={3}", name, idCategory, price, idfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(int idfood)
        {
            string query = string.Format("delete Food where id = " + idfood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<Food> GetListFoodByName(string name)
        {
            List<Food> list = new List<Food>();
            string query = string.Format("select * from Food where dbo.fuChuyenCoDauThanhKhongDau(name) like N'%' +N'{0}' + '%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }
    }
}
