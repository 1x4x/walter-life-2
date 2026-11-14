using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class MonthManager
    {
        public List<Models.MonthModel> GetList()
        {
            var list = new List<Models.MonthModel>();
            string query = "SELECT * FROM ttmonth;";
            MySqlDataReader myReader;
            try
            {
                var constr = DatabaseManager.GetConnectionstring();
                using (var con = new MySqlConnection(constr))
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = query;


                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            var model = new Models.MonthModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.userid = Convert.ToInt32(myReader["userid"]);

                            model.year = Convert.ToInt32(myReader["year"]);

                            model.janretrospect = myReader["janretrospect"].ToString();
                            model.janextracosts = myReader["janextracosts"].ToString();
                            model.janbirthdays = myReader["janbirthdays"].ToString();

                            model.febretrospect = myReader["febretrospect"].ToString();
                            model.febextracosts = myReader["febextracosts"].ToString();
                            model.febbirthdays = myReader["febbirthdays"].ToString();

                            model.marretrospect = myReader["marretrospect"].ToString();
                            model.marextracosts = myReader["marextracosts"].ToString();
                            model.marbirthdays = myReader["marbirthdays"].ToString();

                            model.aprretrospect = myReader["aprretrospect"].ToString();
                            model.aprextracosts = myReader["aprextracosts"].ToString();
                            model.aprbirthdays = myReader["aprbirthdays"].ToString();

                            model.mayretrospect = myReader["mayretrospect"].ToString();
                            model.mayextracosts = myReader["mayextracosts"].ToString();
                            model.maybirthdays = myReader["maybirthdays"].ToString();

                            model.junretrospect = myReader["junretrospect"].ToString();
                            model.junextracosts = myReader["junextracosts"].ToString();
                            model.junbirthdays = myReader["junbirthdays"].ToString();

                            model.julretrospect = myReader["julretrospect"].ToString();
                            model.julextracosts = myReader["julextracosts"].ToString();
                            model.julbirthdays = myReader["julbirthdays"].ToString();

                            model.augretrospect = myReader["augretrospect"].ToString();
                            model.augextracosts = myReader["augextracosts"].ToString();
                            model.augbirthdays = myReader["augbirthdays"].ToString();

                            model.sepretrospect = myReader["sepretrospect"].ToString();
                            model.sepextracosts = myReader["sepextracosts"].ToString();
                            model.sepbirthdays = myReader["sepbirthdays"].ToString();

                            model.octretrospect = myReader["octretrospect"].ToString();
                            model.octextracosts = myReader["octextracosts"].ToString();
                            model.octbirthdays = myReader["octbirthdays"].ToString();

                            model.novretrospect = myReader["novretrospect"].ToString();
                            model.novextracosts = myReader["novextracosts"].ToString();
                            model.novbirthdays = myReader["novbirthdays"].ToString();

                            model.decretrospect = myReader["decretrospect"].ToString();
                            model.decextracosts = myReader["decextracosts"].ToString();
                            model.decbirthdays = myReader["decbirthdays"].ToString();

                            model.text = myReader["text"].ToString();
                            model.color = myReader["color"].ToString();

                            list.Add(model);
                        }
                    }
                    return list;
                }

            }
            catch
            {
                throw;
            }
        }

        public static string[] GetMonths()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string[] array = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Nov", "Dec" };
            return array;
        }
    }
}