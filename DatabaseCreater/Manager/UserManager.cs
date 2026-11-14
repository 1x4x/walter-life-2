using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCreater.Manager
{
    internal static class UserManager
    {
        public static List<Models.UserModel> GetUserList()
        {
            var list = new List<Models.UserModel>();
            string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM user ORDER BY id ASC";
            var conDatabase = new MySqlConnection(myConnection);
            MySqlCommand cmdDataBase = new MySqlCommand(query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDataBase.ExecuteReader();
                if (myReader.HasRows == true)
                {
                    while (myReader.Read())
                    {
                        var model = new Models.UserModel();
                        model.id = Convert.ToInt32(myReader["id"]);
                        model.type = myReader["type"].ToString();
                        model.username = myReader["username"].ToString();
                        model.password = myReader["password"].ToString();
                        list.Add(model);
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
