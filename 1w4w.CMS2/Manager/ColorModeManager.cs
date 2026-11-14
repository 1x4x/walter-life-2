using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class ColorModeManager
    {
        public static string GetMode(int websiteid)
        {
            // [ROE] Bigmo (385:540)  ID:268248281  Kills: 5,9  Power: 61,7 million 
            string mode = "";
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM colormode where websiteid='" + websiteid + "';";
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
                            mode = myReader["mode"].ToString();
                        }
                    }
                    return mode;
                }
            }
            catch
            {
                return "Light";
            }
        }

        public static void SetMode(ColorMode? colormode, int websiteid)
        {
            if (colormode != null)
            {
                if (colormode.ToString() == "Light")
                {
                    UpdateColorMode(websiteid, colormode.ToString());
                }
                if (colormode.ToString() == "Dark")
                {
                    UpdateColorMode(websiteid, colormode.ToString());
                }
            }
        }

        public enum ColorMode
        {
            Light,
            Dark
        }

        public static void UpdateColorMode(int websiteid, string mode)
        {
            //string connString = DatabaseManager.GetConnectionstring();
            string query = "UPDATE colormode SET mode='" + mode + "' WHERE websiteid=@websiteid;";
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "UPDATE colormode SET mode='" + mode + "' WHERE websiteid=@websiteid;";
            //comm.Parameters.AddWithValue("@websiteid", websiteid);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@websiteid", websiteid);
                cmd.ExecuteNonQuery();
            }
        }

    }
}