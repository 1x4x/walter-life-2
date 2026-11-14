using _1w4w.CMS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class EconomyController : Controller
    {
        public ActionResult Index()
        {
            //var template = _1w4w.CMS.Manager.TemplateManager.GetTemplate();

            //var layoutViewModel = new _1w4w.CMS.Models.LayoutViewModel
            //{
            //    templateModel = template,
            //    BaseUrl = "/content/template/catefood"
            //};

            //var productCategories = new _1w4w.CMS.Manager.ProductCategoryManager().GetProductCategoryList();
            //var allProducts = new _1w4w.CMS.Manager.ProductManager().GetProductList().ToList();

            //layoutViewModel.ProductCategories = productCategories;
            //layoutViewModel.Products = allProducts;

            //return View(layoutViewModel);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.ProjectModel model)
        {
            //new ProjectManager().Create(model);
            return Redirect("/home/index");
        }
    }
}