using MySql.Data.MySqlClient;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class ProductManager
    {
        public List<Models.ProductModel> GetProductListByProductCategoryId(List<Models.ProductModel> list, int productcategoryid)
        {
            return list.Where(x => x.productcategoryid == productcategoryid).ToList();
        }

        public List<Models.ProductModel> GetProductList()
        {
            var list = new List<_1w4w.CMS.Models.ProductModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM website WHERE websiteId=" + id + " ORDER BY id ASC";
            string query = "SELECT * FROM product ORDER BY id ASC";
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
                            var model = new ProductModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.productcategoryid = Convert.ToInt32(myReader["productcategoryid"]);
                            model.name = myReader["name"].ToString();
                            model.price = Convert.ToInt32(myReader["price"]);
                            model.description = myReader["description"].ToString();
                            model.extrainfo = myReader["extrainfo"].ToString();
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

        public Models.ProductModel GetProductById(int id, List<Models.ProductModel> list)
        {
            var model = list.SingleOrDefault(x => x.id == id);
            return model;
        }
        //public Models.ProductModel GetWebsiteByDomain(string domain, List<Models.ProductModel> list)
        //{
        //    var model = list.SingleOrDefault(x => x.domain == domain);
        //    return model;
        //}
        public void Create(_1w4w.CMS.Models.ProductModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "INSERT INTO product(id, websiteid, productcategoryid, name, price, description, extrainfo ";
            sql += ") ";

            sql += "VALUES(@id, @websiteid, @productcategoryid, @name, @price, @description, @extrainfo ";
            sql += ")";
            comm.CommandText = sql;
            comm.Parameters.AddWithValue("@id", newhighestid);
            comm.Parameters.AddWithValue("@websiteid", model.websiteid);
            comm.Parameters.AddWithValue("@productcategoryid", model.productcategoryid);
            comm.Parameters.AddWithValue("@name", model.name);
            comm.Parameters.AddWithValue("@price", model.price);
            comm.Parameters.AddWithValue("@description", model.description);
            comm.Parameters.AddWithValue("@extrainfo", model.extrainfo);
            comm.ExecuteNonQuery();
            conn.Close();


            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@productcategoryid", model.productcategoryid);
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.Parameters.AddWithValue("@price", model.price);
                cmd.Parameters.AddWithValue("@description", model.description);
                cmd.Parameters.AddWithValue("@extrainfo", model.extrainfo);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(_1w4w.CMS.Models.ProductModel model)
        {
            string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "UPDATE product SET";
            //sql += " id='" + Convert.ToInt32(model.id) + "',";
            sql += " websiteid='" + Convert.ToInt32(model.websiteid) + "',";
            sql += " productcategoryid='" + Convert.ToInt32(model.productcategoryid) + "',";
            sql += " name='" + model.name + "',";
            sql += " price='" + Convert.ToInt32(model.price) + "',";
            sql += " description='" + model.description + "',";
            sql += " extrainfo='" + model.extrainfo + "'";
            sql += " WHERE id=@id;";

            //comm.CommandText = sql;
            //comm.Parameters.AddWithValue("@id", model.id);
            //comm.Parameters.AddWithValue("@websiteid", model.websiteid);
            //comm.Parameters.AddWithValue("@productcategoryid", model.productcategoryid);
            //comm.Parameters.AddWithValue("@name", model.name);
            //comm.Parameters.AddWithValue("@price", model.price);
            //comm.Parameters.AddWithValue("@description", model.description);
            //comm.Parameters.AddWithValue("@extrainfo", model.extrainfo);
            ////comm.Parameters.AddWithValue("@id", model.id);
            //comm.ExecuteNonQuery();
            //conn.Close();


            

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", model.id);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@productcategoryid", model.productcategoryid);
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.Parameters.AddWithValue("@price", model.price);
                cmd.Parameters.AddWithValue("@description", model.description);
                cmd.Parameters.AddWithValue("@extrainfo", model.extrainfo);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            var sql = "DELETE FROM product WHERE id=@id;";
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "DELETE FROM product WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", id);
            //comm.ExecuteNonQuery();
            //conn.Close();


            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetHighestId()
        {
            var list = new List<_1w4w.CMS.Models.ProductModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM product";
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
                            var model = new ProductModel();
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