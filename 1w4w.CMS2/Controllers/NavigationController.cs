using _1w4w.CMS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class NavigationController : Controller
    {
        public ActionResult Index()
        {
            var list = PageManager.GetPageList();
            ViewBag.list = list;
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.PageModel model)
        {
            new PageManager().Create(model);
            return Redirect("/navigation/index");
        }





        public ActionResult Edit(int id)
        {
            var model = new Models.PageModel();
            if (id > 0)
            {
                var list = _1w4w.CMS.Manager.PageManager.GetPageList().ToList();
                model = new _1w4w.CMS.Manager.PageManager().GetPageById(id, list);
                ViewBag.Website = model;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.PageModel model)
        {
            new PageManager().Update(model);
            return Redirect("/navigation/index");
        }


        public ActionResult Delete(int id)
        {
            new PageManager().Delete(id);
            return Redirect("/navigation/index");
        }
    }
}