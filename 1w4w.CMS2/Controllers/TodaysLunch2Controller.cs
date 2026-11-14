using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

//using Newtonsoft.Json;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;


namespace _1w4w.CMS.Controllers
{
    public class TodaysLunch2Controller : Controller
    {



        public ActionResult Index()
        {
            //UserModel user = WalterAdmin.Manager.UserManager.ReadUserDataFromCookie();
            //UserModel user = Manager.UserManager.ReadUserDataFromCookie();
            //if (user != null)
            //{
            //    ViewBag.User = user;
            //    return Redirect("/cms/index");
            //}
            //else
            //{

            //}
            return View();
        }
        //public ActionResult login()
        //{
        //    return View();
        //}
        ////[HttpPost]
        ////public ActionResult loginByEmailPassword(string email, string password)
        ////{
        ////    return View();
        ////}
        //[HttpPost]
        //public ActionResult loginByEmailPassword(string email, string password)
        //{
        //    var message = "0";
        //    //string email = collection["email"];
        //    //string password = collection["password"];
        //    UserModel user = Manager.UserManager.Login(email, password);
        //    if (user != null)
        //    {
        //        ViewBag.User = user;
        //        return Redirect("/cms/index");
        //    }
        //    else
        //    {
        //        //message = "Wrong Email or Password";
        //        message = "1";
        //        if (email.Length == 0)
        //        {
        //            //message = "You forgot Email";
        //            message = "2";
        //        }
        //        if (password.Length == 0)
        //        {
        //            //message = "You forgot Password";
        //            message = "3";
        //        }
        //        if (email.Length == 0 && password.Length == 0)
        //        {
        //            //message = "You forgot Email & Password";
        //            message = "4";
        //        }
        //        return Redirect("/cms/login/" + message);
        //    }

        //    //return View(user);
        //}
        //public ActionResult signup()
        //{
        //    return View();
        //}
        //public ActionResult forgotpassword()
        //{
        //    return View();
        //}
        //public ActionResult resetpassword()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public ActionResult todayslunch()
        //{
        //    //var path = WalterAdmin.Manager.TodaysLunchManager.GetJsonDataFolderPath();
        //    var lunchesList = Manager.TodaysLunchManager.GetLunchesList();
        //    // List<Models.TodaysLunchModel> GetLunchesList()
        //    ViewBag.LunchesList = lunchesList;
        //    return View(lunchesList);
        //}
        //[HttpGet]
        //public ActionResult food()
        //{
        //    //var path = WalterAdmin.Manager.TodaysLunchManager.GetJsonDataFolderPath();
        //    var foodmanager = new Manager.FoodManager();
        //    var list = foodmanager.GetFoodList();
        //    var fileList = Manager.FileManager.GetFileList();
        //    var categoryList = Manager.CategoryManager.GetCategoryList();
        //    // List<Models.TodaysLunchModel> GetLunchesList()
        //    ViewBag.FileList = fileList;
        //    ViewBag.FoodList = list;
        //    ViewBag.CategoryList = categoryList;
        //    return View(list);
        //}

        //[HttpGet]
        //public ActionResult deletefood(string id)
        //{
        //    var foodmanager = new Manager.FoodManager();
        //    //string id = collection["id"];
        //    foodmanager.Delete(id);
        //    return Redirect("/cms/food");
        //}

        //[HttpGet]
        //public ActionResult deletefile(string id)
        //{
        //    Manager.FileManager.Delete(id);
        //    return Redirect("/cms/food");
        //}

        //public string removeDoubleBackslashes(string input)
        //{
        //    char[] separator = new char[1] { '\\' };
        //    string result = "";
        //    string[] subResult = input.Split(separator);
        //    for (int i = 0; i <= subResult.Length - 1; i++)
        //    {
        //        result = i < subResult.Length - 1 ? result + subResult[i] + "\\" : result + subResult[i];
        //    }
        //    return result;
        //}

