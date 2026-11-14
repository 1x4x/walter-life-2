using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public static class TodaysLunchManager
    {






        public static List<Models.TodaysLunchModel> GetTodaysLunchModels()
        {
            var list = new List<_1w4w.CMS.Models.TodaysLunchModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM todayslunch ORDER BY id ASC";
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
                            var model = new Models.TodaysLunchModel();
                            model.id = myReader["id"].ToString();
                            model.week = myReader["week"].ToString();
                            model.weekday = myReader["weekday"].ToString();
                            model.year = myReader["year"].ToString();

                            model.monday1 = myReader["monday1"].ToString();
                            model.monday2 = myReader["monday2"].ToString();
                            model.monday3 = myReader["monday3"].ToString();
                            model.monday4 = myReader["monday4"].ToString();
                            model.monday5 = myReader["monday5"].ToString();
                            model.monday6 = myReader["monday6"].ToString();
                            model.monday7 = myReader["monday7"].ToString();
                            model.monday8 = myReader["monday8"].ToString();
                            model.monday9 = myReader["monday9"].ToString();
                            model.monday10 = myReader["monday10"].ToString();

                            model.tuesday1 = myReader["tuesday1"].ToString();
                            model.tuesday2 = myReader["tuesday2"].ToString();
                            model.tuesday3 = myReader["tuesday3"].ToString();
                            model.tuesday4 = myReader["tuesday4"].ToString();
                            model.tuesday5 = myReader["tuesday5"].ToString();
                            model.tuesday6 = myReader["tuesday6"].ToString();
                            model.tuesday7 = myReader["tuesday7"].ToString();
                            model.tuesday8 = myReader["tuesday8"].ToString();
                            model.tuesday9 = myReader["tuesday9"].ToString();
                            model.tuesday10 = myReader["tuesday10"].ToString();

                            model.wednesday1 = myReader["wednesday1"].ToString();
                            model.wednesday2 = myReader["wednesday2"].ToString();
                            model.wednesday3 = myReader["wednesday3"].ToString();
                            model.wednesday4 = myReader["wednesday4"].ToString();
                            model.wednesday5 = myReader["wednesday5"].ToString();
                            model.wednesday6 = myReader["wednesday6"].ToString();
                            model.wednesday7 = myReader["wednesday7"].ToString();
                            model.wednesday8 = myReader["wednesday8"].ToString();
                            model.wednesday9 = myReader["wednesday9"].ToString();
                            model.wednesday10 = myReader["wednesday10"].ToString();

                            model.thursday1 = myReader["thursday1"].ToString();
                            model.thursday2 = myReader["thursday2"].ToString();
                            model.thursday3 = myReader["thursday3"].ToString();
                            model.thursday4 = myReader["thursday4"].ToString();
                            model.thursday5 = myReader["thursday5"].ToString();
                            model.thursday6 = myReader["thursday6"].ToString();
                            model.thursday7 = myReader["thursday7"].ToString();
                            model.thursday8 = myReader["thursday8"].ToString();
                            model.thursday9 = myReader["thursday9"].ToString();
                            model.thursday10 = myReader["thursday10"].ToString();

                            model.friday1 = myReader["friday1"].ToString();
                            model.friday2 = myReader["friday2"].ToString();
                            model.friday3 = myReader["friday3"].ToString();
                            model.friday4 = myReader["friday4"].ToString();
                            model.friday5 = myReader["friday5"].ToString();
                            model.friday6 = myReader["friday6"].ToString();
                            model.friday7 = myReader["friday7"].ToString();
                            model.friday8 = myReader["friday8"].ToString();
                            model.friday9 = myReader["friday9"].ToString();
                            model.friday10 = myReader["friday10"].ToString();

                            model.saturday1 = myReader["saturday1"].ToString();
                            model.saturday2 = myReader["saturday2"].ToString();
                            model.saturday3 = myReader["saturday3"].ToString();
                            model.saturday4 = myReader["saturday4"].ToString();
                            model.saturday5 = myReader["saturday5"].ToString();
                            model.saturday6 = myReader["saturday6"].ToString();
                            model.saturday7 = myReader["saturday7"].ToString();
                            model.saturday8 = myReader["saturday8"].ToString();
                            model.saturday9 = myReader["saturday9"].ToString();
                            model.saturday10 = myReader["saturday10"].ToString();

                            model.sunday1 = myReader["sunday1"].ToString();
                            model.sunday2 = myReader["sunday2"].ToString();
                            model.sunday3 = myReader["sunday3"].ToString();
                            model.sunday4 = myReader["sunday4"].ToString();
                            model.sunday5 = myReader["sunday5"].ToString();
                            model.sunday6 = myReader["sunday6"].ToString();
                            model.sunday7 = myReader["sunday7"].ToString();
                            model.sunday8 = myReader["sunday8"].ToString();
                            model.sunday9 = myReader["sunday9"].ToString();
                            model.sunday10 = myReader["sunday10"].ToString();

                            list.Add(model);
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

        public static List<Models.TodaysLunchModel> Read(int year, int week)
        {
            var list = GetTodaysLunchModels();
            return list.Where(x => x.year == year.ToString() && x.week == week.ToString()).ToList();
        }

        public static void Create(Models.TodaysLunchModel model)
        {

        }
        //public static void Update(Models.TodaysLunchModel model)
        //{

        //}
        
        //public static void UpdateStatus(int id, string status)
        //public static void Update(Models.TodaysLunchModel model)
        //{
        //    string connString = DatabaseManager.GetConnectionstring();
        //    MySqlConnection conn = new MySqlConnection(connString);
        //    conn.Open();
        //    MySqlCommand comm = conn.CreateCommand();
        //    comm.CommandText = "UPDATE cateringorder SET status='" + status + "' WHERE id=@id;";
        //    comm.Parameters.AddWithValue("@id", id);
        //    comm.ExecuteNonQuery();
        //    conn.Close();
        //}


        public static void Delete(int id)
        {

        }
    }
}