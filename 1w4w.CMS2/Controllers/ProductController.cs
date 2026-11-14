using _1w4w.CMS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var list = new ProductManager().GetProductList();
            ViewBag.list = list;
            //return View(Enumerable.Empty<Models.ProductModel>());
            //return View(Enumerable.Empty<Models.ProductModel>());
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.ProductModel model)
        {
            new ProductManager().Create(model);
            //return Redirect("/product/index");
            return Redirect("/product/create");
        }

        public ActionResult Edit(int id)
        {
            var model = new Models.ProductModel();
            if (id > 0)
            {
                var list = new _1w4w.CMS.Manager.ProductManager().GetProductList().ToList();
                //var list = Enumerable.Empty<Models.ProductModel>();
                model = new _1w4w.CMS.Manager.ProductManager().GetProductById(id, list.ToList());
                ViewBag.Website = model;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Models.ProductModel model)
        {
            new ProductManager().Update(model);
            return Redirect("/product/index");
        }


        public ActionResult Delete(int id)
        {
            new ProductManager().Delete(id);
            return Redirect("/product/index");
        }
    }
}