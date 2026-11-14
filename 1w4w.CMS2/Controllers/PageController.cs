using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateNew()
        {
            new Manager.PageManager().CreateNew();
            return Redirect("/home/index");
        }

        [HttpGet]
        [Route("/page/delete/{id}")]
        public ActionResult Delete(int id)
        {
            new Manager.PageManager().Delete(id);
            
            // If we removed a page with id == 1 then create a new fresh page with id == 1 before redirecting back.
            // If we dont have a page to show the website will not work
            if(id == 1)
            {
                new Manager.PageManager().CreateNew();
            }
            return Redirect("/home/index");
        }
    }
}