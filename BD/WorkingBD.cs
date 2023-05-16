using Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BD
{
    public class WorkingBD
    {
        public static MySqlDataReader Connection(string query)
        {
            try
            {
                string connection = "server= localhost; uid = root; database= test_bd; port = 3306; pwd =Asdfg123";
                MySqlConnection mySqlConnection = new MySqlConnection(connection);
                mySqlConnection.Open();

                MySqlCommand command = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                return mySqlDataReader;
            }
            catch
            {
                MessageBox.Show("Ошибка в БД", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public static List<user> clUser = new List<user>();
        public static user user = new user();

        public static List<product> clProduct = new List<product>();
        public static product product = new product();

        public static List<category> clCategory = new List<category>();
        public static category category = new category();

        public static void LoadDataBase()
        {
            clUser.Clear();
            MySqlDataReader itemsQuery = Connection("SELECT * FROM `user`");
            clUser.Clear();
            while (itemsQuery.Read())
            {
                user newItem = new user();
                newItem.id = Convert.ToInt32(itemsQuery.GetValue(0));
                newItem.surname = Convert.ToString(itemsQuery.GetValue(1));
                newItem.name = Convert.ToString(itemsQuery.GetValue(2));
                newItem.lastname = Convert.ToString(itemsQuery.GetValue(3));
                newItem.login = Convert.ToString(itemsQuery.GetValue(4));
                newItem.pwd = Convert.ToString(itemsQuery.GetValue(5));
                newItem.role = Convert.ToInt32(itemsQuery.GetValue(6));
                clUser.Add(newItem);
            }
            itemsQuery.Close();

            clProduct.Clear();
            itemsQuery = Connection("SELECT * FROM `product`");
            clProduct.Clear();
            while (itemsQuery.Read())
            {
                product newItem = new product();
                newItem.id = Convert.ToInt32(itemsQuery.GetValue(0));
                newItem.article = Convert.ToString(itemsQuery.GetValue(1));
                newItem.name = Convert.ToString(itemsQuery.GetValue(2));
                newItem.measure_unit = Convert.ToString(itemsQuery.GetValue(3));
                newItem.price = Convert.ToInt32(itemsQuery.GetValue(4));
                newItem.max_discount = Convert.ToInt32(itemsQuery.GetValue(5));
                newItem.manufacturer = Convert.ToString(itemsQuery.GetValue(6));
                newItem.supplier = Convert.ToString(itemsQuery.GetValue(7));
                newItem.category_id = Convert.ToInt32(itemsQuery.GetValue(8));
                newItem.discount = Convert.ToInt32(itemsQuery.GetValue(9));
                newItem.amount_on_warehouse = Convert.ToInt32(itemsQuery.GetValue(10));
                newItem.description = Convert.ToString(itemsQuery.GetValue(11));
                newItem.img_src = Convert.ToString(itemsQuery.GetValue(12));
                clProduct.Add(newItem);
            }
            itemsQuery.Close();

            clCategory.Clear();
            itemsQuery = Connection("SELECT * FROM `category`");
            clCategory.Clear();
            while (itemsQuery.Read())
            {
                category newItem = new category();
                newItem.id = Convert.ToInt32(itemsQuery.GetValue(0));
                newItem.name = Convert.ToString(itemsQuery.GetValue(1));
                clCategory.Add(newItem);
            }
            itemsQuery.Close();
        }
    }
}
