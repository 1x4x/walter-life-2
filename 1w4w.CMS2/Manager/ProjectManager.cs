using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Diagnostics.Contracts;
using _1w4w.CMS.Models;
using System.Configuration;

namespace _1w4w.CMS.Manager
{
    public class ProjectManager
    {
        // in Visual Studio to add connection to MySql write "Install-Package MySql.Data" from "Package Manager Console"
        // https://www.codeproject.com/Articles/822392/Connecting-to-MySQL-from-ASP-NET-MVC-using-Visual
        /*
        public MySqlDataReader GetProjectsByStatus(string status)
        {
            // https://phpmyadmin690.loopia.se/
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "mysql690.loopia.se";
            conn_string.UserID = "e003574a@g361575";
            conn_string.Password = "gladastarnograven1!";
            conn_string.Database = "goblinbot_se";
            using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select * from project";
                conn.Open();
                cmd.ExecuteNonQuery();
                var mySqlDataReader = cmd.ExecuteReader();
                return mySqlDataReader;
            }
            return null;

            //using (SqlConnection _con = new SqlConnection(connectionString))
            //{
            //    string queryStatement = "SELECT * FROM dbo.Project WHERE status = ' + status + ' ORDER BY ProjectId DESC";

            //    using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
            //    {
            //        DataTable customerTable = new DataTable("Top5Customers");
            //        SqlDataAdapter _dap = new SqlDataAdapter(_cmd);
            //        _con.Open();
            //        _dap.Fill(customerTable);
            //        _con.Close();

            //    }
            //}

        }
        */
        //public List<_1w4w.CMS.Models.ProjectModel> GetProjectsByStatus2(string status)
        public List<_1w4w.CMS.Models.ProjectModel> GetUnfinishedProjects()
        {
            var list = new List<_1w4w.CMS.Models.ProjectModel>();
            //List<int> values = new List<int>();

            //string sql = "SELECT Values_To_Add FROM table";
            //command.CommandText = sql;
            //MySqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    values.Add(reader["Values_To_Add "]);
            //}




            //.OrderBy(x => x.status)
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM project ORDER BY percentcompleted DESC";
            //string query = "SELECT * FROM project WHERE percentcompleted<>100 ORDER BY percentcompleted DESC";
            string query = "SELECT * FROM project WHERE status='unfinished' AND percentcompleted<>100 ORDER BY percentcompleted DESC";
            //string query = "SELECT * FROM project WHERE status='unfinished'";
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
                            var projectModel = new ProjectModel();
                            projectModel.id = Convert.ToInt32(myReader["id"]);
                            projectModel.title = myReader["title"].ToString();
                            projectModel.status = myReader["status"].ToString();
                            projectModel.percentcompleted = Convert.ToInt32(myReader["percentcompleted"]);
                            projectModel.owner = myReader["owner"].ToString();
                            list.Add(projectModel);
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
        public List<_1w4w.CMS.Models.ProjectModel> GetFinishedProjects()
        {
            var list = new List<_1w4w.CMS.Models.ProjectModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM project WHERE percentcompleted=100 ORDER BY percentcompleted DESC";
            string query = "SELECT * FROM project WHERE status='finished' AND percentcompleted=100 ORDER BY percentcompleted DESC";
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
                            var projectModel = new ProjectModel();
                            projectModel.id = Convert.ToInt32(myReader["id"]);
                            projectModel.title = myReader["title"].ToString();
                            projectModel.status = myReader["status"].ToString();
                            projectModel.percentcompleted = Convert.ToInt32(myReader["percentcompleted"]);
                            projectModel.owner = myReader["owner"].ToString();
                            list.Add(projectModel);
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
        public int GetHighestProjectId()
        {
            var list = new List<_1w4w.CMS.Models.ProjectModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM project";
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
                            var projectModel = new ProjectModel();
                            projectModel.id = Convert.ToInt32(myReader["id"]);
                            projectModel.title = myReader["title"].ToString();
                            projectModel.status = myReader["status"].ToString();
                            projectModel.percentcompleted = Convert.ToInt32(myReader["percentcompleted"]);
                            projectModel.owner = myReader["owner"].ToString();
                            list.Add(projectModel);
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



        // -----------------------------------------------------------------------------------
        // MYSQL CRUD
        // -----------------------------------------------------------------------------------
        public void Create(_1w4w.CMS.Models.ProjectModel model)
        {
            var highestProjectId = GetHighestProjectId();
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "INSERT INTO project(id, title, status, percentcompleted, owner) VALUES(@id, @title, @status, @percentcompleted, @owner)";
            //comm.Parameters.AddWithValue("@id", (highestProjectId + 1));
            //comm.Parameters.AddWithValue("@title", model.title);
            //comm.Parameters.AddWithValue("@status", model.status);
            //comm.Parameters.AddWithValue("@percentcompleted", model.percentcompleted);
            //comm.Parameters.AddWithValue("@owner", model.owner);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                string query = "INSERT INTO project(id, title, status, percentcompleted, owner) VALUES(@id, @title, @status, @percentcompleted, @owner)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", (highestProjectId + 1));
                cmd.Parameters.AddWithValue("@title", model.title);
                cmd.Parameters.AddWithValue("@status", model.status);
                cmd.Parameters.AddWithValue("@percentcompleted", model.percentcompleted);
                cmd.Parameters.AddWithValue("@owner", model.owner);
                cmd.ExecuteNonQuery();
            }
        }

        public List<_1w4w.CMS.Models.ProjectModel> Read()
        {
            var list = new List<_1w4w.CMS.Models.ProjectModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM project ORDER BY percentcompleted DESC";
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
                            var projectModel = new ProjectModel();
                            projectModel.id = Convert.ToInt32(myReader["id"]);
                            projectModel.title = myReader["title"].ToString();
                            projectModel.status = myReader["status"].ToString();
                            projectModel.percentcompleted = Convert.ToInt32(myReader["percentcompleted"]);
                            projectModel.owner = myReader["owner"].ToString();
                            list.Add(projectModel);
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
        public _1w4w.CMS.Models.ProjectModel Read(int id)
        {
            //var list = new List<_1w4w.CMS.Models.ProjectModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM project WHERE id=" + id + " ORDER BY percentcompleted DESC";
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
                            var projectModel = new ProjectModel();
                            projectModel.id = Convert.ToInt32(myReader["id"]);
                            projectModel.title = myReader["title"].ToString();
                            projectModel.status = myReader["status"].ToString();
                            projectModel.percentcompleted = Convert.ToInt32(myReader["percentcompleted"]);
                            projectModel.owner = myReader["owner"].ToString();
                            return projectModel;
                        }
                        return null;
                    }

                }


            }
            catch
            {
                return null;
            }
            return null;
        }
        public void Update(_1w4w.CMS.Models.ProjectModel model)
        {
            var highestProjectId = GetHighestProjectId();
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "UPDATE project SET id='" + @model.id + "', title='" + model.title + "', owner='" + model.owner + "',status='" + model.status + "',percentcompleted='" + model.percentcompleted + "' WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", model.id);
            //comm.Parameters.AddWithValue("@title", model.title);
            //comm.Parameters.AddWithValue("@owner", model.owner);
            //comm.Parameters.AddWithValue("@status", model.status);
            //comm.Parameters.AddWithValue("@percentcompleted", model.percentcompleted);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var sql = "UPDATE project SET id='" + @model.id + "', title='" + model.title + "', owner='" + model.owner + "',status='" + model.status + "',percentcompleted='" + model.percentcompleted + "' WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", model.id);
                cmd.Parameters.AddWithValue("@title", model.title);
                cmd.Parameters.AddWithValue("@owner", model.owner);
                cmd.Parameters.AddWithValue("@status", model.status);
                cmd.Parameters.AddWithValue("@percentcompleted", model.percentcompleted);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

            }
        }
        public void Delete(int id)
        {
            var highestProjectId = GetHighestProjectId();
            var query = "DELETE FROM project WHERE id=@id;";
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "DELETE FROM project WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", id);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
        }
        // -----------------------------------------------------------------------------------
        
    }
}