using _1w4w.CMS.Models;
using Google.Protobuf.WellKnownTypes;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore.Internal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Ubiety.Dns.Core.Common;

namespace _1w4w.CMS.Manager
{
    public class UserReadBookManager
    {
        public static List<Models.UserReadBookModel> GetUserReadBookList()
        {


            var list = new List<_1w4w.CMS.Models.UserReadBookModel>();
            string query = "SELECT * FROM userreadbook ORDER BY id ASC";
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
                            var model = new UserReadBookModel();
                            model.id = Convert.ToInt32(myReader["id"]);
                            model.userid = Convert.ToInt32(myReader["userid"]);

                            if (myReader["title"] != System.DBNull.Value)
                                model.title = myReader["title"].ToString();

                            if (myReader["authors"] != System.DBNull.Value)
                                model.authors = myReader["authors"].ToString();

                            if (myReader["isbn"] != System.DBNull.Value)
                                model.isbn = myReader["isbn"].ToString();

                            if (myReader["published"] != System.DBNull.Value)
                                model.published = myReader["published"].ToString();

                            if (myReader["language"] != System.DBNull.Value)
                                model.language = myReader["language"].ToString();




                            model.pagecount = Convert.ToInt32(myReader["pagecount"]);
                            if (myReader["pagecount"] != System.DBNull.Value)
                                model.pagecount = Convert.ToInt32(myReader["pagecount"].ToString());

                            model.currentreadingpage = Convert.ToInt32(myReader["currentreadingpage"]);
                            if (myReader["currentreadingpage"] != System.DBNull.Value)
                                model.currentreadingpage = Convert.ToInt32(myReader["currentreadingpage"].ToString());

                            if (myReader["imageurl"] != System.DBNull.Value)
                                model.imageurl = myReader["imageurl"].ToString();

                            list.Add(model);
                        }
                    }
                    else
                    {
                        // if no page exists yet create 1 to be nice to the user :)
                        var model = new UserReadBookModel();
                        model.title = "Test Book";
                        //model.id = Convert.ToInt32("1");
                        //model.year1 = Convert.ToInt32(DateTime.Now.Year);

                        new UserReadBookManager().Create(model);

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
            //var list = new List<_1w4w.CMS.Models.EconomyEventModel>();
            MySqlDataReader myReader;

            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "select * from userreadbook";
                try
                {
                    myReader = cmd.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        while (myReader.Read())
                        {
                            //var model = new EconomyEventModel();
                            //model.id = Convert.ToInt32(myReader["id"]);
                            //model.year1 = Convert.ToInt32(myReader["year1"]);
                            //if (myReader["text1"] != System.DBNull.Value)
                            //    model.text1 = myReader["text1"].ToString();

                            //model.jantext = myReader["jantext"].ToString();
                            //model.janamount = Convert.ToInt32(myReader["janamount"]);

                            //model.febtext = myReader["febtext"].ToString();
                            //model.febamount = Convert.ToInt32(myReader["febamount"]);

                            //model.martext = myReader["martext"].ToString();
                            //model.maramount = Convert.ToInt32(myReader["maramount"]);

                            //model.aprtext = myReader["aprtext"].ToString();
                            //model.apramount = Convert.ToInt32(myReader["apramount"]);

                            //model.maytext = myReader["maytext"].ToString();
                            //model.mayamount = Convert.ToInt32(myReader["mayamount"]);

                            //model.juntext = myReader["juntext"].ToString();
                            //model.junamount = Convert.ToInt32(myReader["junamount"]);

                            //model.jultext = myReader["jultext"].ToString();
                            //model.julamount = Convert.ToInt32(myReader["julamount"]);

                            //model.augtext = myReader["augtext"].ToString();
                            //model.augamount = Convert.ToInt32(myReader["augamount"]);

                            //model.septext = myReader["septext"].ToString();
                            //model.sepamount = Convert.ToInt32(myReader["sepamount"]);

                            //model.octtext = myReader["octtext"].ToString();
                            //model.octamount = Convert.ToInt32(myReader["octamount"]);

                            //model.novtext = myReader["novtext"].ToString();
                            //model.novamount = Convert.ToInt32(myReader["novamount"]);

                            //model.dectext = myReader["dectext"].ToString();
                            //model.decamount = Convert.ToInt32(myReader["decamount"]);


                            //list.Add(model);
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










        public static void Update(Models.UserReadBookModel model)
        {
            //var highestId = GetHighestTodoId();
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            //comm.CommandText = "UPDATE tttodocategory SET @id='" + model.id + "', @userid='" + model.userid + "', @sortorder='" + model.sortorder + "', @name='" + model.name + "', @backgroundcolor='" + model.backgroundcolor + "', @color='" + model.color + "' WHERE id=@id;";
            comm.CommandText = "UPDATE userreadbook SET id=@id, title=@title, description=@description, authors=@authors, isbn=@isbn, published=@published, language=@language, pagecount=@pagecount, userid=@userid, currentreadingpage=@currentreadingpage, imageurl=@imageurl WHERE id=@id;";
            comm.Parameters.AddWithValue("@id", model.id);
            comm.Parameters.AddWithValue("@title", model.title);
            comm.Parameters.AddWithValue("@description", model.description);
            comm.Parameters.AddWithValue("@authors", model.authors);
            comm.Parameters.AddWithValue("@isbn", model.isbn);
            comm.Parameters.AddWithValue("@published", model.published);
            comm.Parameters.AddWithValue("@language", model.language);
            comm.Parameters.AddWithValue("@pagecount", model.pagecount);
            comm.Parameters.AddWithValue("@userid", model.userid);
            comm.Parameters.AddWithValue("@currentreadingpage", model.currentreadingpage);
            comm.Parameters.AddWithValue("@imageurl", model.imageurl);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public static void Delete(int id)
        {
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "DELETE FROM userreadbook WHERE id=@id;";
            comm.Parameters.AddWithValue("@id", id);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public int GetHighestTodoId()
        {
            var list = new List<Models.UserReadBookModel>();
            string myConnection = DatabaseManager.GetConnectionstring();
            string query = "SELECT * FROM userreadbook";
            var conDatabase = new MySqlConnection(myConnection);
            MySqlCommand cmdDataBase = new MySqlCommand(query, conDatabase);
            MySqlDataReader myReader;
            try
            {
                conDatabase.Open();
                myReader = cmdDataBase.ExecuteReader();
                if (myReader.HasRows == true)
                {
                    while (myReader.Read())
                    {
                        var model = new Models.UserReadBookModel();
                        model.id = Convert.ToInt32(myReader["id"]);
                        //model.userid = Convert.ToInt32(myReader["userid"]);
                        //model.sortorder = Convert.ToInt32(myReader["sortorder"]);
                        //model.name = myReader["name"].ToString();
                        //model.color = myReader["color"].ToString();
                        //model.backgroundcolor = myReader["backgroundcolor"].ToString();
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

        public void SetStatus(string status, int id)
        {
            string connString = DatabaseManager.GetConnectionstring();
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "UPDATE userreadbook SET status=@status WHERE id=@id;";
            comm.Parameters.AddWithValue("@id", id);
            comm.Parameters.AddWithValue("@status", status);
            comm.ExecuteNonQuery();
            conn.Close();
        }



        public static void UpdateUserReadBook(UserReadBookModel model)
        {
        
        }

        public static void CreateFromAI(_1w4w.CMS.Models.BookModel model)
        {
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var sql = "INSERT INTO userreadbook(title, description, isbn, pagecount, imageurl) ";
                sql += "VALUES(@title, @description, @isbn, @pagecount, @imageurl);";
                cmd.Parameters.AddWithValue("@title", model.title);
                cmd.Parameters.AddWithValue("@description", model.description);
                cmd.Parameters.AddWithValue("@isbn", model.isbn);
                cmd.Parameters.AddWithValue("@pagecount", Convert.ToInt32(model.pagecount));
                cmd.Parameters.AddWithValue("@imageurl", model.imageurl);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }



        public int Create(_1w4w.CMS.Models.UserReadBookModel model)
        {
            int newhighestid = (GetHighestId() + 1);
            using (var con = new MySqlConnection(DatabaseManager.GetConnectionstring()))
            {
                con.Open();
                var cmd = con.CreateCommand();
                var sql = "";
                sql += "INSERT INTO userreadbook(id, userid, pagecount, currentreadingpage";
                sql += ", title, description, authors ";
                sql += ", isbn, published ";
                sql += ", language ";
                sql += ") ";

                sql += " VALUES(@id, @userid, @pagecount, @currentreadingpage";
                sql += ", @title, @description, @authors";
                sql += ", @isbn, @published";
                sql += ", @language";
                sql += ")";
                cmd.CommandText = sql;
                //comm.CommandText = sql;
                var id = model.id.ToString() ?? "";
                var userid = model.userid.ToString() ?? "";
                var pagecount = model.pagecount.ToString() ?? "";
                var currentreadingpage = model.currentreadingpage.ToString() ?? "";
                //var text1 = model.text1.ToString() ?? "";

                string title = model.title ?? "";
                string description = model.description ?? "";
                string authors = model.authors ?? "";
                string isbn = model.isbn ?? "";
                string published = model.published ?? "";
                string language = model.language ?? "";


                cmd.Parameters.AddWithValue("@id", newhighestid);
                cmd.Parameters.AddWithValue("@userid", model.userid);
                cmd.Parameters.AddWithValue("@pagecount", model.pagecount);
                cmd.Parameters.AddWithValue("@currentreadingpage", model.currentreadingpage);

                cmd.Parameters.AddWithValue("@title", title.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@description", description.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@authors", authors);

                cmd.Parameters.AddWithValue("@isbn", isbn.Replace("'", "''"));
                cmd.Parameters.AddWithValue("@published", published);
                cmd.Parameters.AddWithValue("@language", language);




                var createdid = cmd.ExecuteNonQuery();
                //con.Close();
                return createdid;
            }
        }

        public string Post(string url, string Post, string Header, string Value)
        {
            string str_ReturnValue = "";

            WebRequest request = WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            request.Timeout = 1000000;

            if (Header != null & Value != null)
            {
                request.Headers.Add(Header, Value);
            }

            using (Stream s = request.GetRequestStream())
            {
                using (StreamWriter sw = new StreamWriter(s))
                    sw.Write(Post);
            }

            using (Stream s = request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    var jsonData = sr.ReadToEnd();
                    str_ReturnValue += jsonData.ToString();
                }
            }

            return str_ReturnValue;
        }

        public static string GetBookDataFromStudentapan(string isbn)
        {
            var url = "https://bibliotek.lerum.se/vufind/Search/Results?lookfor=" + isbn + "&type=&limit=20&lng=sv";
            //var url = "https://www.bokus.com/bok/9789144075556/den-kompletta-guiden-till-aspergers-syndrom/" + isbn + "&type=&limit=20&lng=sv";
            //var url = "https://www.studentapan.se/search?query=9789189091511";
            //var url = "https://sl.se/";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            //req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/139.0.0.0 Safari/537.36";
            var responsebody = string.Empty;
            //WebRequest req = WebRequest.Create(url);
            WebResponse res = req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            responsebody = reader.ReadToEnd();
            reader.Close();
            res.Close();
            return responsebody;
        }

        //HtmlWeb web = new HtmlWeb();
        //web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/139.0.0.0 Safari/537.36\r\n";
        ////var html = web.Get(url);
        //HtmlDocument doc = new HtmlDocument();
        //// call one of the doc.LoadXXX() functions
        ////doc.LoadHtml(html);
        //Console.WriteLine(doc.DocumentNode.OuterHtml);
        //var html = doc.DocumentNode.OuterHtml;
        ////var client = new System.Net.Http.HttpClient();
        ////var responsebody = client.GetStringAsync(url).Result;

        public static string GetBookDataFromStudentapan3(string isbn)
        {
            // https://www.bokus.com/bok/9789144075556/
            // https://bibliotek.lerum.se/vufind/Record/4817?print=1
            // https://www.bokborsen.se/?_p=1&f=1&qi=9789189091511
            // https://www.bokborsen.se/view/Tony-Attwood/Den-Kompletta-Guiden-Till-Aspergers-Syndrom/13046270
            //var url = "https://www.studentapan.se/search?query=9789189091511";
            //var url = "https://www.studentapan.se/search?query=" + isbn;
            //var url = "https://www.bokborsen.se/view/Tony-Attwood/Den-Kompletta-Guiden-Till-Aspergers-Syndrom/13046270" + isbn;
            //var url = "https://bibliotek.lerum.se/vufind/Search/Results?lookfor=" + isbn + "&type=&limit=20&lng=sv";
            //var url = "https://www.bokborsen.se/?g=0&c=0&q=&qa=&qt=&qi=" + isbn + "&qs=&f=1&fi=&fd=&fs=&pb=&_s=created_at&_d=desc";
            var url = "https://www.bokus.com/bok/" + isbn + "/";
            var client = new System.Net.Http.HttpClient();
            var responsebody = client.GetStringAsync(url).Result;
            return responsebody;
        }

        public static string GetDataFromHtml(string html)
        {
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            //HtmlNode stockElement = document.DocumentNode.SelectSingleNode("//*[@id='table_1']/div[2]/p[2]");
            //HtmlNode stockElement = document.DocumentNode.SelectSingleNode("//*[@id='#maincontent']");
            //var firstParagraph = document.DocumentNode.SelectSingleNode("//html/body/div[1]/div[6]/div/div/div/div[1]/dl/dd[3]");
            //var firstParagraph = document.DocumentNode.SelectSingleNode(@"/html/body/div[1]/div[6]/div/div/div/div[1]/dl/dd[3]");
            //var linkByPartialText = doc.DocumentNode.SelectSingleNode("//a[contains(text(), 'Contact')]");
            // product-page__facts u-bc-wild-sand
            //HtmlNode node = document.DocumentNode.SelectSingleNode("/html/body/div[1]/div[6]/div/div/div/div[1]/dl/dd[3]");
            //string count = node.InnerText;


            //HtmlNode el = document.DocumentNode.SelectSingleNode("//*[@class='product-page__facts u-bc-wild-sand']");
            //var parentDiv = document.DocumentNode.SelectSingleNode("//div[@class='u-bc-wild-sand']");
            var node = document.DocumentNode.SelectSingleNode(@"//tr[@class=""warning""]/td");
            //SelectSingleNode('').'#text'

            // <dd>448</dd>

            //var aa = html.Contains(" sidor");
            //if (aa)
            //{
            //    var bb = html.Split(" sidor");
            //}






            //var videos = document.DocumentNode.Descendants("kortvyvanster").FirstOrDefault().Attributes["src"].Value;
            //var videos = document.DocumentNode.Descendants("kortvyvanster");
            //var node = document..QuerySelectorAll("#kortvyvanster");
            //var node = document.DocumentNode.SelectNodes(@"//div[contains(@id, ""table_1"")]");
            //var node = document.DocumentNode.SelectNodes(@"//table[contains(@id, ""table_1"")]");
            //var aa = document.DocumentNode.SelectNodes("//div[@id='table_1']");
            //var aa = document.DocumentNode.SelectNodes(@"/html/body/div[2]/div/div/div/div[1]/div[1]/div[2]/div[2]/div[2]/table/tbody/tr[1]/td");

            //var aa = document.DocumentNode.SelectNodes("//div[@id='pageWrapper']");
            //var aa = document.DocumentNode.SelectNodes(@"/html/body/div[2]/div/div/div/div[1]/div[1]/div[2]/div[2]/div[2]/table/tbody/tr[1]/td]");


            // #table_1 > tbody > tr:nth-child(1) > td

            //            var node2 = document.DocumentNode.SelectNodes(@"//dl[contains(@class, ""fullpostlista"")]");
            //            HtmlNode node3 = document.DocumentNode.XPath("/html/body/div[1]/div[5]/div[1]/div/div/div[2]/div/div/div[4]/dl[2]/dt[4]");


            // //*[@id="table_1"]/tbody/tr[1]/td


            // Fysisk beskrivning:


            return "";
        }

        public static string GetBookDataFromAkademibokhandelnse(string isbn)
        {

            // https://libris.kb.se/showrecord?q=9789189091511&r=&n=1&id=11261322&g=&f=simp&s=r&t=&m=10&d=libris
            var url = "https://libris.kb.se/showrecord?q=" + isbn + "&r=&n=1&id=11261322&g=&f=simp&s=r&t=&m=10&d=libris";
            var responsebody = "";
            var client = new System.Net.Http.HttpClient();
            responsebody = client.GetStringAsync(url).Result;

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(responsebody);
            //var videos = document.DocumentNode.Descendants("kortvyvanster").FirstOrDefault().Attributes["src"].Value;
            //var videos = document.DocumentNode.Descendants("kortvyvanster");
            //var node = document..QuerySelectorAll("#kortvyvanster");
            var node = document.DocumentNode.SelectNodes(@"//div[contains(@class, ""kortvyvanster"")]");
            //            var node2 = document.DocumentNode.SelectNodes(@"//dl[contains(@class, ""fullpostlista"")]");
            //            HtmlNode node3 = document.DocumentNode.XPath("/html/body/div[1]/div[5]/div[1]/div/div/div[2]/div/div/div[4]/dl[2]/dt[4]");



            List<string> list = new List<string>();
            list.Clear();
            string[] parts2 = node[0].InnerHtml.Split('>');
            foreach (var part in parts2)
            {
                if (!part.StartsWith("<"))
                {
                    if (!part.StartsWith("\n"))
                    {
                        list.Add(part.Trim());
                    }
                }
            }


            //            var pages = new String(list[12].Where(c => char.IsDigit(c)).ToArray());
            //var pages = list[12];
            // Find elements with specific attribute value
            var externalLinks = document.DocumentNode.SelectNodes("//dl[@class='fullpostlista']");

            // Find elements with attribute containing specific text
            //            var exampleLinks = document.DocumentNode.SelectNodes("//a[contains(@href, 'example')]");





            //    /html/body/div[1]/div[5]/div[1]/div/div/div[2]/div/div/div[4]/dl[2]/dt[4]
            //var c1 = node.Where(x => x.Id == "asdf");

            //var content = document.DocumentNode.SelectNodes(@"//div[contains(@class, ""kortvyvanster"")]");

            //get meta tags data
            var metaTags = document.DocumentNode.SelectNodes("//meta");

            var metadata = GetMetaDataFromUrl(url);
            //var rownodes = node.ChildNodes.Where(w => w.OriginalName == "tr");

            ////var videos = document.GetElementbyId.Descendants("kortvyvanster");
            //foreach (var video in videos)
            //{
            //    Console.Write(video.OuterHtml);
            //}
            return responsebody;
        }

        //public static string GetBookDataFromAkademibokhandelnse2(string isbn)
        //{
        //    var url = "https://libris.kb.se/showrecord?q=" + isbn + "&r=&n=1&id=11261322&g=&f=simp&s=r&t=&m=10&d=libris";
        //    var responsebody = "";
        //    var client = new System.Net.Http.HttpClient();
        //    responsebody = client.GetStringAsync(url).Result;
        //    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        //    document.LoadHtml(responsebody);


        //    var node = document.DocumentNode.SelectNodes(@"//div[contains(@class, ""kortvyvanster"")]");



        //    return responsebody;
        //}

        /*
         "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\"\n    \"http://www.w3.org/TR/html4/strict.dtd\">\n    <html lang=\"sv\">\n        <head profile=\"http://gmpg.org/xfn/11\">\n    <base href=\"//libris.kb.se/\"><!--[if IE]></base><![endif]-->\n    <title>LIBRIS - Den kompletta guiden till Asp...</title>\n    <meta http-equiv=\"robots\" content=\"index,nofollow\">        \n    <meta http-equiv=\"content-type\" content=\"text/html; charset=UTF-8\">\n    <meta name=\"description\" content=\"LIBRIS titelinformation: Den kompletta guiden till Aspergers syndrom / Tony Attwood ; översättning: Håkan Järvå.\">\n    <meta name=\"content\" content=\"LIBRIS Den kompletta guiden till Aspergers syndrom / Tony Attwood ; översättning: Håkan Järvå.\">\n    <meta name=\"copyright\" content=\"Copyright (c) LIBRIS / Kungl. biblioteket\">\n    <style type=\"text/css\" media=\"screen, projection\">@import 'css/kb2.css?v=relrec'; </style>\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"css/kb_print2.css\" media=\"print\">\n    <link rel=\"unapi-server\" type=\"application/xml\" href..."
         */


        /// <summary>
        /// https://codeshare.co.uk/blog/how-to-scrape-meta-data-from-a-url-using-htmlagilitypack-in-c/
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static MetaInformationModel GetMetaDataFromUrl(string url)
        {
            // Get the URL specified
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);
            var metaTags = document.DocumentNode.SelectNodes("//meta");
            MetaInformationModel metaInfo = new MetaInformationModel(url);
            if (metaTags != null)
            {
                int matchCount = 0;
                foreach (var tag in metaTags)
                {
                    var tagName = tag.Attributes["name"];
                    var tagContent = tag.Attributes["content"];
                    var tagProperty = tag.Attributes["property"];
                    if (tagName != null && tagContent != null)
                    {
                        switch (tagName.Value.ToLower())
                        {
                            case "title":
                                metaInfo.Title = tagContent.Value;
                                matchCount++;
                                break;
                            case "description":
                                metaInfo.Description = tagContent.Value;
                                matchCount++;
                                break;
                            case "twitter:title":
                                metaInfo.Title = string.IsNullOrEmpty(metaInfo.Title) ? tagContent.Value : metaInfo.Title;
                                matchCount++;
                                break;
                            case "twitter:description":
                                metaInfo.Description = string.IsNullOrEmpty(metaInfo.Description) ? tagContent.Value : metaInfo.Description;
                                matchCount++;
                                break;
                            case "keywords":
                                metaInfo.Keywords = tagContent.Value;
                                matchCount++;
                                break;
                            case "twitter:image":
                                metaInfo.ImageUrl = string.IsNullOrEmpty(metaInfo.ImageUrl) ? tagContent.Value : metaInfo.ImageUrl;
                                matchCount++;
                                break;
                        }
                    }
                    else if (tagProperty != null && tagContent != null)
                    {
                        switch (tagProperty.Value.ToLower())
                        {
                            case "og:title":
                                metaInfo.Title = string.IsNullOrEmpty(metaInfo.Title) ? tagContent.Value : metaInfo.Title;
                                matchCount++;
                                break;
                            case "og:description":
                                metaInfo.Description = string.IsNullOrEmpty(metaInfo.Description) ? tagContent.Value : metaInfo.Description;
                                matchCount++;
                                break;
                            case "og:image":
                                metaInfo.ImageUrl = string.IsNullOrEmpty(metaInfo.ImageUrl) ? tagContent.Value : metaInfo.ImageUrl;
                                matchCount++;
                                break;
                        }
                    }
                }
                metaInfo.HasData = matchCount > 0;
            }
            return metaInfo;
        }


        public static async Task<string> GetBookDataFromAkademibokhandelnseOLD(string isbn)
        {
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Add("User-Agent", "Chrome");

            var responsebody = "";
            //var url = "https://primo.library.ju.se/discovery/fulldisplay?docid=alma990003726460503831" + isbn;
            //var url = "https://www.akademibokhandeln.se/sok?sokfraga=" + isbn;
            //var url = "https://www.bookoutlet.se/catalogsearch/result/?q=" + isbn;
            //var url = "https://www.bokus.com/cgi-bin/product_search.cgi?ac_used=no&search_word=" + isbn;
            //var url = "https://libris.kb.se/hitlist?d=libris&q=" + isbn + "&f=simp&spell=true&hist=true&mf=&p=1";
            var url = "https://libris.kb.se/showrecord?q=" + isbn + "&r=&n=1&id=11261322&g=&f=simp&s=r&t=&m=10&d=libris";
            // 9789189091511
            // https://www.bokus.com/bok/9789144075556/den-kompletta-guiden-till-aspergers-syndrom/?srsltid=AfmBOop2byRToOfLvtzgyqNwYU0Duy2Kdl1NT1F6_3fUnOADduBoRdnq
            // https://libris.kb.se/showrecord?q=9789189091511&r=&n=1&id=11261322&g=&f=simp&s=r&t=&m=10&d=libris
            // https://libris.kb.se/showrecord?q=9789189091511&r=&n=1&id=11261322&g=&f=simp&s=r&t=&m=10&d=libris
            if (!string.IsNullOrEmpty(isbn))
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responsebody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(responsebody);
                    //client.Dispose();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }



                //var url = "https://www.akademibokhandeln.se/sok?sokfraga=" + isbn;
                //HttpClient client = new HttpClient();
                //client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                //client.BaseAddress = new Uri(isbn);
                //var response = client.GetStringAsync(url);

            }
            return responsebody;

        }
    }





    public class MetaInformationModel
    {
        public bool HasData { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string ImageUrl { get; set; }
        public string SiteName { get; set; }

        public MetaInformationModel(string url)
        {
            Url = url;
            HasData = false;
        }

        public MetaInformationModel(string url, string title, string description, string keywords, string imageUrl, string siteName)
        {
            Url = url;
            Title = title;
            Description = description;
            Keywords = keywords;
            ImageUrl = imageUrl;
            SiteName = siteName;
        }
    }

}