        //[HttpPost]
        //public ActionResult updatefile(FormCollection collection)
        //{
        //    List<Models.FileModel> fileList = Manager.FileManager.GetFileList();
        //    //string file = Path.GetFullPath((HostingEnvironment.MapPath(fileList[0].Filename))).Replace(@"\\", @"\");
        //    //var file2 = file.Split('\\');
        //    //var temp = "";
        //    //foreach (var item in file2) { 
        //    //    temp += item + @"\";
        //    //}
        //    //var temp2 = temp;
        //    string fileidtoupdate = collection["fileidtoupdate"];
        //    string fileid = collection["fileid"];
        //    string filename = collection["filename"];
        //    if (!string.IsNullOrEmpty(fileidtoupdate))
        //    {
        //        if (!string.IsNullOrEmpty(fileid))
        //        {
        //            String[] fileidarr = fileid.Split(',');
        //            String[] filenamearr = filename.Split(',');
        //            for (int i = 0; i < fileidarr.Count(); i++)
        //            {
        //                string fileid2 = fileidarr[i];
        //                string filename2 = filenamearr[i];
        //                if (fileid2 == fileidtoupdate)
        //                {
        //                    var file3 = HostingEnvironment.MapPath("/");
        //                    System.IO.File.Move(file3 + fileList[Convert.ToInt32(i)].Filename, file3 + "\\content\\uploads\\" + filename2);
        //                    FileModel filemodel = new FileModel();
        //                    filemodel.Id = fileid2;
        //                    filemodel.Filename = "/content/uploads/" + filename2;
        //                    Manager.FileManager.Update(filemodel);
        //                }
        //            }

        //        }
        //    }
        //    return Redirect("/cms/food");
        //}

        //[HttpPost]
        //public ActionResult foodaddorupdate(FormCollection collection)
        //{
        //    //var list = WalterAdmin.Manager.FoodManager.GetFoodList();
        //    //var categoryList = WalterAdmin.Manager.CategoryManager.GetCategoryList();
        //    //ViewBag.FoodList = list;
        //    //ViewBag.CategoryList = categoryList;



        //    string id = collection["id"];
        //    string name = collection["name1"];
        //    string ingredients = collection["ingredients"];
        //    string description = collection["description"];
        //    string price = collection["price"];
        //    string image = collection["image"];
        //    string offerprice = collection["offerprice"];
        //    string categoryid = collection["categoryid"];


        //    string flexCheckCatering = collection["flexCheckCatering"];
        //    if (flexCheckCatering == "true") { flexCheckCatering = "1"; } else { flexCheckCatering = "0"; }
        //    string flexCheckHidden = collection["flexCheckHidden"];
        //    if (flexCheckHidden == "true") { flexCheckHidden = "1"; } else { flexCheckCatering = "0"; }

        //    string foodaddorupdateaction = collection["foodaddorupdateaction"];
        //    //flexCheckCatering
        //    FoodModel model = new FoodModel();
        //    model.Name = name;
        //    model.Ingredients = ingredients;
        //    model.Description = description;
        //    model.Price = price;
        //    model.OfferPrice = offerprice;
        //    model.CategoryId = categoryid;
        //    model.Image = image;
        //    model.Catering = flexCheckCatering;
        //    model.Hidden = flexCheckHidden;

        //    //if (!string.IsNullOrEmpty(flexCheckCatering))
        //    //if (!string.IsNullOrEmpty(flexCheckCatering))
        //    //{
        //    //    model.Catering = "1";
        //    //}
        //    //else
        //    //{
        //    //    model.Catering = "0";
        //    //}

        //    //if (!string.IsNullOrEmpty(flexCheckHidden))
        //    if (!string.IsNullOrEmpty(flexCheckHidden))
        //        //{
        //        //    model.Hidden = "1";
        //        //}
        //        //else
        //        //{
        //        //    model.Hidden = "0";
        //        //}

        //        if (foodaddorupdateaction == "add")
        //        {
        //            var foodmanager = new Manager.FoodManager();
        //            foodmanager.Create(model);
        //        }
        //        else if (foodaddorupdateaction == "update")
        //        {
        //            var foodmanager = new Manager.FoodManager();
        //            model.Id = id;
        //            foodmanager.Update(model);
        //        }

        //    //var path = WalterAdmin.Manager.TodaysLunchManager.GetJsonDataFolderPath();
        //    //var list = WalterAdmin.Manager.TodaysLunchManager.GetLunchesList();
        //    // List<Models.TodaysLunchModel> GetLunchesList()
        //    //ViewBag.Food = list;
        //    return Redirect("/cms/food");
        //}
        //[HttpPost]
        //public ActionResult categoryaddorupdate(FormCollection collection)
        //{
        //    string category1 = collection["category1"];
        //    var categoryModel = new Models.CategoryModel();
        //    categoryModel.Category = category1;
        //    Manager.CategoryManager.Create(categoryModel);


