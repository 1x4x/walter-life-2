using MySql.Data.MySqlClient;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class ProductCategoryManager
    {
        public List<Models.ProductCategoryModel> GetProductCategoryList()
        {
            var list = new List<_1w4w.CMS.Models.ProductCategoryModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM website WHERE websiteId=" + id + " ORDER BY id ASC";
            string query = "SELECT * FROM productcategory ORDER BY id ASC";
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
                            var model = new ProductCategoryModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.name = myReader["name"].ToString();
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
        public Models.ProductCategoryModel GetProductCategoryById(int id, List<Models.ProductCategoryModel> list)
        {
            var model = list.SingleOrDefault(x => x.id == id);
            return model;
        }
        //public Models.ProductModel GetWebsiteByDomain(string domain, List<Models.ProductModel> list)
        //{
        //    var model = list.SingleOrDefault(x => x.domain == domain);
        //    return model;
        //}
        public void Create(_1w4w.CMS.Models.ProductCategoryModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "INSERT INTO productcategory(id, websiteid, name";
            sql += ") ";

            sql += " VALUES(@id, @websiteid, @name";
            sql += ")";
            //comm.CommandText = sql;
            //comm.Parameters.AddWithValue("@id", newhighestid);
            //comm.Parameters.AddWithValue("@websiteid", model.websiteid);
            //comm.Parameters.AddWithValue("@name", model.name);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(_1w4w.CMS.Models.ProductCategoryModel model)
        {
            string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "UPDATE productcategory SET";
            //sql += " id='" + Convert.ToInt32(model.id) + "',";
            sql += " websiteid='" + Convert.ToInt32(model.websiteid) + "',";
            sql += " name='" + model.name + "'";
            sql += " WHERE id=@id;";

            //comm.CommandText = sql;
            //comm.Parameters.AddWithValue("@id", model.id);
            //comm.Parameters.AddWithValue("@websiteid", model.websiteid);
            //comm.Parameters.AddWithValue("@name", model.name);
            //comm.ExecuteNonQuery();
            //conn.Close();


            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;


                cmd.Parameters.AddWithValue("@id", model.id);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.ExecuteNonQuery();

            }
        }
        public void Delete(int id)
        {
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "DELETE FROM productcategory WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", id);
            //comm.ExecuteNonQuery();
            //conn.Close();


            var sql = "DELETE FROM productcategory WHERE id=@id;";
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetHighestId()
        {
            var list = new List<_1w4w.CMS.Models.ProductCategoryModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM productcategory";
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
                            var model = new ProductCategoryModel();
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