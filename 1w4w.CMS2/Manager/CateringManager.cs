using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class CateringManager
    {
        public static List<Models.CateringModel> GetCateringList()
        {
            var list = new List<_1w4w.CMS.Models.CateringModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM catering ORDER BY id ASC";
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
                            var model = new Models.CateringModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.name = myReader["name"].ToString();
                            model.artnr = myReader["artnr"].ToString();
                            model.imageurl = myReader["imageurl"].ToString();
                            model.barcodeimageurl = myReader["barcodeimageurl"].ToString();
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

        public Models.CateringModel GetPageById(int id, List<Models.CateringModel> list)
        {
            var model = list.SingleOrDefault(x => x.id == id);
            return model;
        }

        public void Create(Models.CateringModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "INSERT INTO catering(id, websiteid, name, artnr, imageurl, barcodeimageurl";
            sql += ") ";

            sql += " VALUES(@id, @websiteid, @name, @artnr, @imageurl, @barcodeimageurl";
            sql += ")";
            //comm.CommandText = sql;

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.Parameters.AddWithValue("@artnr", model.artnr);
                cmd.Parameters.AddWithValue("@imageurl", model.imageurl);
                cmd.Parameters.AddWithValue("@barcodeimageurl", model.barcodeimageurl);
                cmd.ExecuteNonQuery();
                //conn.Close();
            }
        }
        public void Update(Models.CateringModel model)
        {
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "UPDATE catering SET";
            sql += " websiteid='" + Convert.ToInt32(model.websiteid) + "',";
            sql += " name='" + model.name + "',";
            sql += " artnr='" + model.artnr + "'";
            sql += " imageurl='" + model.imageurl + "'";
            sql += " barcodeimageurl='" + model.barcodeimageurl + "'";
            sql += " WHERE id=@id;";

            comm.CommandText = sql;
            comm.Parameters.AddWithValue("@id", model.id);
            comm.Parameters.AddWithValue("@websiteid", model.websiteid);
            comm.Parameters.AddWithValue("@name", model.name);
            comm.Parameters.AddWithValue("@artnr", model.artnr);
            comm.Parameters.AddWithValue("@imageurl", model.imageurl);
            comm.Parameters.AddWithValue("@barcodeimageurl", model.barcodeimageurl);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int id)
        {
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                //cmd.CommandText = "select * from page";
                cmd.CommandText = "DELETE FROM catering WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            //conn.Close();
        }

        public int GetHighestId()
        {
            var list = new List<Models.CateringModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM catering";
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
                            var model = new Models.CateringModel();
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
    }
}