        //    //var list = WalterAdmin.Manager.TodaysLunchManager.GetLunchesList();
        //    //ViewBag.Food = list;
        //    //return View(list);
        //    return Redirect("/cms/food");
        //}
        //// 
        //[HttpPost]
        ////public ActionResult todayslunchaddorupdate(FormCollection collection)
        //public ActionResult todayslunchaddorupdate(FormCollection collection)
        //{
        //    string id = collection["id"];
        //    string year = collection["year"];
        //    string week = collection["week"];
        //    string weekday = collection["weekday"];

        //    string monday1 = collection["monday1"];
        //    string monday2 = collection["monday2"];
        //    string monday3 = collection["monday3"];
        //    string monday4 = collection["monday4"];
        //    string monday5 = collection["monday5"];
        //    string monday6 = collection["monday6"];
        //    string monday7 = collection["monday7"];
        //    string monday8 = collection["monday8"];
        //    string monday9 = collection["monday9"];
        //    string monday10 = collection["monday10"];

        //    string tuesday1 = collection["tuesday1"];
        //    string tuesday2 = collection["tuesday2"];
        //    string tuesday3 = collection["tuesday3"];
        //    string tuesday4 = collection["tuesday4"];
        //    string tuesday5 = collection["tuesday5"];
        //    string tuesday6 = collection["tuesday6"];
        //    string tuesday7 = collection["tuesday7"];
        //    string tuesday8 = collection["tuesday8"];
        //    string tuesday9 = collection["tuesday9"];
        //    string tuesday10 = collection["tuesday10"];

        //    string wednesday1 = collection["wednesday1"];
        //    string wednesday2 = collection["wednesday2"];
        //    string wednesday3 = collection["wednesday3"];
        //    string wednesday4 = collection["wednesday4"];
        //    string wednesday5 = collection["wednesday5"];
        //    string wednesday6 = collection["wednesday6"];
        //    string wednesday7 = collection["wednesday7"];
        //    string wednesday8 = collection["wednesday8"];
        //    string wednesday9 = collection["wednesday9"];
        //    string wednesday10 = collection["wednesday10"];

        //    string thursday1 = collection["thursday1"];
        //    string thursday2 = collection["thursday2"];
        //    string thursday3 = collection["thursday3"];
        //    string thursday4 = collection["thursday4"];
        //    string thursday5 = collection["thursday5"];
        //    string thursday6 = collection["thursday6"];
        //    string thursday7 = collection["thursday7"];
        //    string thursday8 = collection["thursday8"];
        //    string thursday9 = collection["thursday9"];
        //    string thursday10 = collection["thursday10"];

        //    string friday1 = collection["friday1"];
        //    string friday2 = collection["friday2"];
        //    string friday3 = collection["friday3"];
        //    string friday4 = collection["friday4"];
        //    string friday5 = collection["friday5"];
        //    string friday6 = collection["friday6"];
        //    string friday7 = collection["friday7"];
        //    string friday8 = collection["friday8"];
        //    string friday9 = collection["friday9"];
        //    string friday10 = collection["friday10"];

        //    string saturday1 = collection["saturday1"];
        //    string saturday2 = collection["saturday2"];
        //    string saturday3 = collection["saturday3"];
        //    string saturday4 = collection["saturday4"];
        //    string saturday5 = collection["saturday5"];
        //    string saturday6 = collection["saturday6"];
        //    string saturday7 = collection["saturday7"];
        //    string saturday8 = collection["saturday8"];
        //    string saturday9 = collection["saturday9"];
        //    string saturday10 = collection["saturday10"];

        //    string sunday1 = collection["sunday1"];
        //    string sunday2 = collection["sunday2"];
        //    string sunday3 = collection["sunday3"];
        //    string sunday4 = collection["sunday4"];
        //    string sunday5 = collection["sunday5"];
        //    string sunday6 = collection["sunday6"];
        //    string sunday7 = collection["sunday7"];
        //    string sunday8 = collection["sunday8"];
        //    string sunday9 = collection["sunday9"];
        //    string sunday10 = collection["sunday10"];

        //    var model = new Models.TodaysLunchModel();
        //    model.Id = id;
        //    model.Year = year;
        //    model.Week = week;
        //    model.Weekday = weekday;

        //    model.Monday1 = monday1;
        //    model.Monday2 = monday2;
        //    model.Monday3 = monday3;
        //    model.Monday4 = monday4;
        //    model.Monday5 = monday5;
        //    model.Monday6 = monday6;
        //    model.Monday7 = monday7;
        //    model.Monday8 = monday8;
        //    model.Monday9 = monday9;
        //    model.Monday10 = monday10;

