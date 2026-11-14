using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class TodoManager
    {
        public TodoListCountsModel GetListCounts()
        {
            var model = new TodoListCountsModel();
            var list = GetList();
            //foreach (var item in list.Where(x => x.status == "important" && x.tododate != "" && x.tododate != null)) { model.importantCount = (Convert.ToDateTime(item.tododate) - DateTime.Now.Date).Days; }
            var importantCount = list.Where(x => x.todotype == "important" && x.status == "incomplete").Count();
            var meetingCount = list.Where(x => x.todotype == "meeting" && x.status == "incomplete").Count();
            var trainingCount = list.Where(x => x.todotype == "training" && x.status == "incomplete").Count();
            var hygieneCount = list.Where(x => x.todotype == "hygiene" && x.status == "incomplete").Count();
            var bookCount = list.Where(x => x.todotype == "book" && x.status == "incomplete").Count();
            var todoCount = list.Where(x => x.todotype == "todo" && x.status == "incomplete").Count();


            model.importantCount = importantCount;
            model.meetingCount = meetingCount;
            model.trainingCount = trainingCount;
            model.hygieneCount = hygieneCount;
            model.bookCount = bookCount;
            model.todoCount = todoCount;
            
            
            //foreach (var item in list.Where(x => x.status == "important"))
            //foreach (var item in list.Where(x => x.status == "meeting" && x.tododate != "" && x.tododate != null)) { model.meetingCount = (Convert.ToDateTime(item.tododate) - DateTime.Now.Date).Days; }
            //foreach (var item in list.Where(x => x.status == "training" && x.tododate != "" && x.tododate != null)) { model.trainingCount = (Convert.ToDateTime(item.tododate) - DateTime.Now.Date).Days; }
            //foreach (var item in list.Where(x => x.status == "hygiene" && x.tododate != "" && x.tododate != null)) { model.hygieneCount = (Convert.ToDateTime(item.tododate) - DateTime.Now.Date).Days; }
            //foreach (var item in list.Where(x => x.status == "book" && x.tododate != "" && x.tododate != null)) { model.bookCount = (Convert.ToDateTime(item.tododate) - DateTime.Now.Date).Days; }
            //foreach (var item in list.Where(x => x.status == "todo" && x.tododate != "" && x.tododate != null)) { model.todoCount = (Convert.ToDateTime(item.tododate) - DateTime.Now.Date).Days; }
            
            return model;
        }

        public List<Models.TodoModel> GetList()
        {
            var list = new List<Models.TodoModel>();
            string query = "SELECT * FROM tttodo ORDER BY id DESC;";
            MySqlDataReader myReader;
            try
            {
                //using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
                //var constr = "Server=127.0.0.1;Database=1w4w;Port=3306;User ID=1w4wuser;Password=JOKER!P0KERzzz;";
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
                            var model = new Models.TodoModel();
                            model.id = Convert.ToInt32(myReader["id"] ?? 0);
                            model.userid = Convert.ToInt32(myReader["userid"] ?? 0);
                            model.sortorder = Convert.ToInt32(myReader["sortorder"] ?? 0);
                            model.todotext = myReader["todotext"].ToString() ?? "";
                            model.color = myReader["color"].ToString() ?? "";
                            model.backgroundcolor = myReader["backgroundcolor"].ToString() ?? "";
                            model.status = myReader["status"].ToString() ?? "";
                            model.category = Convert.ToInt32(myReader["category"] ?? 0);
                            model.hidden = Convert.ToInt32(myReader["hidden"] ?? 0);

                            //int stockvalue = (reader["StockValue"] as int?) ?? 0;

                            //model.boardid = myReader["boardid"];
                            model.boardid = myReader["boardid"] != DBNull.Value ? Convert.ToInt32(myReader["boardid"]) : 0;
                            model.todotype = myReader["todotype"].ToString() ?? "";
                            model.todoextratext = myReader["todoextratext"].ToString() ?? "";
                            model.todoonthesedaysinmonth = myReader["todoonthesedaysinmonth"].ToString() ?? "";
                            model.tododate = myReader["tododate"].ToString() ?? "";
                            model.todotime = myReader["todotime"].ToString() ?? "";
                            model.todocustombordercolor = myReader["todocustombordercolor"].ToString() ?? "";

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

        public void Create(Models.TodoModel model)
        {
            var highestTodoId = GetHighestTodoId();
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "INSERT INTO tttodo(id, userid, sortorder, todotext, color, backgroundcolor, status, category, hidden, boardid, todotype, todoextratext, todoonthesedaysinmonth, tododate, todotime, todocustombordercolor) VALUES(@id, @userid, @sortorder, @todotext, @color, @backgroundcolor, @status, @category, @hidden, @boardid, @todotype, @todoextratext, @todoonthesedaysinmonth, @tododate, @todotime, @todocustombordercolor)";
            comm.Parameters.AddWithValue("@id", (highestTodoId + 1));
            comm.Parameters.AddWithValue("@userid", model.userid);
            comm.Parameters.AddWithValue("@sortorder", model.sortorder);
            comm.Parameters.AddWithValue("@todotext", model.todotext);
            comm.Parameters.AddWithValue("@color", model.color);
            comm.Parameters.AddWithValue("@backgroundcolor", model.backgroundcolor);
            comm.Parameters.AddWithValue("@status", model.status);
            comm.Parameters.AddWithValue("@category", model.category);
            comm.Parameters.AddWithValue("@hidden", model.hidden);
            
            
            comm.Parameters.AddWithValue("@boardid", model.boardid);
            comm.Parameters.AddWithValue("@todotype", model.todotype);
            comm.Parameters.AddWithValue("@todoextratext", model.todoextratext);
            comm.Parameters.AddWithValue("@todoonthesedaysinmonth", model.todoonthesedaysinmonth);
            comm.Parameters.AddWithValue("@tododate", model.tododate);
            comm.Parameters.AddWithValue("@todotime", model.todotime);
            comm.Parameters.AddWithValue("@todocustombordercolor", model.todocustombordercolor);

            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void Update(Models.TodoModel model)
        {
            //var highestId = GetHighestTodoId();
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "UPDATE tttodocategory SET @id='" + model.id + "', @userid='" + model.userid + "', @sortorder='" + model.sortorder + "', @name='" + model.name + "', @backgroundcolor='" + model.backgroundcolor + "', @color='" + model.color + "' WHERE id=@id;";
            comm.CommandText = "UPDATE tttodo SET id=@id, userid=@userid, sortorder=@sortorder, todotext=@todotext, backgroundcolor=@backgroundcolor, color=@color, status=@status, category=@category, hidden=@hidden, boardid=@boardid, todotype=@todotype, todoextratext=@todoextratext, todoonthesedaysinmonth=@todoonthesedaysinmonth, tododate=@tododate, todotime=@todotime, todocustombordercolor=@todocustombordercolor WHERE id=@id;";
            comm.Parameters.AddWithValue("@id", model.id);
            comm.Parameters.AddWithValue("@userid", model.userid);
            comm.Parameters.AddWithValue("@sortorder", model.sortorder);
            comm.Parameters.AddWithValue("@todotext", model.todotext);
            comm.Parameters.AddWithValue("@backgroundcolor", model.backgroundcolor);
            comm.Parameters.AddWithValue("@color", model.color);
            comm.Parameters.AddWithValue("@status", model.status);
            comm.Parameters.AddWithValue("@category", model.category);
            comm.Parameters.AddWithValue("@hidden", model.hidden);
            comm.Parameters.AddWithValue("@boardid", model.boardid);
            comm.Parameters.AddWithValue("@todotype", model.todotype);
            comm.Parameters.AddWithValue("@todoextratext", model.todoextratext);
            comm.Parameters.AddWithValue("@todoonthesedaysinmonth", model.todoonthesedaysinmonth);
            comm.Parameters.AddWithValue("@tododate", model.tododate);
            comm.Parameters.AddWithValue("@todotime", model.todotime);
            comm.Parameters.AddWithValue("@todocustombordercolor", model.todocustombordercolor);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM tttodo WHERE id=@id;";
            comm.Parameters.AddWithValue("@id", id);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public int GetHighestTodoId()
        {
            var list = new List<Models.TodoModel>();
            string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM tttodo";
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
                        var model = new Models.TodoModel();
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

        public void SetStatus(string status, int id)
        {
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "UPDATE tttodo SET status=@status WHERE id=@id;";
            comm.Parameters.AddWithValue("@id", id);
            comm.Parameters.AddWithValue("@status", status);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void GetDays(string tododate)
        {
            if (tododate == "")
            {
                return;
            }
        }
    }
}