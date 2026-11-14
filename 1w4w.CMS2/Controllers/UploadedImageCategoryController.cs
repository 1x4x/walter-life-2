using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace _1w4w.CMS.Controllers
{
    public class UploadedImageCategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/uploadedimagecategory/create")]
        public ActionResult Create(_1w4w.CMS.Models.UploadedImageCategoryModel model)
        {
            new Manager.UploadedImageCategoryManager().Create(model);
            return Redirect("/home/index/");
        }


        [HttpPost]
        [Route("/uploadedimagecategory/upload")]
        public ActionResult Upload(_1w4w.CMS.Models.UploadedImageCategoryModel model)
        {
            new Manager.UploadedImageCategoryManager().Update(model);
            return Redirect("/home/index/");
        }


        [HttpGet]
        [Route("/uploadedimagecategory/delete")]
        public ActionResult Delete(int id)
        {
            new Manager.UploadedImageCategoryManager().Delete(id);
            return Redirect("/home/index/");
        }
    }
}