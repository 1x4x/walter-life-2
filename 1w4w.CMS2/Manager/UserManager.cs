using MySql.Data.MySqlClient;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class UserManager
    {
        public static List<Models.UserModel> GetUserList()
        {
            var list = new List<_1w4w.CMS.Models.UserModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM user WHERE id=" + id + ";";
            string query = "SELECT * FROM user;";
            //var conDatabase = new MySqlConnection(myConnection);
            //MySqlCommand cmdDataBase = new MySqlCommand(query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = query;


                    //conDatabase.Open();
                    //myReader = cmdDataBase.ExecuteReader();
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new UserModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.firstname = myReader["firstname"].ToString();
                            model.lastname = myReader["lastname"].ToString();
                            model.username = myReader["username"].ToString();
                            model.password = myReader["password"].ToString();
                            model.companyid = Convert.ToInt32(myReader["companyid"]);
                            model.email = myReader["email"].ToString();
                            model.phone = myReader["phone"].ToString();
                            model.isblocked = myReader["isblocked"].ToString();
                            model.magiclink = myReader["magiclink"].ToString();
                            model.accesslevel = myReader["accesslevel"].ToString();
                            model.status = myReader["status"].ToString();
                            model.imagepath = myReader["imagepath"].ToString();
                            list.Add(model);
                        }
                    }
                    return list;
                }



            }
            catch
            {
                throw;
                //return null;
            }
        }

        public static Models.UserModel Login(string username, string password)
        {
            var list = GetUserList();
            UserModel user = list.SingleOrDefault(x => x.username == username && x.password == password);
            if (user != null)
            {
                HttpContext.Current.Session["User"] = user;
                return user;
            }
            return null;
        }
        
        public Models.UserModel Login(string magiclink)
        {
            var list = UserManager.GetUserList();
            if (list == null)
            {
                // TODO: do we want to autocreate a user?
                return null;
            }
            else
            {
                var user = list.SingleOrDefault(x => x.magiclink == magiclink);
                if (user != null)
                {
                    HttpContext.Current.Session["User"] = user;
                    return user;
                }
                return null;
            }
        }


        public void Create(_1w4w.CMS.Models.UserModel model)
        {
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var sql = "INSERT INTO user(firstname, lastname, username, password, restaurantid, email, phone, isblocked, magiclink, accesslevel, status) ";
                sql += "VALUES(@firstname, @lastname, @username, @password, @companyid, @email, @phone, @isblocked, @magiclink, @accesslevel, @status);";
                cmd.Parameters.AddWithValue("@firstname", model.firstname);
                cmd.Parameters.AddWithValue("@lastname", model.lastname);
                cmd.Parameters.AddWithValue("@username", model.username);
                cmd.Parameters.AddWithValue("@password", model.password);
                cmd.Parameters.AddWithValue("@companyid", model.companyid);
                cmd.Parameters.AddWithValue("@email", model.email);
                cmd.Parameters.AddWithValue("@phone", model.phone);
                cmd.Parameters.AddWithValue("@isblocked", model.isblocked);
                cmd.Parameters.AddWithValue("@magiclink", model.magiclink);
                cmd.Parameters.AddWithValue("@accesslevel", model.accesslevel);
                cmd.Parameters.AddWithValue("@status", model.status);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}