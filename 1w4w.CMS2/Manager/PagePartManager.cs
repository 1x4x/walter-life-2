using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class PagePartManager
    {
        public static List<Models.PagePartModel> GetPagePartList()
        {
            var list = new List<_1w4w.CMS.Models.PagePartModel>();
            string query = "SELECT * FROM pagepart ORDER BY sortorder ASC;";
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
                            var model = new PagePartModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.pageid = Convert.ToInt32(myReader["pageid"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.placementid = Convert.ToInt32(myReader["placementid"]);
                            model.sortorder = Convert.ToInt32(myReader["sortorder"]);
                            model.imagepath = myReader["imagepath"].ToString();
                            model.imagetext = myReader["imagetext"].ToString();
                            model.pagepartstyle = myReader["pagepartstyle"].ToString();
                            model.pageparttext = myReader["pageparttext"].ToString();
                            model.parttype = myReader["parttype"].ToString();
                            model.colors = myReader["colors"].ToString();

                            list.Add(model);
                        }
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
        public Models.PagePartModel GetPageById(int id, List<Models.PagePartModel> list)
        {
            var model = list.SingleOrDefault(x => x.id == id);
            return model;
        }

        //public void CreateNew()
        //{
        //    int newhighestid = (GetHighestId() + 1);

        //    PagePartModel model = new PagePartModel();
        //    model.id = newhighestid;
        //    model.pageid = Convert.ToInt32("0");
        //    model.websiteid = Convert.ToInt32("0");
        //    Create(model);
        //}

        public int CreateImagePagePart(_1w4w.CMS.Models.PagePartModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            int newhighestsortorderid = (GetHighestSortorderId(model.pageid, model.placementid) + 1);

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();

                var sql = "";
                sql += "INSERT INTO pagepart(id, pageid, websiteid, imagepath, imagetext, placementid, parttype, sortorder, pagepartstyle)";
                sql += " VALUES(@id, @pageid, @websiteid, @imagepath, @imagetext, @placementid, @parttype, @sortorder, @pagepartstyle)";
                
                cmd.CommandText = sql;
                var id = model.id.ToString() ?? "";
                var pageid = model.pageid.ToString() ?? "";
                var websiteid = model.websiteid.ToString() ?? "";
                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@pageid", model.pageid);
                cmd.Parameters.AddWithValue("@placementid", model.placementid);
                cmd.Parameters.AddWithValue("@imagepath", model.imagepath);
                cmd.Parameters.AddWithValue("@imagetext", model.imagetext);
                cmd.Parameters.AddWithValue("@parttype", model.parttype);
                cmd.Parameters.AddWithValue("@sortorder", newhighestsortorderid);
                cmd.Parameters.AddWithValue("@pagepartstyle", model.pagepartstyle);
                var createdid = cmd.ExecuteNonQuery();
                return createdid;
            }
        }

        public int CreateTextPagePart(_1w4w.CMS.Models.PagePartModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            int newhighestsortorderid = (GetHighestSortorderId(model.pageid, model.placementid) + 1);

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();

                var sql = "";
                sql += "INSERT INTO pagepart(id, pageid, websiteid, pageparttext, placementid, parttype, sortorder, pagepartstyle)";
                sql += " VALUES(@id, @pageid, @websiteid, @pageparttext, @placementid, @parttype, @sortorder, @pagepartstyle)";

                cmd.CommandText = sql;
                var id = model.id.ToString() ?? "";
                var pageid = model.pageid.ToString() ?? "";
                var websiteid = model.websiteid.ToString() ?? "";
                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@pageid", model.pageid);
                cmd.Parameters.AddWithValue("@placementid", model.placementid);
                cmd.Parameters.AddWithValue("@pageparttext", model.pageparttext);
                cmd.Parameters.AddWithValue("@parttype", model.parttype);
                cmd.Parameters.AddWithValue("@sortorder", newhighestsortorderid);
                cmd.Parameters.AddWithValue("@pagepartstyle", model.pagepartstyle);
                var createdid = cmd.ExecuteNonQuery();
                return createdid;
            }
        }

        public int CreateHtmlPagePart(_1w4w.CMS.Models.PagePartModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            int newhighestsortorderid = (GetHighestSortorderId(model.pageid, model.placementid) + 1);

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();

                var sql = "";
                sql += "INSERT INTO pagepart(id, pageid, websiteid, pageparttext, placementid, sortorder, parttype, pagepartstyle)";
                sql += " VALUES(@id, @pageid, @websiteid, @pageparttext, @placementid, @sortorder, @parttype, @pagepartstyle)";

                cmd.CommandText = sql;
                var id = model.id.ToString() ?? "";
                var pageid = model.pageid.ToString() ?? "";
                var websiteid = model.websiteid.ToString() ?? "";
                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@pageid", model.pageid);
                cmd.Parameters.AddWithValue("@placementid", model.placementid);
                cmd.Parameters.AddWithValue("@pageparttext", model.pageparttext);
                cmd.Parameters.AddWithValue("@sortorder", newhighestsortorderid);
                cmd.Parameters.AddWithValue("@parttype", model.parttype);
                cmd.Parameters.AddWithValue("@pagepartstyle", model.pagepartstyle);
                var createdid = cmd.ExecuteNonQuery();
                return createdid;
            }
        }

        public int Update(_1w4w.CMS.Models.PagePartModel model)
        {
            
            var imagepath = model.imagepath;
            var imagetext = model.imagetext;
            var pagepartstyle = model.pagepartstyle;
            var pageparttext = model.pageparttext;
            var parttype = model.parttype;






            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from pagepart";


                var sql = "";
                sql += "UPDATE pagepart SET";
                //sql += " websiteid='" + Convert.ToInt32(model.websiteid) + "',";
                //sql += " pageid='" + Convert.ToInt32(model.pageid) + "',";
                sql += " imagepath='" + imagepath.Replace("'", "''") + "',";
                sql += " imagetext='" + imagetext.Replace("'", "''") + "',";
                sql += " pagepartstyle='" + pagepartstyle.Replace("'", "''") + "',";
                sql += " pageparttext='" + pageparttext.Replace("'", "''") + "',";
                sql += " parttype='" + parttype.Replace("'", "''") + "'";
                sql += " WHERE id=@id;";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id", model.id);
                //cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                //cmd.Parameters.AddWithValue("@websiteid", model.websiteid);
                cmd.Parameters.AddWithValue("@pageid", model.pageid);
                cmd.Parameters.AddWithValue("@imagepath", model.imagepath);
                cmd.Parameters.AddWithValue("@imagetext", model.imagetext);
                cmd.Parameters.AddWithValue("@pagepartstyle", model.pagepartstyle);
                cmd.Parameters.AddWithValue("@pageparttext", model.pageparttext);
                cmd.Parameters.AddWithValue("@parttype", model.parttype);

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
                cmd.CommandText = "DELETE FROM pagepart WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetHighestId()
        {
            var list = new List<_1w4w.CMS.Models.PagePartModel>();
            MySqlDataReader myReader;

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from pagepart";
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new PagePartModel();
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

        public int GetHighestSortorderId(int pageid, int placementid)
        {
            var list = new List<_1w4w.CMS.Models.PagePartModel>();
            MySqlDataReader myReader;

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from pagepart where pageid=" + pageid + " and placementid=" + placementid + ";";
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new PagePartModel();
                            model.sortorder = Convert.ToInt32(myReader["sortorder"]);
                            list.Add(model);
                        }
                    }
                    return Convert.ToInt32(myReader["sortorder"]);
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}