using MySql.Data.MySqlClient;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Mvc;

namespace _1w4w.CMS.Manager
{
    public class PageManager
    {
        [Obsolete]
        public void aaa()
        {
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from page";
            }
        }


        public static List<Models.PageModel> GetPageList()
        {
            var list = new List<_1w4w.CMS.Models.PageModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM website WHERE websiteId=" + id + " ORDER BY id ASC";
            string query = "SELECT * FROM page ORDER BY id ASC";
            //var conDatabase = new MySqlConnection(myConnection);
            //MySqlCommand cmdDataBase = new MySqlCommand(query, conDatabase);
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                //cmd.CommandText = "select * from page";
                cmd.CommandText = query;




                MySqlDataReader myReader;
                try
                {
                    //conDatabase.Open();
                    //myReader = cmdDataBase.ExecuteReader();
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new PageModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.parentid = Convert.ToInt32(myReader["parentid"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.name = myReader["name"].ToString();
                            model.href = myReader["href"].ToString();

                            model.text1 = myReader["text1"].ToString();
                            model.text2 = myReader["text2"].ToString();
                            model.text3 = myReader["text3"].ToString();
                            model.text4 = myReader["text4"].ToString();
                            model.text5 = myReader["text5"].ToString();
                            model.text6 = myReader["text6"].ToString();
                            model.text7 = myReader["text7"].ToString();
                            model.text8 = myReader["text8"].ToString();
                            model.text9 = myReader["text9"].ToString();
                            model.text10 = myReader["text10"].ToString();

                            list.Add(model);
                        }
                    }
                    else
                    {
                        // if no page exists yet create 1 to be nice to the user :)
                        var model = new PageModel();
                        model.id = Convert.ToInt32("1");
                        model.parentid = Convert.ToInt32("0");
                        model.websiteid = Convert.ToInt32("1");
                        model.name = "Start";
                        model.href = "";

                        model.text1 = "Welcome to the our magifique startpage :)";
                        model.text2 = "";
                        model.text3 = "";
                        model.text4 = "";
                        model.text5 = "";
                        model.text6 = "";
                        model.text7 = "";
                        model.text8 = "";
                        model.text9 = "";
                        model.text10 = "";

                        new PageManager().Create(model);

                        list.Add(model);
                    }
                    return list;
                }
                catch
                {
                    throw;
                    //return null;
                }
            }
        }

        //public static List<Models.PageModel> GetPageList()
        //{
        //    var list = new List<_1w4w.CMS.Models.PageModel>();
        //    string myConnection = DatabaseManager.GetConnectionstring();
        //    //string query = "SELECT * FROM website WHERE websiteId=" + id + " ORDER BY id ASC";
        //    string query = "SELECT * FROM page ORDER BY id ASC";
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
        //                var model = new PageModel();
        //                model.id = Convert.ToInt32(myReader["id"]);
        //                model.parentid = Convert.ToInt32(myReader["parentid"]);
        //                model.websiteid = Convert.ToInt32(myReader["websiteid"]);
        //                model.name = myReader["name"].ToString();
        //                model.href = myReader["href"].ToString();


        //                model.pagepartlist = myReader[""];
        //                list.Add(model);
        //            }
        //        }
        //        return list;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        public Models.PageModel GetPageById(int id, List<Models.PageModel> list)
        {
            var model = list.SingleOrDefault(x => x.id == id);
            return model;
        }

        public void CreateNew()
        {
            int newhighestid = (GetHighestId() + 1);
            
            PageModel model = new PageModel();
            model.id = newhighestid;
            model.parentid = Convert.ToInt32("0");
            model.websiteid = Convert.ToInt32("0");
            model.name = "new page";
            model.href = "";
            model.text1 = "1";
            model.text2 = "2";
            model.text3 = "3";
            model.text4 = "4";
            model.text5 = "5";
            model.text6 = "6";
            model.text7 = "7";
            model.text8 = "8";
            model.text9 = "9";
            model.text10 = "10";
            Create(model);
        }

        public int Create(_1w4w.CMS.Models.PageModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                //cmd.CommandText = "select * from page";
                



                var sql = "";
                sql += "INSERT INTO page(id, parentid, websiteid, name, href, ";
                sql += " text1, text2, text3, text4, text5, text6, text7, text8, text9, text10";
                sql += ") ";

                sql += " VALUES(@id, @parentid, @websiteid, @name, @href,";
                sql += " @text1, @text2, @text3, @text4, @text5, @text6, @text7, @text8, @text9, @text10";
                sql += ")";
                cmd.CommandText = sql;
                //comm.CommandText = sql;
                var id = model.id.ToString() ?? "";
                var parentid = model.parentid.ToString() ?? "";
                var websiteid = model.websiteid.ToString() ?? "";
                var name = model.name.ToString() ?? "";
                var href = model.href.ToString() ?? "";
                var text1 = model.text1.ToString() ?? "";
                var text2 = model.text2.ToString() ?? "";
                var text3 = model.text3.ToString() ?? "";
                var text4 = model.text4.ToString() ?? "";
                var text5 = model.text5.ToString() ?? "";
                var text6 = model.text6.ToString() ?? "";
                var text7 = model.text7.ToString() ?? "";
                var text8 = model.text8.ToString() ?? "";
                var text9 = model.text9.ToString() ?? "";
                var text10 = model.text10.ToString() ?? "";
                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@parentid", model.parentid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@name", name.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@href", href.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text1", text1.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text2", text2.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text3", text3.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text4", text4.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text5", text5.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text6", text6.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text7", text7.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text8", text8.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text9", text9.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@text10", text10.Replace("'", "''"));
                var createdid = cmd.ExecuteNonQuery();
                //con.Close();
                return createdid;
            }
        }

        public int Update(_1w4w.CMS.Models.PageModel model)
        {
            var name = model.name ?? "";
            var href = model.href ?? "";
            var text1 = model.text1 ?? "";
            var text2 = model.text2 ?? "";
            var text3 = model.text3 ?? "";
            var text4 = model.text4 ?? "";
            var text5 = model.text5 ?? "";
            var text6 = model.text6 ?? "";
            var text7 = model.text7 ?? "";
            var text8 = model.text8 ?? "";
            var text9 = model.text9 ?? "";
            var text10 = model.text10 ?? "";





            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from page";
            



                //string connString = DatabaseManager.GetConnectionstring();
                //MySqlConnection conn = new MySqlConnection(connString);
                //conn.Open();
                //MySqlCommand comm = conn.CreateCommand();
                var sql = "";
                sql += "UPDATE page SET";
                sql += " websiteid='" + Convert.ToInt32(model.websiteid) + "',";
                sql += " parentid='" + Convert.ToInt32(model.parentid) + "',";
                sql += " name='" + name.Replace("'", "''") + "',";
                sql += " href='" + href.Replace("'", "''") + "',";
                sql += " text1='" + text1.Replace("'", "''") + "',";
                sql += " text2='" + text2.Replace("'", "''") + "',";
                sql += " text3='" + text3.Replace("'", "''") + "',";
                sql += " text4='" + text4.Replace("'", "''") + "',";
                sql += " text5='" + text5.Replace("'", "''") + "',";
                sql += " text6='" + text6.Replace("'", "''") + "',";
                sql += " text7='" + text7.Replace("'", "''") + "',";
                sql += " text8='" + text8.Replace("'", "''") + "',";
                sql += " text9='" + text9.Replace("'", "''") + "',";
                sql += " text10='" + text10.Replace("'", "''") + "'";
                sql += " WHERE id=@id;";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", model.id);
                cmd.Parameters.AddWithValue("@parentid", model.parentid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@name", model.name);
                cmd.Parameters.AddWithValue("@href", model.href);
                cmd.Parameters.AddWithValue("@text1", model.text1);
                cmd.Parameters.AddWithValue("@text2", model.text2);
                cmd.Parameters.AddWithValue("@text3", model.text3);
                cmd.Parameters.AddWithValue("@text4", model.text4);
                cmd.Parameters.AddWithValue("@text5", model.text5);
                cmd.Parameters.AddWithValue("@text6", model.text6);
                cmd.Parameters.AddWithValue("@text7", model.text7);
                cmd.Parameters.AddWithValue("@text8", model.text8);
                cmd.Parameters.AddWithValue("@text9", model.text9);
                cmd.Parameters.AddWithValue("@text10", model.text10);
                var updatedid = cmd.ExecuteNonQuery();
                //conn.Close();

                return model.id;
            }
        }
        public void Delete(int id)
        {
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM page WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetHighestId()
        {
            var list = new List<_1w4w.CMS.Models.PageModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM page";
            //var conDatabase = new MySqlConnection(myConnection);
            //MySqlCommand cmdDataBase = new MySqlCommand(query, conDatabase);
            MySqlDataReader myReader;

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from page";
                try
                {
                    //conDatabase.Open();
                    //myReader = cmdDataBase.ExecuteReader();
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new PageModel();
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

        public static bool ParentHasChildren(int id, List<PageModel> list)
        {
            if (list == null) return false;
            if (!list.Any()) { return false; }
            // only get the page with the sent in id
            foreach (var page in list.Where(x => x.id == id))
            {
                // get only the childs for this parent
                foreach (var page2 in list.Where(x => x.parentid == page.id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}