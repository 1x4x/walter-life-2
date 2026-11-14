using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class WebsiteManager
    {
        public List<Models.WebsiteModel> GetWebsiteList()
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    //int employeeID = findEmployeeID();
            //    try
            //    {
            //        connection.Open();
            //        SqlCommand command = new SqlCommand("UpdateEmployeeTable", connection);
            //        command.CommandType = CommandType.StoredProcedure;
            //        command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
            //        command.CommandTimeout = 5;

            //        command.ExecuteNonQuery();
            //    }
            //    catch (Exception)
            //    {
            //        /*Handle error*/
            //    }
            //}




            var list = new List<Models.WebsiteModel>();
            string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM website WHERE websiteId=" + id + " ORDER BY id ASC";
            string query = "SELECT * FROM website ORDER BY id ASC";
            var conDatabase = new MySqlConnection(myConnection);
            MySqlCommand cmdDataBase = new MySqlCommand(query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDataBase.ExecuteReader();

                // if we have not even 1 row create 1 dummywebsiterow so we have a website to work with
                //if (myReader.HasRows == false)
                //{
                //    CreateDummyWebsite();
                //}

                // this will always be true since we always create 1 row up in the code if not 1 row exist
                if (myReader.HasRows == true)
                {
                    while (myReader.Read())
                    {
                        var model = new WebsiteModel();
                        model.id = Convert.ToInt32(myReader["id"]);
                        model.name = myReader["name"].ToString();
                        //model.domain = myReader["domain"].ToString();
                        //model.title = myReader["title"].ToString();
                        //model.description = myReader["description"].ToString();
                        //model.keywords = myReader["keywords"].ToString();
                        //model.logoimageurl = myReader["logoimageurl"].ToString();
                        //model.copyright = myReader["copyright"].ToString();
                        //model.phone = myReader["phone"].ToString();
                        //model.email = myReader["email"].ToString();
                        //model.address = myReader["address"].ToString();
                        //model.zipcode = myReader["zipcode"].ToString();
                        //model.city = myReader["city"].ToString();
                        //model.opentimesmontofri = myReader["opentimesmontofri"].ToString();
                        //model.opentimessattosun = myReader["opentimessattosun"].ToString();
                        //model.lunchtime = myReader["lunchtime"].ToString();
                        //model.sociallinkfacebook = myReader["sociallinkfacebook"].ToString();
                        //model.sociallinktwitter = myReader["sociallinktwitter"].ToString();
                        //model.sociallinkinstagram = myReader["sociallinkinstagram"].ToString();
                        //model.sociallinkyoutube = myReader["sociallinkyoutube"].ToString();
                        //model.logo1 = myReader["logo1"].ToString();
                        //model.logo2 = myReader["logo2"].ToString();
                        //model.logo3 = myReader["logo3"].ToString();
                        list.Add(model);
                    }
                }
                return list;
            }
            catch
            {
                //return null;
                return list;
            }
        }

    }
}