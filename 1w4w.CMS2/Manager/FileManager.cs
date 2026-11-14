using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class FileManager
    {
        public static List<UploadedFileModel> GetFileList()
        {
            var list = new List<UploadedFileModel>();
            string query = "SELECT * FROM uploadedfile ORDER BY id ASC";
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = query;

                MySqlDataReader myReader;
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new UploadedFileModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.name = myReader["name"].ToString();

                            list.Add(model);
                        }
                    }
                    return list;
                }
                catch
                {
                    throw;
                }
            }
        }

        public static List<UploadedImageModel> GetImageList()
        {
            var list = new List<UploadedImageModel>();
            string query = "SELECT * FROM uploadedimage ORDER BY id ASC";
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = query;

                MySqlDataReader myReader;
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new UploadedImageModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.uploadedimagecategory = myReader["uploadedimagecategory"].ToString();
                            model.name = myReader["name"].ToString();

                            list.Add(model);
                        }
                    }
                    return list;
                }
                catch
                {
                    throw;
                }
            }
        }

        public int CreateUploadedFile(UploadedFileModel model)
        {
            int newhighestid = (GetHighestFileId() + 1);
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();

                var sql = "";
                sql += "INSERT INTO uploadedfile(id, websiteid, name) ";
                sql += " VALUES(@id, @websiteid, @name);";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@name", model.name.Replace("'", "''"));
                var createdid = cmd.ExecuteNonQuery();
                
                return newhighestid;
            }
        }

        public int CreateUploadedImage(UploadedImageModel model)
        {
            int newhighestid = (GetHighestImageId() + 1);
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();

                var sql = "";
                sql += "INSERT INTO uploadedimage(id, websiteid, uploadedimagecategory, name) ";
                sql += " VALUES(@id, @websiteid, @uploadedimagecategory, @name);";
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@uploadedimagecategory", "uncategorized");
                cmd.Parameters.AddWithValue("@name", model.name.Replace("'", "''"));
                var createdid = cmd.ExecuteNonQuery();

                return newhighestid;
            }
        }

        public void UpdateUploadedImage(PagePartModel model)
        {
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "UPDATE pagepart SET";
            sql += " imagepath='" + model.imagepath + "',";
            sql += " colors='" + model.colors + "'";
            sql += " WHERE id=@id;";

            comm.CommandText = sql;
            comm.Parameters.AddWithValue("@id", model.id);
            comm.Parameters.AddWithValue("@imagepath", model.imagepath);
            comm.Parameters.AddWithValue("@colors", model.colors);
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


        public int GetHighestFileId()
        {
            var list = new List<UploadedFileModel>();
            MySqlDataReader myReader;
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from uploadedfile";
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new UploadedFileModel();
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

        public int GetHighestImageId()
        {
            var list = new List<UploadedImageModel>();
            MySqlDataReader myReader;
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from uploadedimage";
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new UploadedImageModel();
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

        public string GetFilename1()
        {
            return Path.GetRandomFileName().Replace(".","");
        }
        public string GetFilename2()
        {
            return new Random().Next(1,12).ToString();
        }
        public string GetFilename3()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Muppe");
        }
    }
}