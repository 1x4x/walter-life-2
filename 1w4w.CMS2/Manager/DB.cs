using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace _1w4w.CMS.Manager
{
    public static class DB
    {
        //private static string ConnString => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //public static MySqlConnection GetConn()
        //{
        //    var c = new MySqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString); c.Open(); return c;
        //}
        public static MySqlConnection GetConn()
        {
            var constr = HttpContext.Current.Request.IsLocal == true ? WebConfigurationManager.AppSettings["dev"] : WebConfigurationManager.AppSettings["prod"];
            var c = new MySqlConnection(constr); 
            c.Open();
            return c;
        }
        //public static string GetConn()
        //{
        //    string c = "";
        //    if (HttpContext.Current.Request.IsLocal)
        //    {
        //        c = WebConfigurationManager.AppSettings["dev"];
        //    }
        //    else
        //    {
        //        c = WebConfigurationManager.AppSettings["prod"];
        //    }
        //    return c;
        //}
        public static DataTable ExecuteDataTable(string sql, params MySqlParameter[] parameters)
        {
            using (var conn = GetConn())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (var da = new MySqlDataAdapter(cmd)) { var dt = new DataTable(); da.Fill(dt); return dt; }
            }
        }
        public static int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (var conn = GetConn())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
        public static object ExecuteScalar(string sql, params MySqlParameter[] parameters)
        {
            using (var conn = GetConn())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

    }
}