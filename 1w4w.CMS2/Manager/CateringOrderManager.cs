using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class CateringOrderManager
    {
        public static List<Models.CateringOrderModel> GetCateringOrderList()
        {
            var list = new List<_1w4w.CMS.Models.CateringOrderModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM cateringorder ORDER BY id ASC";
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
                            var model = new Models.CateringOrderModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.status = myReader["status"].ToString();
                            model.created = myReader["created"].ToString();
                            model.updated = myReader["updated"].ToString();
                            model.fullname = myReader["fullname"].ToString();
                            model.address = myReader["address"].ToString();
                            model.zipcode = myReader["zipcode"].ToString();
                            model.orgnr = myReader["orgnr"].ToString();
                            model.phone = myReader["phone"].ToString();
                            model.email = myReader["email"].ToString();
                            model.city = myReader["city"].ToString();
                            list.Add(model);
                        }
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
        public static List<Models.CateringOrderRowModel> GetCateringOrderRowList()
        {
            var list = new List<_1w4w.CMS.Models.CateringOrderRowModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM cateringorderrow ORDER BY id ASC";
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
                    //cmd.CommandText = "select * from page";
                
                    //conDatabase.Open();
                    //myReader = cmdDataBase.ExecuteReader();
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new Models.CateringOrderRowModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.orderid = Convert.ToInt32(myReader["orderid"]);
                            model.productid = Convert.ToInt32(myReader["productid"]);
                            model.status = myReader["status"].ToString();
                            model.created = myReader["created"].ToString();
                            model.updated = myReader["updated"].ToString();
                            model.amount = Convert.ToInt32(myReader["amount"]);
                            model.artnr = myReader["artnr"].ToString();
                            model.name = myReader["name"].ToString();
                            list.Add(model);
                        }
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
        

        //public static int Create(string name, string address, string zipcode, string orgnr, 
        public static int Create(CateringOrderModel order)
        //public static void Create(int id, int amount, string artnr, string name)
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



                var sql = "";
                sql += "INSERT INTO cateringorder (created, fullname,address,zipcode,city,orgnr,phone,email,status) ";
                sql += "VALUES (" +
                    "'" + DateTime.Now.ToString() + "'," +
                    "'" + order.fullname + "'," +
                    "'" + order.address + "'," +
                    "'" + order.zipcode + "'," +
                    "'" + order.city + "'," +
                    "'" + order.orgnr + "'," +
                    "'" + order.phone + "'," +
                    "'" + order.email + "'," +
                    "'" + "ordered" + "');";


                cmd.CommandText = sql;
            

            
            //Console.WriteLine(sql);
            //MySqlCommand cmd = new MySqlCommand(sql, conn);

            // INSERT INTO order (name, address, zipcode, city, orgnr, phone, email) VALUES ('Walter Schötz','Granängsringen 22','13544','Tyresö','123','08123456','nisse@lisse.se')
            // INSERT INTO order (name, address, zipcode, city, orgnr, phone, email) VALUES ('Walter Schötz','Granängsringen 22', '13544', 'Tyresö', '123', '08123456', 'nisse@lisse.se');

            //sql += "VALUES(@name, @address, @zipcode, @city, @orgnr, @phone, @email";
            //sql += ")";
            //cmd.CommandText = sql;
            //comm.Parameters.AddWithValue("@id", newhighestid);
            //comm.Parameters.AddWithValue("@name", name);
            //comm.Parameters.AddWithValue("@address", address);
            //comm.Parameters.AddWithValue("@zipcode", zipcode);
            //comm.Parameters.AddWithValue("@orgnr", orgnr);
            //comm.Parameters.AddWithValue("@phone", phone);
            //comm.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
                //cmd.Close();

                // 
                //return GetHighestId();
            }
            return newhighestid;
        }
        
        public static int CreateOrderRow(int orderid, int productid, int amount, string artnr, string name)
        {
            int newhighestid = (GetHighestOrderrowId() + 1);
            //string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            var sql = "";
            sql += "INSERT INTO cateringorderrow (created, orderid, productid, status, amount, artnr, name) ";
            //sql += "VALUES (id, orderid, amount, artnr, name)";
            sql += "VALUES (" +
                "'" + DateTime.Now.ToString() + "'," +
                "'" + orderid + "'," +
                "'" + productid + "'," +
                "'" + "delivered" + "'," +
                "'" + amount + "'," +
                "'" + artnr + "'," +
                "'" + name + "'" +
                ");";
            //sql += "VALUES (@id, @orderid, @amount, @artnr, @name)";

            //comm.CommandText = sql;
            //comm.Parameters.AddWithValue("@id", newhighestid);
            //comm.Parameters.AddWithValue("@orderid", orderid);
            //comm.Parameters.AddWithValue("@amount", amount);
            //comm.Parameters.AddWithValue("@artnr", artnr);
            //comm.Parameters.AddWithValue("@name", name);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

            //MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.ExecuteNonQuery();
            return newhighestid;
        }


        public static void UpdateStatus(int id, string status)
        {
            string connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                //cmd.CommandText = "select * from page";
                cmd.CommandText = "UPDATE cateringorder SET status='" + status + "' WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            //comm.CommandText = "UPDATE cateringorder SET status='" + status + "' WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", id);
            
            //conn.Close();
        }

        public void Delete(int id)
        {
            //tring connString = DatabaseManager.GetConnectionstring();
            //MySqlConnection conn = new MySqlConnection(connString);
            //conn.Open();
            //MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "DELETE FROM cateringorder WHERE id=@id;";
            //comm.Parameters.AddWithValue("@id", id);
            //comm.ExecuteNonQuery();
            //conn.Close();

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM cateringorder WHERE id=@id;"; ;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        // Nisseluring123!
        static public int GetHighestId()
        {
            var list = new List<_1w4w.CMS.Models.CateringOrderModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM cateringorder";
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

                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new CateringOrderModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            list.Add(model);
                        }
                    }
                    return Convert.ToInt32(myReader["id"]);
                }
                //conDatabase.Open();
                //myReader = cmdDataBase.ExecuteReader();
                
            }
            catch
            {
                return 0;
            }
        }

        static public int GetHighestOrderrowId()
        {
            var list = new List<_1w4w.CMS.Models.CateringOrderModel>();
            //string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM cateringorderrow";
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
                            var model = new CateringOrderModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            list.Add(model);
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
    }
}