        //    model.Tuesday1 = tuesday1;
        //    model.Tuesday2 = tuesday2;
        //    model.Tuesday3 = tuesday3;
        //    model.Tuesday4 = tuesday4;
        //    model.Tuesday5 = tuesday5;
        //    model.Tuesday6 = tuesday6;
        //    model.Tuesday7 = tuesday7;
        //    model.Tuesday8 = tuesday8;
        //    model.Tuesday9 = tuesday9;
        //    model.Tuesday10 = tuesday10;

        //    model.Wednesday1 = wednesday1;
        //    model.Wednesday2 = wednesday2;
        //    model.Wednesday3 = wednesday3;
        //    model.Wednesday4 = wednesday4;
        //    model.Wednesday5 = wednesday5;
        //    model.Wednesday6 = wednesday6;
        //    model.Wednesday7 = wednesday7;
        //    model.Wednesday8 = wednesday8;
        //    model.Wednesday9 = wednesday9;
        //    model.Wednesday10 = wednesday10;

        //    model.Thursday1 = thursday1;
        //    model.Thursday2 = thursday2;
        //    model.Thursday3 = thursday3;
        //    model.Thursday4 = thursday4;
        //    model.Thursday5 = thursday5;
        //    model.Thursday6 = thursday6;
        //    model.Thursday7 = thursday7;
        //    model.Thursday8 = thursday8;
        //    model.Thursday9 = thursday9;
        //    model.Thursday10 = thursday10;

        //    model.Friday1 = friday1;
        //    model.Friday2 = friday2;
        //    model.Friday3 = friday3;
        //    model.Friday4 = friday4;
        //    model.Friday5 = friday5;
        //    model.Friday6 = friday6;
        //    model.Friday7 = friday7;
        //    model.Friday8 = friday8;
        //    model.Friday9 = friday9;
        //    model.Friday10 = friday10;

        //    model.Saturday1 = saturday1;
        //    model.Saturday2 = saturday2;
        //    model.Saturday3 = saturday3;
        //    model.Saturday4 = saturday4;
        //    model.Saturday5 = saturday5;
        //    model.Saturday6 = saturday6;
        //    model.Saturday7 = saturday7;
        //    model.Saturday8 = saturday8;
        //    model.Saturday9 = saturday9;
        //    model.Saturday10 = saturday10;

        //    model.Sunday1 = sunday1;
        //    model.Sunday2 = sunday2;
        //    model.Sunday3 = sunday3;
        //    model.Sunday4 = sunday4;
        //    model.Sunday5 = sunday5;
        //    model.Sunday6 = sunday6;
        //    model.Sunday7 = sunday7;
        //    model.Sunday8 = sunday8;
        //    model.Sunday9 = sunday9;
        //    model.Sunday10 = sunday10;


        //    var lunchesList = Manager.TodaysLunchManager.GetLunchesList();
        //    if (lunchesList != null)
        //    {
        //        Models.TodaysLunchModel thisWeeksLunch = lunchesList.Where(x => x.Week.ToString() == week.ToString() && x.Year.ToString() == year.ToString()).SingleOrDefault();
        //        if (thisWeeksLunch != null)
        //        {
        //            //thisWeeksLunch.monda
        //            //Manager.TodaysLunchManager.Update(Convert.ToInt32(thisWeeksLunch.Id), model);
        //            Manager.TodaysLunchManager.Update(model);
        //        }
        //        else
        //        {
        //            Manager.TodaysLunchManager.Create(model);
        //        }
        //    }
        //    else
        //    {
        //        Manager.TodaysLunchManager.Create(model);
        //    }

        //    //return View();
        //    //return RedirectToAction("index");
        //    // /cms/todayslunch?year=2024&week=10
        //    return Redirect("/cms/todayslunch?year=" + model.Year + "&week=" + model.Week + "&weekday=" + model.Weekday);
        //}


        ////public static List<TodoX.Models.Todo> Read(int userId)
        ////{
        ////    // get todos from todo.json
        ////    var jsonmanager = new JsonManager();
        ////    var json = jsonmanager.Read("todo.json");
        ////    var list = JsonConvert.DeserializeObject<List<TodoX.Models.Todo>>(json);
        ////    return list.Where(x => x.UserId == userId).ToList();
        ////}

