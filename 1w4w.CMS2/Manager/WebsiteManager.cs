using MySql.Data.MySqlClient;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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




            var list = new List<_1w4w.CMS.Models.WebsiteModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM website WHERE websiteId=" + id + " ORDER BY id ASC";
            string query = "SELECT * FROM website ORDER BY id ASC";
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

                    // if we have not even 1 row create 1 dummywebsiterow so we have a website to work with
                    if (myReader.HasRows == false)
                    {
                        CreateDummyWebsite();
                    }

                    // this will always be true since we always create 1 row up in the code if not 1 row exist
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new WebsiteModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.name = myReader["name"].ToString();
                            model.domain = myReader["domain"].ToString();
                            model.title = myReader["title"].ToString();
                            model.description = myReader["description"].ToString();
                            model.keywords = myReader["keywords"].ToString();
                            model.logoimageurl = myReader["logoimageurl"].ToString();
                            model.copyright = myReader["copyright"].ToString();
                            model.phone = myReader["phone"].ToString();
                            model.email = myReader["email"].ToString();
                            model.address = myReader["address"].ToString();
                            model.zipcode = myReader["zipcode"].ToString();
                            model.city = myReader["city"].ToString();
                            model.opentimesmontofri = myReader["opentimesmontofri"].ToString();
                            model.opentimessattosun = myReader["opentimessattosun"].ToString();
                            model.lunchtime = myReader["lunchtime"].ToString();
                            model.sociallinkfacebook = myReader["sociallinkfacebook"].ToString();
                            model.sociallinktwitter = myReader["sociallinktwitter"].ToString();
                            model.sociallinkinstagram = myReader["sociallinkinstagram"].ToString();
                            model.sociallinkyoutube = myReader["sociallinkyoutube"].ToString();
                            model.logo1 = myReader["logo1"].ToString();
                            model.logo2 = myReader["logo2"].ToString();
                            model.logo3 = myReader["logo3"].ToString();
                            list.Add(model);
                        }
                    }
                    return list;
                }

                
            }
            catch
            {
                //return null;
                return list;
            }
        }
        public Models.WebsiteModel GetWebsiteById(int id)
        {
            List<Models.WebsiteModel> list = GetWebsiteList();
            var model = list.SingleOrDefault(x => x.id == id);
            return model;
        }
        public Models.WebsiteModel GetWebsiteByDomain(string domain)
        {
            List<Models.WebsiteModel> list = GetWebsiteList();
            var model = list.SingleOrDefault(x => x.domain == domain);
            return model;
        }
        public void CreateDummyWebsite()
        {
            var model = new Models.WebsiteModel
            {
                id = 1,
                opentimesmontofri = "1",
                city = "1",
                name = "1",
                lunchtime = "1",
                logoimageurl = "1",
                logo3 = "1",
                logo2 = "1",
                address = "1",
                opentimessattosun = "1",
                logo1 = "1",
                copyright = "1",
                description = "1",
                domain = "energikällan.net",
                email = "1",
                keywords = "1",
                phone = "1",
                sociallinkfacebook = "1",
                sociallinkinstagram = "1",
                sociallinktwitter = "1",
                sociallinkyoutube = "1",
                title = "1",
                zipcode = "1"
            };

            Create(model);
        }

        public void Create(_1w4w.CMS.Models.WebsiteModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            //var sql = "";
            //sql += "INSERT INTO website(id, name, domain, title, description, keywords, logoimageurl, copyright, phone, email, ";
            //sql += "address, zipcode, city, opentimesmontofri, opentimessattosun, lunchtime, sociallinkfacebook, sociallinktwitter, sociallinkinstagram, sociallinkyoutube, logo1, logo2, logo3) ";
            
            //sql += "VALUES(@id, @name, @domain, @title, @description, @keywords, @logoimageurl, @copyright, @phone, @email, ";
            //sql += "@address, @zipcode, @city, @opentimesmontofri, @opentimessattosun, @lunchtime, @sociallinkfacebook, @sociallinktwitter, @sociallinkinstagram, @sociallinkyoutube, @logo1, @logo2, @logo3)";
            //comm.CommandText = sql;
            //comm.Parameters.AddWithValue("@id", newhighestid);
            //comm.Parameters.AddWithValue("@name", model.name);
            //comm.Parameters.AddWithValue("@title", model.title);
            //comm.Parameters.AddWithValue("@domain", model.domain);
            //comm.Parameters.AddWithValue("@description", model.description);
            //comm.Parameters.AddWithValue("@keywords", model.keywords);
            //comm.Parameters.AddWithValue("@logoimageurl", model.logoimageurl);
            //comm.Parameters.AddWithValue("@copyright", model.copyright);
            //comm.Parameters.AddWithValue("@phone", model.phone);
            //comm.Parameters.AddWithValue("@email", model.email);
            //comm.Parameters.AddWithValue("@address", model.address);
            //comm.Parameters.AddWithValue("@zipcode", model.zipcode);
            //comm.Parameters.AddWithValue("@city", model.city);
            //comm.Parameters.AddWithValue("@opentimesmontofri", model.opentimesmontofri);
            //comm.Parameters.AddWithValue("@opentimessattosun", model.opentimessattosun);
            //comm.Parameters.AddWithValue("@lunchtime", model.lunchtime);
            //comm.Parameters.AddWithValue("@sociallinkfacebook", model.sociallinkfacebook);
            //comm.Parameters.AddWithValue("@sociallinktwitter", model.sociallinktwitter);
            //comm.Parameters.AddWithValue("@sociallinkinstagram", model.sociallinkinstagram);
            //comm.Parameters.AddWithValue("@sociallinkyoutube", model.sociallinkyoutube);
            //comm.Parameters.AddWithValue("@logo1", model.logo1);
            //comm.Parameters.AddWithValue("@logo2", model.logo2);
            //comm.Parameters.AddWithValue("@logo3", model.logo3);
            //comm.ExecuteNonQuery();
            conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();

                var sql = "";
                sql += "INSERT INTO website(id, name, domain, title, description, keywords, logoimageurl, copyright, phone, email, ";
                sql += "address, zipcode, city, opentimesmontofri, opentimessattosun, lunchtime, sociallinkfacebook, sociallinktwitter, sociallinkinstagram, sociallinkyoutube, logo1, logo2, logo3) ";

                sql += "VALUES(@id, @name, @domain, @title, @description, @keywords, @logoimageurl, @copyright, @phone, @email, ";
                sql += "@address, @zipcode, @city, @opentimesmontofri, @opentimessattosun, @lunchtime, @sociallinkfacebook, @sociallinktwitter, @sociallinkinstagram, @sociallinkyoutube, @logo1, @logo2, @logo3)";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.Parameters.AddWithValue("@title", model.title);
                cmd.Parameters.AddWithValue("@domain", model.domain);
                cmd.Parameters.AddWithValue("@description", model.description);
                cmd.Parameters.AddWithValue("@keywords", model.keywords);
                cmd.Parameters.AddWithValue("@logoimageurl", model.logoimageurl);
                cmd.Parameters.AddWithValue("@copyright", model.copyright);
                cmd.Parameters.AddWithValue("@phone", model.phone);
                cmd.Parameters.AddWithValue("@email", model.email);
                cmd.Parameters.AddWithValue("@address", model.address);
                cmd.Parameters.AddWithValue("@zipcode", model.zipcode);
                cmd.Parameters.AddWithValue("@city", model.city);
                cmd.Parameters.AddWithValue("@opentimesmontofri", model.opentimesmontofri);
                cmd.Parameters.AddWithValue("@opentimessattosun", model.opentimessattosun);
                cmd.Parameters.AddWithValue("@lunchtime", model.lunchtime);
                cmd.Parameters.AddWithValue("@sociallinkfacebook", model.sociallinkfacebook);
                cmd.Parameters.AddWithValue("@sociallinktwitter", model.sociallinktwitter);
                cmd.Parameters.AddWithValue("@sociallinkinstagram", model.sociallinkinstagram);
                cmd.Parameters.AddWithValue("@sociallinkyoutube", model.sociallinkyoutube);
                cmd.Parameters.AddWithValue("@logo1", model.logo1);
                cmd.Parameters.AddWithValue("@logo2", model.logo2);
                cmd.Parameters.AddWithValue("@logo3", model.logo3);
                comm.ExecuteNonQuery();
            }
        }

        public void Update(_1w4w.CMS.Models.WebsiteModel model)
        {
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                

                var sql = "";
                sql += "UPDATE website SET";
                sql += " name='" + model.name + "',";
                sql += " domain='" + model.domain + "',";
                sql += " title='" + model.title + "',";
                sql += " description='" + model.description + "',";
                sql += " keywords='" + model.keywords + "',";
                sql += " logoimageurl='" + model.logoimageurl + "',";
                sql += " copyright='" + model.copyright + "',";
                sql += " phone='" + model.phone + "',";
                sql += " email='" + model.email + "',";
                sql += " address='" + model.address + "',";
                sql += " zipcode='" + model.zipcode + "',";
                sql += " city='" + model.city + "',";
                sql += " opentimesmontofri='" + model.opentimesmontofri + "',";
                sql += " opentimessattosun='" + model.opentimessattosun + "',";
                sql += " lunchtime='" + model.lunchtime + "',";
                sql += " sociallinkfacebook='" + model.sociallinkfacebook + "',";
                sql += " sociallinktwitter='" + model.sociallinktwitter + "',";
                sql += " sociallinkinstagram='" + model.sociallinkinstagram + "',";
                sql += " sociallinkyoutube='" + model.sociallinkyoutube + "',";
                sql += " logo1='" + model.logo1 + "',";
                sql += " logo2='" + model.logo2 + "',";
                sql += " logo3='" + model.logo3 + "'";
                sql += " WHERE id=@id;";
                cmd.CommandText = sql;
                //comm.CommandText = sql;
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.Parameters.AddWithValue("@domain", model.domain);
                cmd.Parameters.AddWithValue("@title", model.title);
                cmd.Parameters.AddWithValue("@description", model.description);
                cmd.Parameters.AddWithValue("@keywords", model.keywords);
                cmd.Parameters.AddWithValue("@logoimageurl", model.logoimageurl);
                cmd.Parameters.AddWithValue("@copyright", model.copyright);
                cmd.Parameters.AddWithValue("@phone", model.phone);
                cmd.Parameters.AddWithValue("@email", model.email);
                cmd.Parameters.AddWithValue("@address", model.address);
                cmd.Parameters.AddWithValue("@zipcode", model.zipcode);
                cmd.Parameters.AddWithValue("@city", model.city);
                cmd.Parameters.AddWithValue("@opentimesmontofri", model.opentimesmontofri);
                cmd.Parameters.AddWithValue("@opentimessattosun", model.opentimessattosun);
                cmd.Parameters.AddWithValue("@lunchtime", model.lunchtime);
                cmd.Parameters.AddWithValue("@sociallinkfacebook", model.sociallinkfacebook);
                cmd.Parameters.AddWithValue("@sociallinktwitter", model.sociallinktwitter);
                cmd.Parameters.AddWithValue("@sociallinkinstagram", model.sociallinkinstagram);
                cmd.Parameters.AddWithValue("@sociallinkyoutube", model.sociallinkyoutube);
                cmd.Parameters.AddWithValue("@logo1", model.logo1);
                cmd.Parameters.AddWithValue("@logo2", model.logo2);
                cmd.Parameters.AddWithValue("@logo3", model.logo3);
                cmd.Parameters.AddWithValue("@id", model.id);
                cmd.ExecuteNonQuery();
                
            }
        }
        public void Delete(int id)
        {
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "DELETE FROM website WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", id);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var query = "DELETE FROM website WHERE id=@id;";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetHighestId()
        {
            var list = new List<_1w4w.CMS.Models.WebsiteModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM website";
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
                            var model = new WebsiteModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            list.Add(model);
                        }
                    }
                    return Convert.ToInt32(myReader["id"]);
                }
            }
            catch
            {
                return 0;
            }
        }

        public string GetTelLinkFromPhonenumber(string phonenumber)
        {
            //   input:     +46 (8) 712-00 33
            //   output:    tel:+46-87120033
            if (phonenumber == null) { return ""; }
            var tellink = "tel:" + phonenumber
                .Replace(" ","")
                .Replace("(","")
                .Replace(")", "")
                .Replace("-", "");
            return tellink;
        }
    }
}