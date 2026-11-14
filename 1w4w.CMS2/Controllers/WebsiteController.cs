using _1w4w.CMS.Manager;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class WebsiteController : Controller
    {
        public ActionResult Index()
        {
            //var layoutViewModel = new _1w4w.CMS.Models.LayoutViewModel
            //{
            //    BaseUrl = "/aa/bbb"
            //};
            //@Model _1w4w.CMS.Models.LayoutViewModel
            //ViewBag.LayoutViewModel = layoutViewModel;
            
            
            //var table1 = (IEnumerable<ProductModel>)DatabaseManager.DbQueryToArray("Server=mysql690.loopia.se;Database=goblinbot_se;Port=3306;User ID=e003574a@g361575;Password=gladastarnograven1!;Charset=utf8", "select * from product");
            //var table1 = DatabaseManager.DbQueryToArray("Server=mysql690.loopia.se;Database=goblinbot_se;Port=3306;User ID=e003574a@g361575;Password=gladastarnograven1!;Charset=utf8", "select * from product").ToList();
            //for(int i = 0; i < table1.Count(); i++)
            //{
            //    var aa = table1[i].GetRange(i,1).ToString();
            //    //var aa = table1.ToList().GetRange(i,1).ToString();
            //    //var aa = table1[0]..ToString();
            //}


            //var list = new WebsiteManager().GetWebsiteList();
            var list = new WebsiteManager().GetWebsiteList();
            ViewBag.list = list;
            var website = list.FirstOrDefault(x => x.id == 1);
            //return View(layoutViewModel);
            //return View(list);
            return View(website);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.WebsiteModel model)
        {
            new WebsiteManager().Create(model);
            return Redirect("/website/index");
        }





        //public ActionResult Update(int id)
        public ActionResult Edit(int id)
        {
            //var finishedTasksList = new TaskManager().GetFinishedTasks(id.ToString());
            //var unfinishedTasksList = new TaskManager().GetUnfinishedTasks(id.ToString());
            //ViewBag.FinishedTasksList = finishedTasksList;
            //ViewBag.UnfinishedTasksList = unfinishedTasksList;

            var model = new Models.WebsiteModel();
            if (id > 0)
            {
                var list = new _1w4w.CMS.Manager.WebsiteManager().GetWebsiteList().ToList();
                model = new _1w4w.CMS.Manager.WebsiteManager().GetWebsiteById(id);
                ViewBag.Website = model;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.WebsiteModel model)
        {
            new WebsiteManager().Update(model);
            return Redirect("/website/index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            new WebsiteManager().Delete(id);
            //return Redirect("/home/index");
            return Redirect("/website/index");
        }
    }
}