        //public string GetSafeFilename(string filename)
        //{
        //    // https://stackoverflow.com/questions/2230826/remove-invalid-disallowed-bad-characters-from-filename-or-directory-folder/12800424#12800424
        //    return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        //}

        //[HttpPost]
        //public ActionResult Upload()
        //{
        //    // https://www.aspsnippets.com/Articles/2985/Fetch-File-from-Form-Collection-in-ASPNet-MVC/
        //    if (Request.Files.Count > 0)
        //    {
        //        // upload directory where files will be uploaded to
        //        string path = Server.MapPath("~/content/uploads/");
        //        string filename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
        //        if (!Directory.Exists(path))
        //            Directory.CreateDirectory(path);

        //        Request.Files[0].SaveAs(path + GetSafeFilename(Request.Files[0].FileName));
        //        Manager.FileManager.Create(new FileModel
        //        {
        //            //Filename = WalterAdmin.Manager.FileManager.GetUploadedFilesFolderPath() + GetSafeFilename(Request.Files[0].FileName)
        //            Filename = "/content/uploads/" + GetSafeFilename(Request.Files[0].FileName)
        //        });

        //        //// https://stackoverflow.com/questions/210650/validate-image-from-file-in-c-sharp/9446045#9446045
        //        //// make sure here serverside that the uploaded file really is an image
        //        //try
        //        //{
        //        //    using (FileStream stream = new FileStream(path + Request.Files[0].FileName, FileMode.Open, FileAccess.Read))
        //        //    {
        //        //        Image im = Image.FromStream(stream);
        //        //        // Do something with image if needed.



        //        //        //Request.Files[0].SaveAs(path + filename);
        //        //        //Request.Files[0].SaveAs(path + Request.Files[0].FileName);
        //        //        Request.Files[0].SaveAs(path + GetSafeFilename(Request.Files[0].FileName));
        //        //    }
        //        //}
        //        //catch (ArgumentException)
        //        //{
        //        //    //if (!IsValidImageFormat(path))
        //        //    //    return SetLastError("File '" + fileName + "' is not a valid image");
        //        //    //throw;
        //        //}



        //        // save every uploaded file
        //        //using (Stream inputStream = Request.InputStream)
        //        //{
        //        //    byte[] data;
        //        //    using (MemoryStream ms = new MemoryStream())
        //        //    {
        //        //        inputStream.CopyTo(ms);
        //        //        data = ms.ToArray();
        //        //        //System.IO.File.WriteAllBytes(Path.Combine(ClientFolder, objGroup.GSTDocumentFile.FileName), data);
        //        //        System.IO.File.WriteAllBytes(Path.Combine(path, Request.Files[0].FileName), data);
        //        //    }

        //        //}

        //        //var s = Convert.FromBase64String(Request.InputStream);


        //        //---

        //        //string result = string.Empty;

        //        //---
        //        //using (BinaryReader b = new BinaryReader(Request.InputStream))
        //        //{
        //        //    byte[] binData = b.ReadBytes(Convert.ToInt32(Request.InputStream.Length));
        //        //    result = System.Text.Encoding.UTF8.GetString(binData);
        //        //    string path2 = Path.Combine(path, fileName);
        //        //    System.IO.File.WriteAllBytes(path2, binData);
        //        //}
        //        //---

        //        //---
        //        //FileStream fs = new FileStream(Request.Files[0].FileName, FileMode.Open, FileAccess.Read);
        //        //byte[] data = new byte[fs.Length];
        //        //fs.Read(data, 0, data.Length);
        //        //fs.Close();
        //        //.SaveAs(path + Path.GetFileName(postedFile.FileName));
        //        //using (Stream file = System.IO.File.Create(Request.Files[0].FileName))
        //        //{
        //        //    CopyStream(Request.InputStream, path + filename);
        //        //}
        //        //---


        //        //---
        //        //byte[] binData = b.ReadBytes(Convert.ToInt32(Request.InputStream.Length));

        //        //MemoryStream memoryStream = new MemoryStream(binData);
        //        //StreamReader streamReader = new StreamReader(memoryStream, Encoding.Default, true);
        //        //memoryStream.Seek(0, SeekOrigin.Begin);

        //        //string fileString = streamReader.ReadToEnd();
        //        //string fileData = fileString.Substring(0, fileString.IndexOf("\r\n\r\n") + 4);
        //        //string finalData = Regex.Replace(fileString, fileData, "");

