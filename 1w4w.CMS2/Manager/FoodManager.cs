using MySql.Data.MySqlClient;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.Design;

namespace _1w4w.CMS.Manager
{
    public class FoodManager
    {
        public List<Models.FoodModel> GetFoodList(int companyid)
        {
            var list = new List<_1w4w.CMS.Models.FoodModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM food WHERE companyid=" + companyid + " ORDER BY id ASC";
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
                            var model = new FoodModel();
                            model.companyid = Convert.ToInt32(myReader["companyid"]);
                            model.categoryid = Convert.ToInt32(myReader["categoryid"]);
                            model.color = myReader["color"].ToString();
                            model.name = myReader["name"].ToString();
                            model.ingredients = myReader["ingredients"].ToString();
                            model.description = myReader["description"].ToString();
                            model.price = Convert.ToInt32(myReader["price"]);
                            model.offerprice = Convert.ToInt32(myReader["offerprice"]);
                            model.image = myReader["image"].ToString();
                            model.catering = myReader["catering"].ToString();
                            model.hidden = myReader["hidden"].ToString();
                            model.attop = myReader["attop"].ToString();
                            list.Add(model);
                        }
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public void Create(_1w4w.CMS.Models.FoodModel model)
        {
            var query = "INSERT INTO food(companyid, categoryid, color, name, ingredients, description, price, offerprice, image, catering, hidden, attop) VALUES(@restaurantid, @categoryid, @color, @name, @ingredients, @price, @offerprice, @image, @catering, @hidden, @attop)";
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = query;


                var highestProjectId = GetHighestFoodId();
                cmd.Parameters.AddWithValue("@companyid", model.companyid);
                cmd.Parameters.AddWithValue("@categoryid", model.categoryid);
                cmd.Parameters.AddWithValue("@color", model.color);
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.Parameters.AddWithValue("@ingredients", model.ingredients);
                cmd.Parameters.AddWithValue("@description", model.description);
                cmd.Parameters.AddWithValue("@price", model.price);
                cmd.Parameters.AddWithValue("@offerprice", model.offerprice);
                cmd.Parameters.AddWithValue("@image", model.image);
                cmd.Parameters.AddWithValue("@catering", model.catering);
                cmd.Parameters.AddWithValue("@hidden", model.hidden);
                cmd.Parameters.AddWithValue("@attop", model.attop);
                cmd.ExecuteNonQuery();

                //string connString = DatabaseManager.GetConnectionstring();
                //MySqlConnection conn = new MySqlConnection(connString);
                //conn.Open();
                //MySqlCommand comm = conn.CreateCommand();
                //comm.CommandText = "INSERT INTO food(restaurantid, categoryid, color, name, ingredients, description, price, offerprice, image, catering, hidden, attop) VALUES(@restaurantid, @categoryid, @color, @name, @ingredients, @price, @offerprice, @image, @catering, @hidden, @attop)";
                //comm.Parameters.AddWithValue("@restaurantid", model.restaurantid);
                //comm.Parameters.AddWithValue("@categoryid", model.categoryid);
                //comm.Parameters.AddWithValue("@color", model.color);
                //comm.Parameters.AddWithValue("@name", model.name);
                //comm.Parameters.AddWithValue("@ingredients", model.ingredients);
                //comm.Parameters.AddWithValue("@description", model.description);
                //comm.Parameters.AddWithValue("@price", model.price);
                //comm.Parameters.AddWithValue("@offerprice", model.offerprice);
                //comm.Parameters.AddWithValue("@image", model.image);
                //comm.Parameters.AddWithValue("@catering", model.catering);
                //comm.Parameters.AddWithValue("@hidden", model.hidden);
                //comm.Parameters.AddWithValue("@attop", model.attop);
                //comm.ExecuteNonQuery();
                //conn.Close();
            }
            
        }

        public int GetHighestFoodId()
        {
            var list = new List<_1w4w.CMS.Models.FoodModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM food";
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
                            var projectModel = new FoodModel();
                            projectModel.id = Convert.ToInt32(myReader["id"]);
                            //projectModel.title = myReader["title"].ToString();
                            //projectModel.status = myReader["status"].ToString();
                            //projectModel.percentcompleted = Convert.ToInt32(myReader["percentcompleted"]);
                            //projectModel.owner = myReader["owner"].ToString();
                            list.Add(projectModel);
                        }
                    }
                }
                return Convert.ToInt32(myReader["id"]);
            }
            catch
            {
                return 0;
            }
        }
    }
}