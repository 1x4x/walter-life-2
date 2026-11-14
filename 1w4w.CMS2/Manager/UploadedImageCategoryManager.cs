using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class UploadedImageCategoryManager
    {
        public List<Models.UploadedImageCategoryModel> GetUploadedImageCategoryList()
        {
            var list = new List<_1w4w.CMS.Models.UploadedImageCategoryModel>();
            string query = "SELECT * FROM uploadedimagecategory;";
            MySqlDataReader myReader;
            try
            {
                using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new UploadedImageCategoryModel();
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
                throw;
                //return null;
            }
        }



        public int Create(_1w4w.CMS.Models.UploadedImageCategoryModel model)
        {
            int newhighestid = (GetHighestId() + 1);

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                //cmd.CommandText = "select * from page";




                var sql = "";
                sql += "INSERT INTO uploadedimagecategory(id, websiteid, name";
                sql += ") ";

                sql += " VALUES(@id, @websiteid, @name";
                sql += ")";
                cmd.CommandText = sql;

                var id = model.id.ToString() ?? "";
                var websiteid = model.websiteid.ToString() ?? "";
                var name = model.name.ToString() ?? "";

                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@name", name.Replace("'", "''"));

                var createdid = cmd.ExecuteNonQuery();
                return createdid;
            }
        }

        public int Update(_1w4w.CMS.Models.UploadedImageCategoryModel model)
        {
            var name = model.name ?? "";


            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from uploadedimagecategory";




                var sql = "";
                sql += "UPDATE uploadedimagecategory SET";
                sql += " websiteid='" + Convert.ToInt32(model.websiteid) + "',";
                sql += " name='" + name.Replace("'", "''") + "',";
                sql += " WHERE id=@id;";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", model.id);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@name", model.name);

                var updatedid = cmd.ExecuteNonQuery();

                return model.id;
            }
        }

        public void Delete(int id)
        {
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();

                cmd.CommandText = "DELETE FROM uploadedimagecategory WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetHighestId()
        {
            var list = new List<_1w4w.CMS.Models.UploadedImageCategoryModel>();
            MySqlDataReader myReader;

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from uploadedimagecategory";
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new UploadedImageCategoryModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            list.Add(model);
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
}