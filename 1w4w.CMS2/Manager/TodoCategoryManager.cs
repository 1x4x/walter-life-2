using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class TodoCategoryManager
    {
        public List<Models.TodoCategoryModel> GetList()
        {
            var list = new List<Models.TodoCategoryModel>();
            string query = "SELECT * FROM tttodocategory;";
            MySqlDataReader myReader;
            try
            {
                var constr = DatabaseManager.GetConnectionstring();
                using (var con = new MySqlConnection(constr))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = query;


                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new Models.TodoCategoryModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.userid = Convert.ToInt32(myReader["userid"]);
                            model.sortorder = Convert.ToInt32(myReader["sortorder"]);
                            model.boardid = Convert.ToInt32(myReader["boardid"]);
                            model.name = myReader["name"].ToString();
                            model.color = myReader["color"].ToString();
                            model.backgroundcolor = myReader["backgroundcolor"].ToString();
                            model.hidden = Convert.ToInt32(myReader["hidden"]);

                            list.Add(model);
                        }
                    }
                    return list;
                }

            }
            catch
            {
                throw;
            }
        }

        //public List<Models.TaskModel> GetUnfinishedTasks(string projectid = "")
        //{
        //    var list = new List<Models.TaskModel>();





        //    string myConnection = DatabaseManager.GetConnectionstring();

        //    //string query = "SELECT * FROM task WHERE status<>'finished' and projectid='" + projectid + "' ORDER BY status DESC";
        //    string query = "";
        //    if (string.IsNullOrEmpty(projectid))
        //    {
        //        query = "SELECT * FROM tttodocategory WHERE status='unfinished' ORDER BY status DESC";
        //    }
        //    else
        //    {
        //        query = "SELECT * FROM tttodocategory WHERE status='unfinished' and projectid='" + projectid + "' ORDER BY status DESC";
        //    }

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
        //                var projectModel = new TaskModel();
        //                projectModel.id = Convert.ToInt32(myReader["id"]);
        //                projectModel.projectid = Convert.ToInt32(myReader["projectid"]);
        //                projectModel.title = myReader["title"].ToString();
        //                projectModel.status = myReader["status"].ToString();
        //                projectModel.color = myReader["color"].ToString();
        //                projectModel.owner = myReader["owner"].ToString();
        //                list.Add(projectModel);
        //            }
        //        }
        //        return list;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        //public int GetHighestTaskId()
        //{
        //    var list = new List<Models.TaskModel>();
        //    string myConnection = DatabaseManager.GetConnectionstring();
        //    string query = "SELECT * FROM tttodocategory";
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
        //                var taskModel = new TaskModel();
        //                taskModel.id = Convert.ToInt32(myReader["id"]);
        //                taskModel.title = myReader["title"].ToString();
        //                taskModel.status = myReader["status"].ToString();
        //                taskModel.owner = myReader["owner"].ToString();
        //                list.Add(taskModel);
        //            }
        //        }
        //        return Convert.ToInt32(myReader["id"]);
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
        //public List<Models.TaskModel> GetFinishedTasks(string projectid = "")
        //{
        //    var list = new List<Models.TaskModel>();
        //    string myConnection = DatabaseManager.GetConnectionstring();
        //    string query = "";
        //    if (string.IsNullOrEmpty(projectid))
        //    {
        //        query = "SELECT * FROM tttodocategory WHERE status='finished' ORDER BY status DESC";
        //    }
        //    else
        //    {
        //        query = "SELECT * FROM tttodocategory WHERE status='finished' and projectid='" + projectid + "' ORDER BY status DESC";
        //    }
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
        //                var taskModel = new TaskModel();
        //                taskModel.id = Convert.ToInt32(myReader["id"]);
        //                taskModel.projectid = Convert.ToInt32(myReader["projectid"]);
        //                taskModel.title = myReader["title"].ToString();
        //                taskModel.status = myReader["status"].ToString();
        //                taskModel.owner = myReader["owner"].ToString();
        //                list.Add(taskModel);
        //            }
        //        }
        //        return list;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //// -----------------------------------------------------------------------------------
        //// MYSQL CRUD
        //// -----------------------------------------------------------------------------------

        //public List<Models.TaskModel> Read()
        //{
        //    var list = new List<Models.TaskModel>();
        //    string myConnection = DatabaseManager.GetConnectionstring();
        //    string query = "SELECT * FROM tttodocategory ORDER BY status DESC";
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
        //                var taskModel = new TaskModel();
        //                taskModel.id = Convert.ToInt32(myReader["id"]);
        //                taskModel.projectid = Convert.ToInt32(myReader["projectid"]);
        //                taskModel.title = myReader["title"].ToString();
        //                taskModel.status = myReader["status"].ToString();
        //                taskModel.color = myReader["color"].ToString();
        //                taskModel.owner = myReader["owner"].ToString();
        //                list.Add(taskModel);
        //            }
        //        }
        //        return list;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        //public Models.TaskModel Read(int id)
        //{
        //    string myConnection = DatabaseManager.GetConnectionstring();
        //    string query = "SELECT * FROM tttodocategory WHERE id=" + id + " ORDER BY status DESC";
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
        //                var taskModel = new TaskModel();
        //                taskModel.id = Convert.ToInt32(myReader["id"]);
        //                taskModel.projectid = Convert.ToInt32(myReader["projectid"]);
        //                taskModel.title = myReader["title"].ToString();
        //                taskModel.status = myReader["status"].ToString();
        //                taskModel.color = myReader["color"].ToString();
        //                taskModel.owner = myReader["owner"].ToString();
        //                return taskModel;
        //            }
        //            return null;
        //        }
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    return null;
        //}





        public int GetHighestTodoCategoryId()
        {
            var list = new List<Models.TodoCategoryModel>();
            string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM tttodocategory";
            var conDatabase = new MySqlConnection(myConnection);
            MySqlCommand cmdDataBase = new MySqlCommand(query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDataBase.ExecuteReader();
                if (myReader.HasRows == true)
                {
                    while (myReader.Read())
                    {
                        var model = new Models.TodoCategoryModel();
                        model.id = Convert.ToInt32(myReader["id"]);
                        //model.userid = Convert.ToInt32(myReader["userid"]);
                        //model.sortorder = Convert.ToInt32(myReader["sortorder"]);
                        //model.name = myReader["name"].ToString();
                        //model.color = myReader["color"].ToString();
                        //model.backgroundcolor = myReader["backgroundcolor"].ToString();
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

        public void Create(Models.TodoCategoryModel model)
        {
            var highestTodoCategoryId = GetHighestTodoCategoryId();
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO tttodocategory(id, userid, sortorder, boardid, hidden, name, color, backgroundcolor) VALUES(@id, @userid, @sortorder, @boardid, @hidden, @name, @color, @backgroundcolor)";
            comm.Parameters.AddWithValue("@id", (highestTodoCategoryId + 1));
            comm.Parameters.AddWithValue("@userid", model.userid);
            comm.Parameters.AddWithValue("@sortorder", model.sortorder);
            comm.Parameters.AddWithValue("@boardid", model.boardid);
            comm.Parameters.AddWithValue("@hidden", model.hidden);
            comm.Parameters.AddWithValue("@name", model.name);
            comm.Parameters.AddWithValue("@color", model.color);
            comm.Parameters.AddWithValue("@backgroundcolor", model.backgroundcolor);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(Models.TodoCategoryModel model)
        {
            var highestProjectId = GetHighestTodoCategoryId();
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "UPDATE tttodocategory SET @id='" + model.id + "', @userid='" + model.userid + "', @sortorder='" + model.sortorder + "', @name='" + model.name + "', @backgroundcolor='" + model.backgroundcolor + "', @color='" + model.color + "' WHERE id=@id;";
            comm.CommandText = "UPDATE tttodocategory SET id=@id, userid=@userid, sortorder=@sortorder, hidden=@hidden, boardid=@boardid, name=@name, backgroundcolor=@backgroundcolor, color=@color WHERE id=@id;";
            comm.Parameters.AddWithValue("@id", model.id);
            comm.Parameters.AddWithValue("@userid", model.userid);
            comm.Parameters.AddWithValue("@sortorder", model.sortorder);
            comm.Parameters.AddWithValue("@boardid", model.boardid);
            comm.Parameters.AddWithValue("@hidden", model.hidden);
            comm.Parameters.AddWithValue("@name", model.name);
            comm.Parameters.AddWithValue("@backgroundcolor", model.backgroundcolor);
            comm.Parameters.AddWithValue("@color", model.color);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int id)
        {
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM tttodocategory WHERE id=@id;";
            comm.Parameters.AddWithValue("@id", id);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}