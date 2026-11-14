using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class UploadedFileCategoryManager
    {
        public List<Models.UploadedFileCategoryModel> GetUploadedFileCategoryList()
        {
            var list = new List<_1w4w.CMS.Models.UploadedFileCategoryModel>();
            string query = "SELECT * FROM uploadedimagecategory;";
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
                            var model = new UploadedFileCategoryModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.websiteid = Convert.ToInt32(myReader["websiteid"]);
                            model.name = myReader["name"].ToString();
                            list.Add(model);
                        }
                    }
                    return list;
                }



            }
            catch
            {
                throw;
                //return null;
            }
        }
    }
}