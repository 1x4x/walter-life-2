using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DatabaseCreater.Manager
{
    internal class DatabaseManager
    {
        public static string GetConnectionstring()
        {
            // Production: Loopia mysql database
            //return "Server=mysql690.loopia.se;Database=goblinbot_se;Port=3306;User ID=e003574a@g361575;Password=gladastarnograven1!;Charset=utf8";
            // root@localhost:3306
            // Dev: Local mysql database on mysql computer
            //return "Server=localhost;Database=goblinbot_se;Port=3306;User ID=e003574a@g361575;Password=gladastarnograven1!;Charset=utf8";
            // local mysql database

            // PHPMyAdmin   https://phpmyadmin181.loopia.se/
            string connectionstring = "";
            //if (!true)
            if (true)
            {
                //connectionstring = WebConfigurationManager.AppSettings["connectionstringEKPROD"];
                return "Server=127.0.0.1;Database=1w4w;Port=3306;User ID=1w4wuser;Password=JOKER!P0KERzzz;Charset=utf8";
            }
            else
            {
                //connectionstring = WebConfigurationManager.AppSettings["connectionstringEKDEV"];
                return "Server=mysql181.loopia.se; Database=energikallan_net; Port=3306;User ID=ek@e368337;Password=I8as!A4dB!5NfajoIreG;Charset=utf8";
            }
            //return connectionstring;
            // Production: Loopia mysql database
            //return "Server=mysql690.loopia.se;Database=goblinbot_se;Port=3306;User ID=e003574a@g361575;Password=gladastarnograven1!;Charset=utf8";
            //return "Server=mysql531.loopia.se;Database=chrillesrestaurang_se;Port=3306;User ID=chrilles@c368952;Password=Chrilles2020;Charset=utf8";
            //return "Server=mysql181.loopia.se; Database=energikallan_net; Port=3306;User ID=ek@e368337; Password =Chrilles2020;Charset=utf8";
            //return "Server=mysql690.loopia.se;Database=goblinbot_se;Port=3306;User ID=e003574a@g361575;Password=gladastarnograven1!;Charset=utf8";
            // root@localhost:3306
            // Dev: Local mysql database on mysql computer
            //return "Server=localhost;Database=goblinbot_se;Port=3306;User ID=e003574a@g361575;Password=gladastarnograven1!;Charset=utf8";
        }
        #region util
        public static string GetAllDatabasesSql()
        {
            // mysql get all databases
            var sql = "SELECT DISTINCT SCHEMA_NAME AS `database`";
            sql += "FROM information_schema.SCHEMATA";
            sql += "WHERE SCHEMA_NAME NOT IN('information_schema', 'performance_schema', 'mysql')";
            sql += "ORDER BY SCHEMA_NAME";
            return sql;
        }
        public static string GetAllTablesSql()
        {
            // mysql get all tables
            var sql = "SELECT TABLE_SCHEMA AS `database`,";
            sql += "TABLE_NAME AS `table`";
            sql += "FROM information_schema.TABLES";
            sql += " WHERE TABLE_TYPE = 'BASE TABLE'";
            sql += " ORDER BY TABLE_SCHEMA, TABLE_NAME";
            return sql;
        }
        #endregion util

        //private static IEnumerable<IDataRecord> SqlRetrieve(string ConnectionString, 
        //    string StoredProcName, Action<SqlCommand> AddParameters)
        //{
        //    using (var cn = new SqlConnection(ConnectionString))
        //    using (var cmd = new SqlCommand(StoredProcName, cn))
        //    {
        //        cn.Open();
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        if (AddParameters != null)
        //        {
        //            AddParameters(cmd);
        //        }

        //        using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        //        {
        //            while (rdr.Read())
        //                yield return rdr;
        //        }
        //    }
        //}


        //public static IEnumerable<IDataRecord> DbQueryToArray(string connectionString, string sql)
        //{
        //    if (null == sql)
        //        throw new ArgumentNullException(nameof(sql));

        //    string SqlCString = connectionString;
        //    using (MySqlConnection connection = new MySqlConnection(SqlCString))
        //    {
        //        connection.Open();
        //        if (connection == null)
        //            throw new Exception("Db's down.");

        //        using (MySqlCommand command = new MySqlCommand(sql, connection))
        //        {
        //            using (MySqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    yield return reader as IDataRecord;
        //                }
        //            }
        //        }
        //        if (connection != null)
        //            connection.Close();
        //    }
        //}
        //var table_1 = DbQueryToArray(SQL_Conn_String.ConnString, query1);
        //var table_2 = DbQueryToArray(SQL_Conn_String.ConnString, query2);




        //public string GetConnectionstring()
        //{
        //    //string myConnection = "Server=localhost;Database=data;Port=3306;User ID=root;Password=;Charset=utf8";
        //    //string myConnection = "Server=mysql690.loopia.se;Database=goblinbot_se;Port=3306;User ID=e003574a@g361575;Password=Gladastarnograven1!;Charset=utf8";
        //    //private string connectionString = @"server=(local)\SQLExpress;database=Northwind;integrated Security=SSPI;";
        //    //private string connectionString = @"server=81.95.105.76; database=multidatabase; User Id=e003574a; Password=Gladastarnograven1!; integrated Security=SSPI;";
        //    return _1w4w.CMS.Manager.DatabaseManager.GetConnectionstring();
        //}
    }
}