        //        //var fileDataArr = Regex.Split(fileData, "\r\n|\r|\n").ToList();
        //        //var resultData = Regex.Replace(finalData, fileDataArr[0] + "--", "");

        //        //byte[] buffer = Encoding.Default.GetBytes(resultData);
        //        //---



        //        //---

        //        //---
        //        //byte[] buffer = new byte[Request.InputStream.Length];
        //        //Request.InputStream.Read(buffer, 0, buffer.Length);
        //        //string data = Encoding.Default.GetString(buffer);
        //        //string[] tokens = data.Split(',');
        //        //if (tokens.Length > 1)
        //        //{
        //        //    byte[] image = Convert.FromBase64String(tokens[1]);
        //        //    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png";
        //        //    //string path = Path.Combine(@"D:\www\images", fileName);
        //        //    System.IO.File.WriteAllBytes(path, image);
        //        //}
        //        //---


        //        //foreach (HttpPostedFileBase file in Request.Files)
        //        //{
        //        //    file.SaveAs(path + Path.GetFileName(file.FileName));
        //        //}

        //        //HttpPostedFileBase postedFile = Request.Files["imgUpload"];
        //        //string path = Server.MapPath("~/content/uploads/");
        //        //if (!Directory.Exists(path))
        //        //{
        //        //    Directory.CreateDirectory(path);
        //        //}

        //        //postedFile.SaveAs(path + Path.GetFileName(postedFile.FileName));
        //        //TempData["Message"] = "File uploaded successfully.";
        //        //return Content("Success");
        //        return Json("Success", JsonRequestBehavior.AllowGet);
        //    }

        //    //return Redirect("/cms/food");
        //    //return Content("<script>window.location.href='/cms/food';</script>");
        //    //return Content("Files uploaded");
        //    //return Content("Failure");
        //    return Json("Failure", JsonRequestBehavior.AllowGet);
        //}




        ////public void CopyStream(Stream stream, string destPath)
        ////{
        ////    using (var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
        ////    {
        ////        stream.CopyTo(fileStream);
        ////    }
        ////}

        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Upload56(HttpPostedFileBase imgUpload)
        //{
        //    // https://stackoverflow.com/questions/13041808/mvc-controller-get-json-object-from-http-body
        //    //Stream req = Request.InputStream;
        //    //req.Seek(0, System.IO.SeekOrigin.Begin);
        //    //string json = new StreamReader(req).ReadToEnd();
        //    string jsonData = Request.Form[0];

        //    //InputClass input = null;
        //    //try
        //    //{
        //    //    // assuming JSON.net/Newtonsoft library from http://json.codeplex.com/
        //    //    input = JsonConvert.DeserializeObject<InputClass>(json);
        //    //}

        //    //catch (Exception ex)
        //    //{
        //    //    // Try and handle malformed POST body
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}

        //    // process files here

        //    return Content("Success");
        //}

        //[AllowAnonymous]
        //[HttpPost]
        ////public ActionResult Upload(List<HttpPostedFileBase> fileData)
        //public ActionResult Upload3(IEnumerable<HttpPostedFileBase> files, FormCollection form)
        //{
        //    if (files.Any())
        //    {
        //        string path = Server.MapPath("~/content/uploads/");
        //        foreach (HttpPostedFileBase file in files)
        //        {
        //            if (file != null)
        //            //if (fileData != null)
        //            {
        //                //string fileName = Path.GetFileName(fileData.FileName);
        //                string filename = Path.GetFileName(file.FileName);
        //                file.SaveAs(path + filename);
        //                //fileData.SaveAs(path + fileName);
        //                return Content("Success");
        //            }
        //        }
        //    }
        //    return Content("Failed");
        //}

        //[AllowAnonymous]
        //[HttpPost]
        ////public ActionResult Upload(List<HttpPostedFileBase> fileData)
        //public ActionResult Upload2(HttpPostedFileBase fileData)
        //{
        //    //if (fileData.Any())
        //    //{
        //    string path = Server.MapPath("~/content/uploads/");
        //    //foreach (HttpPostedFileBase postedFile in fileData)
        //    //{
        //    //if (postedFile != null)
        //    if (fileData != null)
        //    {
        //        string fileName = Path.GetFileName(fileData.FileName);
        //        //string fileName = Path.GetFileName(postedFile.FileName);
        //        //postedFile.SaveAs(path + fileName);
        //        fileData.SaveAs(path + fileName);
        //        return Content("Success");
        //    }
        //    //}

        //    //}
        //    return Content("Failed");
        //}



    }
}