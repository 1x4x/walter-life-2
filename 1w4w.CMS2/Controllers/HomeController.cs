using _1w4w.CMS.Manager;
using _1w4w.CMS.Manager.Template;
using _1w4w.CMS.Models;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace _1w4w.CMS.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();

            //var data = _1w4w.CMS.Manager.UserReadBookManager.GetBookDataFromAkademibokhandelnse("9789100809867");
            //var data = _1w4w.CMS.Manager.UserReadBookManager.GetBookDataFromAkademibokhandelnse("9789189091511");
//            var html = _1w4w.CMS.Manager.UserReadBookManager.GetBookDataFromStudentapan("9789189091511");
//            var o1 = _1w4w.CMS.Manager.UserReadBookManager.GetDataFromHtml(html);
            //var airesponse = _1w4w.CMS.Manager.ChatGPTManager.ChatGPT("Get title, description, pagecount as json object for book with isbn 9789189091511");
            //var airesponse = Task.Run(() => _1w4w.CMS.Manager.ChatGPTManager.ChatGPT("Get title, description, pagecount as json object for isbn: 9789189091511").Result);
            //var title = "den kompletta guiden till aspergers syndrom";
            //var title = "underbara adhd den svåra superkraften";
            //var airesponse = Task.Run(() => _1w4w.CMS.Manager.ChatGPTManager.ChatGPT($"Hämta isbn, title, description, pagecount, imageurl för boken: " + title));

            //var data1 = _1w4w.CMS.Manager.UserReadBookManager.GetBookDataFromStudentapan("9789189091511");
            //var data1 = _1w4w.CMS.Manager.UserReadBookManager.GetBookDataFromStudentapan("9789170276750");
            //var data2 = _1w4w.CMS.Manager.UserReadBookManager.GetBookDataFromAkademibokhandelnse("9789170276750");

            //              var apikey = "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";
            //              var title = "Sex, kärlek & aspergers syndrom : med kärleksskola för aspergare";
            //              string response = await _1w4w.CMS.Manager.ChatGPTManager.CallOpenAiApi($"Hämta isbn, title, description, pagecount, imageurl för boken: " + title, apikey);

            return View(layoutViewModel);

        }



        public async Task<ActionResult> TodoLayout2()
        {
            return View();
        }



        [AllowAnonymous]
        [HttpPost, ValidateInput(false)]
        [Route("/home/getbookdata")]
        //public async Task<string> GetBookData()
        public async Task<ActionResult> GetBookData()
        {
            // -------------------------------------------------------------
            // get the booktitle that we want information for from chatgpt
            // -------------------------------------------------------------
            var title = Request.Form["booktitle"];
            if (string.IsNullOrEmpty(title)) { return Redirect("/home/book"); }
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            
            var apikey = "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";
            //var title = "Sex, kärlek & aspergers syndrom : med kärleksskola för aspergare";
            
            string response = await _1w4w.CMS.Manager.ChatGPTManager.CallOpenAiApi($"Hämta isbn, title, description, pagecount, imageurl för boken: " + title, apikey);


            //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            //object routes_list = json_serializer.DeserializeObject("{ \"test\":\"some data\" }");

            //var model = JsonConvert.DeserializeObject<Models.BookModel>(response);

            //object obj = json_serializer.DeserializeObject(response);
            //var text = obj[4]["choices"][0];



            // --------------------------
            // parse response
            // --------------------------



            //var jsonData = JsonConvert.DeserializeObject<dynamic>(response);
            //int counter = 0;
            //foreach (var data in jsonData)
            //{
            //    var current = data[counter];
            //    //var description = data[0].Value;
            //    //Console.WriteLine($"description: {description}");
            //    //var age = data.age;
            //    //var department = data.department;

            //    //Console.WriteLine($"Name: {name}, Age: {age}, Department: {department}");
            //    counter++;
            //}

            int pos1 = 0;
            int pos2 = 0;
            int p1 = 0;
            int p2 = 0;


            var isbn = "";

            var title2 = "";
            if (response.Contains(@"\nTitle: ")) { title2 = _1w4w.CMS.Manager.ParseManager.Between(response, @"\nTitle: ", @"\nDescription: "); }

            var description = "";
            if (response.Contains(@"\nDescription: ")) { description = _1w4w.CMS.Manager.ParseManager.Between(response, @"\nDescription: ", @"\nPagecount: "); }

            var pagecount = "";
            if (response.Contains(@"\nPagecount: ")) { pagecount = _1w4w.CMS.Manager.ParseManager.Between(response, @"\nPagecount: ", @"\nImageurl: "); }

            var imageurl = "";
            if (response.Contains(@"\nImageurl: ")) {


            

                //var items = JsonConvert.DeserializeObject<List<BookItem>>(response);
                dynamic array = JsonConvert.DeserializeObject(response);
                foreach (var item in array)
                {
                    //if (!string.IsNullOrEmpty(item.choices))
                    //{
                        var dynitem = item;
                    
                        //imageurl = dynitem.Imageurl;

                    JObject dynJson = JsonConvert.DeserializeObject(response) as JObject;
                    foreach (var item2 in dynJson["choices"])
                    {
                        //string output = string.Format("{0} {1} {2}", item2["Imageurl"], item2["surname"], item2["house"]);
                        string text = string.Format("{0}", item2["text"]);

                        p1 = 0;
                        p2 = 0;
                        var start = "";


                        // isbn
                        start = "\n\n\n\nISBN: "; p1 = text.IndexOf(start) + start.Length;
                        for (int i = p1; i < text.Length; i++)
                        {
                            var end = "";
                            char ch = text[i];
                            // isbn -> search for \
                            if (ch == '\\')
                            {
                                end = "\\";
                                // isbn -> search for n
                                if (end == "\\" && ch == 'n')
                                {
                                    end = "\\n";
                                    
                                    //
                                    p2 = i;
                                    isbn = text.Substring(p1, p2 - p1);
                                    break;

                                }
                            }
                        }



                        // find the , after the url
                        for (int i = 0; i < text.Length; i++)
                        {
                            char ch = text[i];
                            if (ch == ',')
                            {
                                pos2 = i;
                                imageurl = text.Substring(pos1, pos2 - pos1);
                                break;
                            }
                        }


                        var Imageurl44 = item2["Imageurl"];
                    }


                    //}

                    //dynamic array2 = JsonConvert.DeserializeObject(arne);
                    //Console.WriteLine("{0} {1}", item.Imageurl, item.vcc);                    
                }
                //JToken.Parse() 
                //JObject.Parse(),
                //JArray.Parse()
                //JValue.Parse()

                pos1 = response.IndexOf("\nImageurl: ") + "\nImageurl: ".Length;
                //int pos1 = response.IndexOf("\nImageurl: ") + "\nImageurl: ".Length;
                pos2 = response.IndexOf("\",");
                // ",

                // find the , after the url
                for (int i = 0; i < response.Length; i++)
                {
                    char ch = response[i];
                    if (ch == ',')
                    {
                        pos2 = i;
                        imageurl = response.Substring(pos1, pos2 - pos1);
                        break;
                    }
                }
                


                //imageurl = _1w4w.CMS.Manager.ParseManager.Between(response, @"\nImageurl: ", @","); 
            }


            //var bookmodel = JsonConvert.DeserializeObject<object>(response);
            //var pagecount = bookmodel.pagecount;
            //choices


            //var parsed = JObject.Parse(response);
            //var forecast = new WeatherForeCast();
            //forecast.City = parsed.SelectToken("city.name").Value<string>();
            //forecast.Day = parsed.SelectToken("list[0].temp.day").Value<decimal>();
            //var description = parsed.SelectToken("list[0].weather[0].description").Value<string>();
            //forecast.Min = parsed.SelectToken("list[0].temp.min").Value<decimal>();
            //forecast.Max = parsed.SelectToken("list[0].temp.max").Value<decimal>();
            //forecast.Night = parsed.SelectToken("list[0].temp.night").Value<decimal>();
            //var description = parsed.SelectToken("description").Value<string>();



            //dynamic jsonObj = JsonConvert.DeserializeObject(response);
            //var text1 = (string)jsonObj.text;





            //var dataObj = JArray.Parse(response)["response"];
            //foreach (var record in dataObj)
            //{
            //    var text = record["text"];

            //}


            // --------------------------
            // save to database
            // --------------------------
            BookModel model = new BookModel();
            model.title = title;
            model.description = description;
            model.isbn = isbn;
            var isNumeric = int.TryParse(pagecount, out int n);
            if (isNumeric)
            {
                model.pagecount = pagecount;
            }
            else
            {
                model.pagecount = "1";
            }

            model.imageurl = imageurl;
            _1w4w.CMS.Manager.UserReadBookManager.CreateFromAI(model);



            JObject rss = JObject.Parse(response);
            //var isbn222 = (string)rss["choices"]["text"];
            //var asdfsd = rss.SelectToken("choices.text");

            var jObj = JObject.Parse(response);
            foreach (var kvp in jObj.Cast<KeyValuePair<string, JToken>>().ToList())
            {
                var aa = kvp.Key;
                var bb = kvp.Value;
                if (aa == "choices")
                {
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    //var brands = rss.SelectToken("choices[0].text")?.ToObject<string[]>();
                    //var brands = rss["choices"][0]["text"].Values<string>().ToArray();


                    //object routes_list = json_serializer.DeserializeObject("{ \"test\":\"some data\" }");
                    //object routes_list = json_serializer.DeserializeObject(bb);
                    //routes_list["test"]

                    //string[] brands = _1w4w.CMS.Manager.JTokenManager.JTokenToArray<string>(jObject.Value<JToken>("brands"));
                    //string[] brands = _1w4w.CMS.Manager.JTokenManager.JTokenToArray<string>(bb.Value<JToken>("text"));



                }
            }


            return Redirect("/home/book?year=");


            //return response;
        }


        //public static int IterateOverJsonDynamically(string json)
        //{
        //    var jsonData = JsonConvert.DeserializeObject<dynamic>(json);

        //    foreach (var data in jsonData)
        //    {
        //        var name = data.name;
        //        var age = data.age;
        //        var department = data.department;

        //        Console.WriteLine($"Name: {name}, Age: {age}, Department: {department}");
        //    }

        //    var count = jsonData.Count;
        //    return count;
        //}

        public class BookItem
        {
            public string Imageurl;
        }

        public ActionResult Book()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }


        public ActionResult Economy()
        {
            // if we have no record create 1 row for the given year
            //var year2 = string.IsNullOrEmpty(Request.QueryString["year"]) ?? DateTime.Now.Year.ToString();

            string year = Request.QueryString["year"];
            if (string.IsNullOrEmpty(year)) { year = DateTime.Now.Year.ToString(); }
            //var economyeventcount = EconomyManager.GetEconomyEventCount(year);
            if (EconomyManager.GetEconomyEventCount(year) == 0) { EconomyManager.CreateDummy(Convert.ToInt32(year)); }



            // EconomyTransactionList
            var economyTransactionList = EconomyManager.GetEconomyTransactionList(year);
            ViewBag.EconomyTransactionList = economyTransactionList;


            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }

        [HttpPost]
        public ActionResult UpdateEconomy(EconomyEventModel model)
        {
            EconomyManager.Update(model);
            return Redirect("/home/economy?year=" + model.year1);
        }

        public ActionResult Forgotpassword()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }

        public ActionResult Signup()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }

        public ActionResult Login()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }

        public ActionResult Logout()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }

        public ActionResult Website()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(Models.ProjectModel model)
        //{
        //    new ProjectManager().Create(model);
        //    return Redirect("/home/index");
        //}


        //

        //public ActionResult Update(int id)
        //{
        //    var finishedTasksList = new TaskManager().GetFinishedTasks(id.ToString());
        //    var unfinishedTasksList = new TaskManager().GetUnfinishedTasks(id.ToString());
        //    ViewBag.FinishedTasksList = finishedTasksList;
        //    ViewBag.UnfinishedTasksList = unfinishedTasksList;

        //    var model = new Models.ProjectModel();
        //    if (id > 0) {
        //        model = new _1w4w.CMS.Manager.ProjectManager().Read(id);
        //        ViewBag.Project = model;
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Update(Models.ProjectModel model)
        //{
        //    new ProjectManager().Update(model);
        //    return Redirect("/home/index");
        //}

        [HttpPost]
        [Route("/home/UpdatePart1startHeadings")]
        public ActionResult UpdatePart1startHeadings(string websiteid, string heading1, string heading2, string opentimesmontofri, string opentimessattosun, string opentimeslunch)
        {
            T1Manager.UpdatePart1startHeadings(websiteid, heading1, heading2, opentimesmontofri, opentimessattosun, opentimeslunch);
            return Redirect("/home/index");
        }

        //public ActionResult Delete(int id)
        //{
        //    new ProjectManager().Delete(id);
        //    return Redirect("/home/index");
        //}

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

    }
}