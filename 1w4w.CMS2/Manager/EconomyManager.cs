using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace _1w4w.CMS.Manager
{
    public class EconomyManager
    {
        public static string GetServerPartFromConnectionstring()
        {
            // Retrieve the ConnectionString from App.config 
            string connectString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);
            // Retrieve the DataSource property.    
            string ip = builder.DataSource;
            return ip;
        }

        /*
         https://chatgpt.com/c/68f3c4c2-597c-8333-b064-1d31c256bffc

SELECT
    DATE_FORMAT(updateddate, '%Y-%m') AS month,
    SUM(CASE WHEN amount > 0 THEN amount ELSE 0 END) AS total_income,
    COUNT(CASE WHEN amount > 0 THEN 1 END) AS income_count,
    SUM(CASE WHEN amount < 0 THEN amount ELSE 0 END) AS total_cost,
    COUNT(CASE WHEN amount < 0 THEN 1 END) AS cost_count,
    SUM(amount) AS net_balance
FROM economy
GROUP BY DATE_FORMAT(updateddate, '%Y-%m')
ORDER BY month;
         */
        public static int ConvertToPositive(int i)
        {
            return (i + (i >> 31)) ^ (i >> 31);
        }

        //var dt = DB.ExecuteDataTable("SELECT Id, UserId, Title FROM Boards WHERE Id=@id AND UserId=@uid", new MySqlParameter("@id", id), new MySqlParameter("@uid", CurrentUserId));
        public static List<Models.EconomyTransactionModel> GetEconomyTransactionList(string year1)
        {
            var dt = DB.ExecuteDataTable("SELECT * FROM economytransaction WHERE year1=@year1 ORDER BY id ASC", new MySqlParameter("@year1", year1));
            if (dt.Rows.Count == 0) return null;
            var list = new List<EconomyTransactionModel>();
            foreach (DataRow r in dt.Rows) list.Add(new EconomyTransactionModel { 
                id = Convert.ToInt32(r["id"]),
                year1 = r.Field<int?>("year1") ?? 0,

                text1 = r.Field<string>("text1") ?? "",
                economytype = r.Field<string>("economytype") ?? "",

                janamount = r.Field<int?>("janamount") ?? 0,
                febamount = r.Field<int?>("febamount") ?? 0,
                maramount = r.Field<int?>("maramount") ?? 0,
                apramount = r.Field<int?>("apramount") ?? 0,
                mayamount = r.Field<int?>("mayamount") ?? 0,
                junamount = r.Field<int?>("junamount") ?? 0,
                julamount = r.Field<int?>("julamount") ?? 0,
                augamount = r.Field<int?>("augamount") ?? 0,
                sepamount = r.Field<int?>("sepamount") ?? 0,
                octamount = r.Field<int?>("octamount") ?? 0,
                novamount = r.Field<int?>("novamount") ?? 0,
                decamount = r.Field<int?>("decamount") ?? 0,

                jantext = r.Field<string>("jantext") ?? "",
                febtext = r.Field<string>("febtext") ?? "",
                martext = r.Field<string>("martext") ?? "",
                aprtext = r.Field<string>("aprtext") ?? "",
                maytext = r.Field<string>("maytext") ?? "",
                juntext = r.Field<string>("juntext") ?? "",
                jultext = r.Field<string>("jultext") ?? "",
                augtext = r.Field<string>("augtext") ?? "",
                septext = r.Field<string>("septext") ?? "",
                octtext = r.Field<string>("octtext") ?? "",
                novtext = r.Field<string>("novtext") ?? "",
                dectext = r.Field<string>("dectext") ?? "",
            });
            return list;
        }
        
        public static List<Models.EconomyTransactionModel> GetEconomyTransactionList2(string year)
        {


            var list = new List<_1w4w.CMS.Models.EconomyTransactionModel>();
            string query = "SELECT * FROM economytransaction WHERE year1=" + year + " ORDER BY id ASC";
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
                            var model = new EconomyTransactionModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.year1 = Convert.ToInt32(myReader["year1"]);
                            if (myReader["text1"] != System.DBNull.Value)
                                model.text1 = myReader["text1"].ToString();

                            model.economytype = myReader["economytype"].ToString();

                            model.janamount = Convert.ToInt32(myReader["janamount"]);
                            model.febamount = Convert.ToInt32(myReader["febamount"]);
                            model.maramount = Convert.ToInt32(myReader["maramount"]);
                            model.apramount = Convert.ToInt32(myReader["apramount"]);
                            model.mayamount = Convert.ToInt32(myReader["mayamount"]);
                            model.junamount = Convert.ToInt32(myReader["junamount"]);
                            model.julamount = Convert.ToInt32(myReader["julamount"]);
                            model.augamount = Convert.ToInt32(myReader["augamount"]);
                            model.sepamount = Convert.ToInt32(myReader["sepamount"]);
                            model.octamount = Convert.ToInt32(myReader["octamount"]);
                            model.novamount = Convert.ToInt32(myReader["novamount"]);
                            model.decamount = Convert.ToInt32(myReader["decamount"]);
                            if (myReader["jantext"] != System.DBNull.Value) model.jantext = myReader["jantext"].ToString();
                            if (myReader["febtext"] != System.DBNull.Value) model.febtext = myReader["febtext"].ToString();
                            if (myReader["martext"] != System.DBNull.Value) model.martext = myReader["martext"].ToString();
                            if (myReader["aprtext"] != System.DBNull.Value) model.aprtext = myReader["aprtext"].ToString();
                            if (myReader["maytext"] != System.DBNull.Value) model.maytext = myReader["maytext"].ToString();
                            if (myReader["juntext"] != System.DBNull.Value) model.juntext = myReader["juntext"].ToString();
                            if (myReader["jultext"] != System.DBNull.Value) model.jultext = myReader["jultext"].ToString();
                            if (myReader["augtext"] != System.DBNull.Value) model.augtext = myReader["augtext"].ToString();
                            if (myReader["septext"] != System.DBNull.Value) model.septext = myReader["septext"].ToString();
                            if (myReader["octtext"] != System.DBNull.Value) model.octtext = myReader["octtext"].ToString();
                            if (myReader["novtext"] != System.DBNull.Value) model.novtext = myReader["novtext"].ToString();
                            if (myReader["dectext"] != System.DBNull.Value) model.dectext = myReader["dectext"].ToString();

                            list.Add(model);
                        }
                    }
                    else
                    {
                        // if no page exists yet create 1 to be nice to the user :)
                        var model = new EconomyTransactionModel();
                        //model.id = Convert.ToInt32("1");
                        model.year1 = Convert.ToInt32(DateTime.Now.Year);


                        
                        new EconomyManager().CreateEconomyTransaction(model);

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

        
        public static int GetEconomyEventCount(string year1)
        {
            int count = 0;
            var list = new List<_1w4w.CMS.Models.EconomyEventModel>();
            string query = "SELECT * FROM economyevent WHERE year1='" + year1 + "' ORDER BY id ASC";
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
                            count++;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                    return count;
                }
                catch
                {
                    throw;
                    //return null;
                }
            }
        }

        public static List<Models.EconomyEventModel> GetEconomyEventList()
        {


            var list = new List<_1w4w.CMS.Models.EconomyEventModel>();
            string query = "SELECT * FROM economyevent ORDER BY id ASC";
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
                            var model = new EconomyEventModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.year1 = Convert.ToInt32(myReader["year1"]);
                            if (myReader["text1"] != System.DBNull.Value) 
                                model.text1 = myReader["text1"].ToString();

                            if (myReader["janamount"] != System.DBNull.Value)
                                model.jantext = myReader["jantext"].ToString();

                            model.janamount = Convert.ToInt32(myReader["janamount"]);
                            

                            model.febamount = Convert.ToInt32(myReader["febamount"]);
                            if (myReader["febtext"] != System.DBNull.Value)
                                model.febtext = myReader["febtext"].ToString();

                            model.maramount = Convert.ToInt32(myReader["maramount"]);
                            if (myReader["martext"] != System.DBNull.Value)
                                model.martext = myReader["martext"].ToString();

                            model.apramount = Convert.ToInt32(myReader["apramount"]);
                            if (myReader["aprtext"] != System.DBNull.Value)
                                model.aprtext = myReader["aprtext"].ToString();

                            model.mayamount = Convert.ToInt32(myReader["mayamount"]);
                            if (myReader["maytext"] != System.DBNull.Value)
                                model.maytext = myReader["maytext"].ToString();

                            model.junamount = Convert.ToInt32(myReader["junamount"]);
                            if (myReader["juntext"] != System.DBNull.Value)
                                model.juntext = myReader["juntext"].ToString();

                            model.julamount = Convert.ToInt32(myReader["julamount"]);
                            if (myReader["jultext"] != System.DBNull.Value)
                                model.jultext = myReader["jultext"].ToString();

                            model.augamount = Convert.ToInt32(myReader["augamount"]);
                            if (myReader["augtext"] != System.DBNull.Value)
                                model.augtext = myReader["augtext"].ToString();

                            model.sepamount = Convert.ToInt32(myReader["sepamount"]);
                            if (myReader["septext"] != System.DBNull.Value)
                                model.septext = myReader["septext"].ToString();

                            model.octamount = Convert.ToInt32(myReader["octamount"]);
                            if (myReader["octtext"] != System.DBNull.Value)
                                model.octtext = myReader["octtext"].ToString();

                            model.novamount = Convert.ToInt32(myReader["novamount"]);
                            if (myReader["novtext"] != System.DBNull.Value)
                                model.novtext = myReader["novtext"].ToString();

                            model.decamount = Convert.ToInt32(myReader["decamount"]);
                            if (myReader["dectext"] != System.DBNull.Value)
                                model.dectext = myReader["dectext"].ToString();

                            list.Add(model);
                        }
                    }
                    else
                    {
                        // if no page exists yet create 1 to be nice to the user :)
                        var model = new EconomyEventModel();
                        //model.id = Convert.ToInt32("1");
                        model.year1 = Convert.ToInt32(DateTime.Now.Year);
                        
                        

                        new EconomyManager().Create(model);

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

        public int GetHighestId()
        {
            var list = new List<_1w4w.CMS.Models.EconomyEventModel>();
            MySqlDataReader myReader;

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from economyevent";
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new EconomyEventModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.year1 = Convert.ToInt32(myReader["year1"]);
                            if (myReader["text1"] != System.DBNull.Value) 
                                model.text1 = myReader["text1"].ToString();
                            
                            model.jantext = myReader["jantext"].ToString();
                            model.janamount = Convert.ToInt32(myReader["janamount"]);

                            model.febtext = myReader["febtext"].ToString();
                            model.febamount = Convert.ToInt32(myReader["febamount"]);

                            model.martext = myReader["martext"].ToString();
                            model.maramount = Convert.ToInt32(myReader["maramount"]);

                            model.aprtext = myReader["aprtext"].ToString();
                            model.apramount = Convert.ToInt32(myReader["apramount"]);

                            model.maytext = myReader["maytext"].ToString();
                            model.mayamount = Convert.ToInt32(myReader["mayamount"]);

                            model.juntext = myReader["juntext"].ToString();
                            model.junamount = Convert.ToInt32(myReader["junamount"]);

                            model.jultext = myReader["jultext"].ToString();
                            model.julamount = Convert.ToInt32(myReader["julamount"]);

                            model.augtext = myReader["augtext"].ToString();
                            model.augamount = Convert.ToInt32(myReader["augamount"]);

                            model.septext = myReader["septext"].ToString();
                            model.sepamount = Convert.ToInt32(myReader["sepamount"]);

                            model.octtext = myReader["octtext"].ToString();
                            model.octamount = Convert.ToInt32(myReader["octamount"]);

                            model.novtext = myReader["novtext"].ToString();
                            model.novamount = Convert.ToInt32(myReader["novamount"]);

                            model.dectext = myReader["dectext"].ToString();
                            model.decamount = Convert.ToInt32(myReader["decamount"]);


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
        public int Create(_1w4w.CMS.Models.EconomyEventModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var sql = "";
                sql += "INSERT INTO economyevent(id, year1, text1";
                sql += ", jantext, janamount ";
                sql += ", febtext, febamount ";
                sql += ", martext, maramount ";
                sql += ", aprtext, apramount ";
                sql += ", maytext, mayamount ";
                sql += ", juntext, junamount ";
                sql += ", jultext, julamount ";
                sql += ", augtext, augamount ";
                sql += ", septext, sepamount ";
                sql += ", octtext, octamount ";
                sql += ", novtext, novamount ";
                sql += ", dectext, decamount ";
                sql += ") ";

                sql += " VALUES(@id, @year1, text1";
                sql += ", @jantext, @janamount";
                sql += ", @febtext, @febamount";
                sql += ", @martext, @maramount";
                sql += ", @aprtext, @apramount";
                sql += ", @maytext, @mayamount";
                sql += ", @juntext, @junamount";
                sql += ", @jultext, @julamount";
                sql += ", @augtext, @augamount";
                sql += ", @septext, @sepamount";
                sql += ", @octtext, @octamount";
                sql += ", @novtext, @novamount";
                sql += ", @dectext, @decamount";
                sql += ")";
                cmd.CommandText = sql;
                //comm.CommandText = sql;
                var id = model.id.ToString() ?? "";
                var year1 = model.year1.ToString() ?? "";
                var text1 = model.text1.ToString() ?? "";

                string jantext = model.jantext ?? "";
                int janamount = model.janamount;

                string febtext = model.febtext ?? "";
                int febamount = model.febamount;

                string martext = model.martext ?? "";
                int maramount = model.maramount;

                string aprtext = model.aprtext ?? "";
                int apramount = model.apramount;

                string maytext = model.maytext ?? "";
                int mayamount = model.mayamount;

                string juntext = model.juntext ?? "";
                int junamount = model.junamount;

                string jultext = model.jultext ?? "";
                int julamount = model.julamount;

                string augtext = model.augtext ?? "";
                int augamount = model.augamount;

                string septext = model.septext ?? "";
                int sepamount = model.sepamount;

                string octtext = model.octtext ?? "";
                int octamount = model.octamount;

                string novtext = model.novtext ?? "";
                int novamount = model.novamount;

                string dectext = model.dectext ?? "";
                int decamount = model.decamount;




                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@year1", model.year1);
                cmd.Parameters.AddWithValue("@text1", model.text1);
                
                cmd.Parameters.AddWithValue("@jantext", jantext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@janamount", janamount);

                cmd.Parameters.AddWithValue("@febtext", febtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@febamount", febamount);

                cmd.Parameters.AddWithValue("@martext", martext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@maramount", maramount);

                cmd.Parameters.AddWithValue("@aprtext", aprtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@apramount", apramount);

                cmd.Parameters.AddWithValue("@maytext", maytext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@mayamount", mayamount);

                cmd.Parameters.AddWithValue("@juntext", juntext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@junamount", junamount);

                cmd.Parameters.AddWithValue("@jultext", jultext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@julamount", julamount);

                cmd.Parameters.AddWithValue("@augtext", augtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@augamount", augamount);

                cmd.Parameters.AddWithValue("@septext", septext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@sepamount", sepamount);

                cmd.Parameters.AddWithValue("@octtext", octtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@octamount", octamount);

                cmd.Parameters.AddWithValue("@novtext", novtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@novamount", novamount);

                cmd.Parameters.AddWithValue("@dectext", dectext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@decamount", decamount);


                var createdid = cmd.ExecuteNonQuery();
                //con.Close();
                return createdid;
            }
        }
        
        
        public int CreateEconomyTransaction(_1w4w.CMS.Models.EconomyTransactionModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var sql = "";
                sql += "INSERT INTO economytransaction(id, year1, text1, economytype";
                sql += ", jantext, janamount ";
                sql += ", febtext, febamount ";
                sql += ", martext, maramount ";
                sql += ", aprtext, apramount ";
                sql += ", maytext, mayamount ";
                sql += ", juntext, junamount ";
                sql += ", jultext, julamount ";
                sql += ", augtext, augamount ";
                sql += ", septext, sepamount ";
                sql += ", octtext, octamount ";
                sql += ", novtext, novamount ";
                sql += ", dectext, decamount ";
                sql += ") ";

                sql += " VALUES(@id, @year1, text1, @economytype";
                sql += ", @jantext, @janamount";
                sql += ", @febtext, @febamount";
                sql += ", @martext, @maramount";
                sql += ", @aprtext, @apramount";
                sql += ", @maytext, @mayamount";
                sql += ", @juntext, @junamount";
                sql += ", @jultext, @julamount";
                sql += ", @augtext, @augamount";
                sql += ", @septext, @sepamount";
                sql += ", @octtext, @octamount";
                sql += ", @novtext, @novamount";
                sql += ", @dectext, @decamount";
                sql += ")";
                cmd.CommandText = sql;
                //comm.CommandText = sql;
                var id = model.id.ToString() ?? "";
                var year1 = model.year1.ToString() ?? "";
                var text1 = model.text1.ToString() ?? "";
                var economytype = model.economytype.ToString() ?? "";

                string jantext = model.jantext ?? "";
                int janamount = model.janamount;

                string febtext = model.febtext ?? "";
                int febamount = model.febamount;

                string martext = model.martext ?? "";
                int maramount = model.maramount;

                string aprtext = model.aprtext ?? "";
                int apramount = model.apramount;

                string maytext = model.maytext ?? "";
                int mayamount = model.mayamount;

                string juntext = model.juntext ?? "";
                int junamount = model.junamount;

                string jultext = model.jultext ?? "";
                int julamount = model.julamount;

                string augtext = model.augtext ?? "";
                int augamount = model.augamount;

                string septext = model.septext ?? "";
                int sepamount = model.sepamount;

                string octtext = model.octtext ?? "";
                int octamount = model.octamount;

                string novtext = model.novtext ?? "";
                int novamount = model.novamount;

                string dectext = model.dectext ?? "";
                int decamount = model.decamount;




                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@year1", model.year1);
                cmd.Parameters.AddWithValue("@text1", model.text1);
                cmd.Parameters.AddWithValue("@economytype", model.economytype);

                cmd.Parameters.AddWithValue("@jantext", jantext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@janamount", janamount);

                cmd.Parameters.AddWithValue("@febtext", febtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@febamount", febamount);

                cmd.Parameters.AddWithValue("@martext", martext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@maramount", maramount);

                cmd.Parameters.AddWithValue("@aprtext", aprtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@apramount", apramount);

                cmd.Parameters.AddWithValue("@maytext", maytext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@mayamount", mayamount);

                cmd.Parameters.AddWithValue("@juntext", juntext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@junamount", junamount);

                cmd.Parameters.AddWithValue("@jultext", jultext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@julamount", julamount);

                cmd.Parameters.AddWithValue("@augtext", augtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@augamount", augamount);

                cmd.Parameters.AddWithValue("@septext", septext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@sepamount", sepamount);

                cmd.Parameters.AddWithValue("@octtext", octtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@octamount", octamount);

                cmd.Parameters.AddWithValue("@novtext", novtext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@novamount", novamount);

                cmd.Parameters.AddWithValue("@dectext", dectext.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@decamount", decamount);


                var createdid = cmd.ExecuteNonQuery();
                //con.Close();
                return createdid;
            }
        }

        public static string GetEconomyEventColorClass(int amount)
        {
            string colorclass = "";
            if (amount == 0) { colorclass = "text-warning"; }
            if (amount > 0) { colorclass = "text-success"; }
            if (amount < 0) { colorclass = "text-danger"; }
            return colorclass;
        }

        public static void CreateDummy(int year1)
        {
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "INSERT INTO economyevent(year1, text1,";
            sql += " jantext, janamount,";
            sql += " febtext, febamount,";
            sql += " martext, maramount,";
            sql += " aprtext, apramount,";
            sql += " maytext, mayamount,";
            sql += " juntext, junamount,";
            sql += " jultext, julamount,";
            sql += " augtext, augamount,";
            sql += " septext, sepamount,";
            sql += " octtext, octamount,";
            sql += " novtext, novamount,";
            sql += " dectext, decamount";
            sql += ")";
            sql += " VALUES(@year1, @text1,";
            sql += " @jantext, @janamount,";
            sql += " @febtext, @febamount,";
            sql += " @martext, @maramount,";
            sql += " @aprtext, @apramount,";
            sql += " @maytext, @mayamount,";
            sql += " @juntext, @junamount,";
            sql += " @jultext, @julamount,";
            sql += " @augtext, @augamount,";
            sql += " @septext, @sepamount,";
            sql += " @octtext, @octamount,";
            sql += " @novtext, @novamount,";
            sql += " @dectext, @decamount";
            sql += ");";
            comm.CommandText = sql;
            comm.Parameters.AddWithValue("@year1", year1);
            comm.Parameters.AddWithValue("@text1", " ");

            comm.Parameters.AddWithValue("@jantext", " ");
            comm.Parameters.AddWithValue("@janamount", 0);

            comm.Parameters.AddWithValue("@febtext", " ");
            comm.Parameters.AddWithValue("@febamount", 0);

            comm.Parameters.AddWithValue("@martext", " ");
            comm.Parameters.AddWithValue("@maramount", 0);

            comm.Parameters.AddWithValue("@aprtext", " ");
            comm.Parameters.AddWithValue("@apramount", 0);

            comm.Parameters.AddWithValue("@maytext", " ");
            comm.Parameters.AddWithValue("@mayamount", 0);

            comm.Parameters.AddWithValue("@juntext", " ");
            comm.Parameters.AddWithValue("@junamount", 0);

            comm.Parameters.AddWithValue("@jultext", " ");
            comm.Parameters.AddWithValue("@julamount", 0);

            comm.Parameters.AddWithValue("@augtext", " ");
            comm.Parameters.AddWithValue("@augamount", 0);

            comm.Parameters.AddWithValue("@septext", " ");
            comm.Parameters.AddWithValue("@sepamount", 0);

            comm.Parameters.AddWithValue("@octtext", " ");
            comm.Parameters.AddWithValue("@octamount", 0);

            comm.Parameters.AddWithValue("@novtext", " ");
            comm.Parameters.AddWithValue("@novamount", 0);

            comm.Parameters.AddWithValue("@dectext", " ");
            comm.Parameters.AddWithValue("@decamount", 0);

            comm.ExecuteNonQuery();
            conn.Close();
        }

        public static void Update(EconomyEventModel model)
        {
            string connString = DatabaseManager.GetConnectionstring();
            var sql = "";
            sql += "UPDATE economyevent SET";
            sql += " year1='" + Convert.ToInt32(model.year1) + "',";
            sql += " text1='" + Convert.ToInt32(model.text1) + "',";
            sql += " jantext='" + model.jantext + "',";
            sql += " janamount='" + model.janamount + "',";

            sql += " febtext='" + model.febtext + "',";
            sql += " febamount='" + model.febamount + "',";

            sql += " martext='" + model.martext + "',";
            sql += " maramount='" + model.maramount + "',";

            sql += " aprtext='" + model.aprtext + "',";
            sql += " apramount='" + model.apramount + "',";

            sql += " maytext='" + model.maytext + "',";
            sql += " mayamount='" + model.mayamount + "',";

            sql += " juntext='" + model.juntext + "',";
            sql += " junamount='" + model.junamount + "',";

            sql += " jultext='" + model.jultext + "',";
            sql += " julamount='" + model.julamount + "',";

            sql += " augtext='" + model.augtext + "',";
            sql += " augamount='" + model.augamount + "',";

            sql += " septext='" + model.septext + "',";
            sql += " sepamount='" + model.sepamount + "',";

            sql += " octtext='" + model.octtext + "',";
            sql += " octamount='" + model.octamount + "',";

            sql += " novtext='" + model.novtext + "',";
            sql += " novamount='" + model.novamount + "',";

            sql += " dectext='" + model.dectext + "',";
            sql += " decamount='" + model.decamount + "'";

            sql += " WHERE id=" + model.id + ";";
            //sql += " WHERE id=@id1;";

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@id1", model.id);
                cmd.Parameters.AddWithValue("@year1", model.year1);
                cmd.Parameters.AddWithValue("@text1", model.text1);
                cmd.Parameters.AddWithValue("@jantext", model.jantext);
                cmd.Parameters.AddWithValue("@febtext", model.febtext);
                cmd.Parameters.AddWithValue("@martext", model.martext);
                cmd.Parameters.AddWithValue("@aprtext", model.aprtext);
                cmd.Parameters.AddWithValue("@maytext", model.maytext);
                cmd.Parameters.AddWithValue("@juntext", model.juntext);
                cmd.Parameters.AddWithValue("@jultext", model.jultext);
                cmd.Parameters.AddWithValue("@augtext", model.augtext);
                cmd.Parameters.AddWithValue("@septext", model.septext);
                cmd.Parameters.AddWithValue("@octtext", model.octtext);
                cmd.Parameters.AddWithValue("@novtext", model.novtext);
                cmd.Parameters.AddWithValue("@dectext", model.dectext);

                cmd.Parameters.AddWithValue("@janamount", model.janamount);
                cmd.Parameters.AddWithValue("@febamount", model.febamount);
                cmd.Parameters.AddWithValue("@maramount", model.maramount);
                cmd.Parameters.AddWithValue("@apramount", model.apramount);
                cmd.Parameters.AddWithValue("@mayamount", model.mayamount);
                cmd.Parameters.AddWithValue("@junamount", model.junamount);
                cmd.Parameters.AddWithValue("@julamount", model.julamount);
                cmd.Parameters.AddWithValue("@augamount", model.augamount);
                cmd.Parameters.AddWithValue("@sepamount", model.sepamount);
                cmd.Parameters.AddWithValue("@octamount", model.octamount);
                cmd.Parameters.AddWithValue("@novamount", model.novamount);
                cmd.Parameters.AddWithValue("@decamount", model.decamount);

                cmd.ExecuteNonQuery();
            }

        }
    }
}