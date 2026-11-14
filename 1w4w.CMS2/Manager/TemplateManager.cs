using MySql.Data.MySqlClient;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public static class TemplateManager
    {
        public static _1w4w.CMS.Models.TemplateModel GetTemplate(int templateid)
        {
            //_1w4w.CMS.Models.TemplateModel template = (_1w4w.CMS.Models.TemplateModel)new object();
            _1w4w.CMS.Models.TemplateModel template = new _1w4w.CMS.Models.TemplateModel();
            //var template1 = "";
            //template1 = "catefood";
            //template1 = "medicare";

            //template = new _1w4w.CMS.Models.TemplateModel();
            template.id = 1;
            template.name = "catefood";  
            //template.name = "hakim";
            //template.name = "medicare";
            //template.name = "varsity";
            //template.baseurl = "/Views/Shared/catefood";
            template.baseurl = "/content/template/" + template.name;
            // /content/template/catefood
            //template.baseurl = "/Views/Shared/" + template.name;


            if (templateid == 1)
            {
                //template = new _1w4w.CMS.Models.TemplateModel();
                template.id = 1;
                template.name = "catefood";
                template.baseurl = "/content/template/" + template.name;
            }
            
            if (templateid == 2)
            {
                //template = new _1w4w.CMS.Models.TemplateModel();
                template.id = 2;
                template.name = "medicare";
                template.baseurl = "/content/template/" + template.name;
            }

            if (templateid == 3)
            {
                template = new _1w4w.CMS.Models.TemplateModel();
                template.id = 3;
                template.name = "energy";
                template.baseurl = "/content/template/" + template.name;
            }

            return template;
        }

        public static List<Models.TemplateModel> GetTemplateList()
        {
            var list = new List<_1w4w.CMS.Models.TemplateModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
//            string query = "SELECT * FROM template WHERE restaurantId=" + restaurantId + " ORDER BY id ASC";
            string query = "SELECT * FROM template ORDER BY id ASC";
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
                            var model = new TemplateModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.name = myReader["name"].ToString();
                            model.baseurl = myReader["baseurl"].ToString();
                            list.Add(model);
                        }
                    }
                    return list;
                }


            }
            catch
            {
                return null;
            }
        }

        //public void Create(_1w4w.CMS.Models.FoodModel model)
        //{
        //    var highestProjectId = GetHighestProjectId();
        //    string connString = DatabaseManager.GetConnectionstring();
        //    MySqlConnection conn = new MySqlConnection(connString);
        //    conn.Open();
        //    MySqlCommand comm = conn.CreateCommand();
        //    comm.CommandText = "INSERT INTO food(restaurantid, categoryid, color, name, ingredients, description, price, offerprice, image, catering, hidden, attop) VALUES(@restaurantid, @categoryid, @color, @name, @ingredients, @price, @offerprice, @image, @catering, @hidden, @attop)";
        //    comm.Parameters.AddWithValue("@restaurantid", model.restaurantid);
        //    comm.Parameters.AddWithValue("@categoryid", model.categoryid);
        //    comm.Parameters.AddWithValue("@color", model.color);
        //    comm.Parameters.AddWithValue("@name", model.name);
        //    comm.Parameters.AddWithValue("@ingredients", model.ingredients);
        //    comm.Parameters.AddWithValue("@description", model.description);
        //    comm.Parameters.AddWithValue("@price", model.price);
        //    comm.Parameters.AddWithValue("@offerprice", model.offerprice);
        //    comm.Parameters.AddWithValue("@image", model.image);
        //    comm.Parameters.AddWithValue("@catering", model.catering);
        //    comm.Parameters.AddWithValue("@hidden", model.hidden);
        //    comm.Parameters.AddWithValue("@attop", model.attop);
        //    comm.ExecuteNonQuery();
        //    conn.Close();
        //}

        //public int GetHighestProjectId()
        //{
        //    var list = new List<_1w4w.CMS.Models.FoodModel>();
        //    string myConnection = DatabaseManager.GetConnectionstring();
        //    string query = "SELECT * FROM food";
        //    var conDatabase = new MySqlConnection(myConnection);
        //    MySqlCommand cmdDataBase = new MySqlCommand(query, conDatabase);
        //    MySqlDataReader myReader;
        //    try
        //    {
        //        conDatabase.Open();
        //        myReader = cmdDataBase.ExecuteReader();
        //        if (myReader.HasRows == true)
        //        {
        //            while (myReader.Read())
        //            {
        //                var projectModel = new FoodModel();
        //                projectModel.id = Convert.ToInt32(myReader["id"]);
        //                //projectModel.title = myReader["title"].ToString();
        //                //projectModel.status = myReader["status"].ToString();
        //                //projectModel.percentcompleted = Convert.ToInt32(myReader["percentcompleted"]);
        //                //projectModel.owner = myReader["owner"].ToString();
        //                list.Add(projectModel);
        //            }
        //        }
        //        return Convert.ToInt32(myReader["id"]);
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
    }
}