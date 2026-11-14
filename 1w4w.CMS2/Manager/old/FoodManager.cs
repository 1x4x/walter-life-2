using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class FoodManager
    {
        public List<Models.FoodModel> GetFoodList(int restaurantId)
        {
            var list = new List<Models.FoodModel>();
            string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM food WHERE restaurantId=" + restaurantId + " ORDER BY id ASC";
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
                        var model = new FoodModel();
                        model.restaurantid = Convert.ToInt32(myReader["restaurantid"]);
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
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}