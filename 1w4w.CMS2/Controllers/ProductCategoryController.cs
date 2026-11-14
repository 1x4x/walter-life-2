using _1w4w.CMS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class ProductCategoryController : Controller
    {
        public ActionResult Index()
        {
            var list = new ProductCategoryManager().GetProductCategoryList();
            ViewBag.list = list;
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.ProductCategoryModel model)
        {
            new ProductCategoryManager().Create(model);
            return Redirect("/productcategory/index");
        }





        public ActionResult Edit(int id)
        {
            var model = new Models.ProductCategoryModel();
            if (id > 0)
            {
                var list = new _1w4w.CMS.Manager.ProductCategoryManager().GetProductCategoryList().ToList();
                model = new _1w4w.CMS.Manager.ProductCategoryManager().GetProductCategoryById(id, list);
                ViewBag.Website = model;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.ProductCategoryModel model)
        {
            new ProductCategoryManager().Update(model);
            return Redirect("/productcategory/index");
        }


        public ActionResult Delete(int id)
        {
            new ProductCategoryManager().Delete(id);
            return Redirect("/productcategory/index");
        }
    }
}