using _1w4w.CMS.Manager;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class UserReadBookController : Controller
    {
        // GET: UserReadBook
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUserReadBook(UserReadBookModel model)
        {
            UserReadBookManager.Update(model);
            return Redirect("/home/book");
        }

        [HttpGet]
        [Route("/userreadbook/deleteuserreadbook/{id}")]
        public ActionResult DeleteUserReadBook(int id)
        {
            UserReadBookManager.Delete(id);
            return Redirect("/home/book");
        }
        
        //
    }
}