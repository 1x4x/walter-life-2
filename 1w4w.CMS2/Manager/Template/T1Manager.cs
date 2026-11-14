using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using _1w4w.CMS.Models;
using _1w4w.CMS.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager.Template
{
    public class T1Manager
    {
        public static void UpdatePart1startHeadings(string websiteid, string heading1, string heading2, string opentimesmontofri, string opentimessattosun, string opentimeslunch)
        {
            //websiteid = "1";

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var sql = "";
                sql += "UPDATE t1catefood SET";
                sql += " heading1='" + heading1 + "',";
                sql += " heading2='" + heading2 + "',";
                sql += " opentimesmontofri='" + opentimesmontofri + "',";
                sql += " opentimessattosun='" + opentimessattosun + "',";
                sql += " opentimeslunch='" + opentimeslunch + "'";
                //sql += " backgroundimage='" + backgroundimage + "'";
                sql += " WHERE websiteid=@websiteid;";
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@heading1", heading1);
                cmd.Parameters.AddWithValue("@heading2", heading2);
                cmd.Parameters.AddWithValue("@opentimesmontofri", opentimesmontofri);
                cmd.Parameters.AddWithValue("@opentimessattosun", opentimessattosun);
                cmd.Parameters.AddWithValue("@opentimeslunch", opentimeslunch);
                //comm.Parameters.AddWithValue("@backgroundimage", backgroundimage);
                cmd.Parameters.AddWithValue("@websiteid", websiteid);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdatePart1startBackgroundimage(int websiteid, string backgroundimage)
        {
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //var sql = "";
            //sql += "UPDATE t1catefood SET";
            //sql += " backgroundimage='" + backgroundimage + "'";
            //sql += " WHERE websiteid=@websiteid;";

            //comm.CommandText = sql;
            //comm.Parameters.AddWithValue("@backgroundimage", backgroundimage);
            //comm.Parameters.AddWithValue("@websiteid", websiteid);
            //comm.ExecuteNonQuery();
            //conn.Close();


            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var sql = "";
                sql += "UPDATE t1catefood SET";
                sql += " backgroundimage='" + backgroundimage + "'";
                sql += " WHERE websiteid=@websiteid;";

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@backgroundimage", backgroundimage);
                cmd.Parameters.AddWithValue("@websiteid", websiteid);
                cmd.ExecuteNonQuery();
            }
        }


        public static _1w4w.CMS.Models.Template.T1catefoodModel GettPopulatedt1catefood(string websiteid)
        {
            var list = new List<_1w4w.CMS.Models.Template.T1catefoodModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            //string query = "SELECT * FROM website WHERE websiteId=" + id + " ORDER BY id ASC";
            string query = "SELECT * FROM t1catefood WHERE websiteid='" + websiteid + "' ORDER BY id ASC";
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
                    //myReader = cmdDataBase.ExecuteReader();
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new T1catefoodModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.heading1 = myReader["heading1"].ToString();
                            model.heading2 = myReader["heading2"].ToString();
                            model.opentimesmontofri = myReader["opentimesmontofri"].ToString();
                            model.opentimessattosun = myReader["opentimessattosun"].ToString();
                            model.opentimeslunch = myReader["opentimeslunch"].ToString();
                            model.backgroundimage = myReader["backgroundimage"].ToString();
                            model.box1heading = myReader["box1heading"].ToString();
                            model.box2heading = myReader["box2heading"].ToString();
                            model.box3heading = myReader["box3heading"].ToString();
                            model.box4heading = myReader["box4heading"].ToString();
                            model.box1text = myReader["box1text"].ToString();
                            model.box2text = myReader["box2text"].ToString();
                            model.box3text = myReader["box3text"].ToString();
                            model.box4text = myReader["box4text"].ToString();
                            model.box1icon = myReader["box1icon"].ToString();
                            model.box2icon = myReader["box2icon"].ToString();
                            model.box3icon = myReader["box3icon"].ToString();
                            model.box4icon = myReader["box4icon"].ToString();
                            model.part3takeaway_heading1 = myReader["part3takeaway_heading1"].ToString();
                            model.part3takeaway_heading2 = myReader["part3takeaway_heading2"].ToString();
                            model.part3takeaway_text = myReader["part3takeaway_text"].ToString();
                            model.part3takeaway_image = myReader["part3takeaway_image"].ToString();

                            model.part4videocarusel_slide1_heading1 = myReader["part4videocarusel_slide1_heading1"].ToString();
                            model.part4videocarusel_slide1_heading2 = myReader["part4videocarusel_slide1_heading2"].ToString();
                            model.part4videocarusel_slide1_heading3 = myReader["part4videocarusel_slide1_heading3"].ToString();
                            model.part4videocarusel_slide1_heading4 = myReader["part4videocarusel_slide1_heading4"].ToString();
                            model.part4videocarusel_slide1_text = myReader["part4videocarusel_slide1_text"].ToString();
                            model.part4videocarusel_slide1_videourl = myReader["part4videocarusel_slide1_videourl"].ToString();

                            model.part4videocarusel_slide2_heading1 = myReader["part4videocarusel_slide2_heading1"].ToString();
                            model.part4videocarusel_slide2_heading2 = myReader["part4videocarusel_slide2_heading2"].ToString();
                            model.part4videocarusel_slide2_heading3 = myReader["part4videocarusel_slide2_heading3"].ToString();
                            model.part4videocarusel_slide2_heading4 = myReader["part4videocarusel_slide2_heading4"].ToString();
                            model.part4videocarusel_slide2_text = myReader["part4videocarusel_slide2_text"].ToString();
                            model.part4videocarusel_slide2_videourl = myReader["part4videocarusel_slide2_videourl"].ToString();

                            model.part4videocarusel_slide3_heading1 = myReader["part4videocarusel_slide3_heading1"].ToString();
                            model.part4videocarusel_slide3_heading2 = myReader["part4videocarusel_slide3_heading2"].ToString();
                            model.part4videocarusel_slide3_heading3 = myReader["part4videocarusel_slide3_heading3"].ToString();
                            model.part4videocarusel_slide3_heading4 = myReader["part4videocarusel_slide3_heading4"].ToString();
                            model.part4videocarusel_slide3_text = myReader["part4videocarusel_slide3_text"].ToString();
                            model.part4videocarusel_slide3_videourl = myReader["part4videocarusel_slide3_videourl"].ToString();

                            model.part5tablebooking_heading1 = myReader["part5tablebooking_heading1"].ToString();
                            model.part5tablebooking_heading2 = myReader["part5tablebooking_heading2"].ToString();
                            model.part5tablebooking_buttontext = myReader["part5tablebooking_buttontext"].ToString();

                            model.part6contactheading1 = myReader["part6contactheading1"].ToString();
                            model.part6contactheading2 = myReader["part6contactheading2"].ToString();

                            model.part6contactcolumn1heading1 = myReader["part6contactcolumn1heading1"].ToString();
                            model.part6contactcolumn1text1 = myReader["part6contactcolumn1text1"].ToString();
                            model.part6contactcolumn1text2 = myReader["part6contactcolumn1text2"].ToString();
                            list.Add(model);
                            return model;
                        }
                    }
                }


            }
            catch
            {
                return null;
            }


            //var t1 = _1w4w.CMS.Manager.template.t1Manager.GettPopulated1catefood();
            //var t1 = new _1w4w.CMS.Models.template.t1catefoodModel();
            //t1.heading1 = "a1";
            //t1.heading2 = "b2";
            //return t1;
            return null;
        }
    }
}