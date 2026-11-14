using MySql.Data.MySqlClient;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class TaskManager
    {
        public List<_1w4w.CMS.Models.TaskModel> GetUnfinishedTasks(string projectid = "")
        {
            var list = new List<_1w4w.CMS.Models.TaskModel>();





            //string myConnection = DatabaseManager.GetConnectionstring();

            //string query = "SELECT * FROM task WHERE status<>'finished' and projectid='" + projectid + "' ORDER BY status DESC";
            string query = "";
            if (string.IsNullOrEmpty(projectid))
            {
                query = "SELECT * FROM task WHERE status='unfinished' ORDER BY status DESC";
            }
            else
            {
                query = "SELECT * FROM task WHERE status='unfinished' and projectid='" + projectid + "' ORDER BY status DESC";
            }

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
                    myReader = cmd.ExecuteReader();
                    //myReader = cmdDataBase.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var projectModel = new TaskModel();
                            projectModel.id = Convert.ToInt32(myReader["id"]);
                            projectModel.projectid = Convert.ToInt32(myReader["projectid"]);
                            projectModel.title = myReader["title"].ToString();
                            projectModel.status = myReader["status"].ToString();
                            projectModel.color = myReader["color"].ToString();
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
        public int GetHighestTaskId()
        {
            var list = new List<_1w4w.CMS.Models.TaskModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM task";
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
                            var taskModel = new TaskModel();
                            taskModel.id = Convert.ToInt32(myReader["id"]);
                            taskModel.title = myReader["title"].ToString();
                            taskModel.status = myReader["status"].ToString();
                            taskModel.owner = myReader["owner"].ToString();
                            list.Add(taskModel);
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
        public List<_1w4w.CMS.Models.TaskModel> GetFinishedTasks(string projectid = "")
        {
            var list = new List<_1w4w.CMS.Models.TaskModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "";
            if (string.IsNullOrEmpty(projectid))
            {
                query = "SELECT * FROM task WHERE status='finished' ORDER BY status DESC";
            }
            else
            {
                query = "SELECT * FROM task WHERE status='finished' and projectid='" + projectid + "' ORDER BY status DESC";
            }
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
                            var taskModel = new TaskModel();
                            taskModel.id = Convert.ToInt32(myReader["id"]);
                            taskModel.projectid = Convert.ToInt32(myReader["projectid"]);
                            taskModel.title = myReader["title"].ToString();
                            taskModel.status = myReader["status"].ToString();
                            taskModel.owner = myReader["owner"].ToString();
                            list.Add(taskModel);
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

        // -----------------------------------------------------------------------------------
        // MYSQL CRUD
        // -----------------------------------------------------------------------------------
        public void Create(_1w4w.CMS.Models.TaskModel model)
        {
            var highestProjectId = GetHighestTaskId();
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "INSERT INTO task(id, projectid, title, status, color, owner) VALUES(@id, @projectid, @title, @status, @color, @owner)";
            //comm.Parameters.AddWithValue("@id", (highestProjectId + 1));
            //comm.Parameters.AddWithValue("@projectid", model.projectid);
            //comm.Parameters.AddWithValue("@title", model.title);
            //comm.Parameters.AddWithValue("@status", model.status);
            //comm.Parameters.AddWithValue("@color", model.color);
            //comm.Parameters.AddWithValue("@owner", model.owner);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var query = "INSERT INTO task(id, projectid, title, status, color, owner) VALUES(@id, @projectid, @title, @status, @color, @owner)";
                cmd.Parameters.AddWithValue("@id", (highestProjectId + 1));
                cmd.Parameters.AddWithValue("@projectid", model.projectid);
                cmd.Parameters.AddWithValue("@title", model.title);
                cmd.Parameters.AddWithValue("@status", model.status);
                cmd.Parameters.AddWithValue("@color", model.color);
                cmd.Parameters.AddWithValue("@owner", model.owner);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
        }
        public List<_1w4w.CMS.Models.TaskModel> Read()
        {
            var list = new List<_1w4w.CMS.Models.TaskModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM task ORDER BY status DESC";
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
                            var taskModel = new TaskModel();
                            taskModel.id = Convert.ToInt32(myReader["id"]);
                            taskModel.projectid = Convert.ToInt32(myReader["projectid"]);
                            taskModel.title = myReader["title"].ToString();
                            taskModel.status = myReader["status"].ToString();
                            taskModel.color = myReader["color"].ToString();
                            taskModel.owner = myReader["owner"].ToString();
                            list.Add(taskModel);
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
        public _1w4w.CMS.Models.TaskModel Read(int id)
        {
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM task WHERE id=" + id + " ORDER BY status DESC";
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
                            var taskModel = new TaskModel();
                            taskModel.id = Convert.ToInt32(myReader["id"]);
                            taskModel.projectid = Convert.ToInt32(myReader["projectid"]);
                            taskModel.title = myReader["title"].ToString();
                            taskModel.status = myReader["status"].ToString();
                            taskModel.color = myReader["color"].ToString();
                            taskModel.owner = myReader["owner"].ToString();
                            return taskModel;
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

        public void Update(_1w4w.CMS.Models.TaskModel model)
        {
            var highestProjectId = GetHighestTaskId();
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "UPDATE task SET id='" + @model.id + "', title='" + model.title + "', owner='" + model.owner + "',status='" + model.status + "',color='" + model.color + "' WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", model.id);
            //comm.Parameters.AddWithValue("@projectid", model.projectid);
            //comm.Parameters.AddWithValue("@title", model.title);
            //comm.Parameters.AddWithValue("@owner", model.owner);
            //comm.Parameters.AddWithValue("@color", model.color);
            //comm.Parameters.AddWithValue("@status", model.status);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var query = "UPDATE task SET id='" + @model.id + "', title='" + model.title + "', owner='" + model.owner + "',status='" + model.status + "',color='" + model.color + "' WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", model.id);
                cmd.Parameters.AddWithValue("@projectid", model.projectid);
                cmd.Parameters.AddWithValue("@title", model.title);
                cmd.Parameters.AddWithValue("@owner", model.owner);
                cmd.Parameters.AddWithValue("@color", model.color);
                cmd.Parameters.AddWithValue("@status", model.status);
                
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            var highestProjectId = GetHighestTaskId();
            

            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "DELETE FROM task WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", id);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var query = "DELETE FROM task WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }
        // -----------------------------------------------------------------------------------


    }
}