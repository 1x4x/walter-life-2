using _1w4w.CMS.Manager;
using _1w4w.CMS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class TodaysLunchController : Controller
    {
        // GET: TodaysLunch
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        [AllowAnonymous]
        public ActionResult UpdatePart1(Models.PageModel model)
        {
            int pageid = 0;
            // if we dont have pageid create 1 new row for us
            if (model.id == 0)
            {
                pageid = new _1w4w.CMS.Manager.PageManager().Create(model);
            }

            // now we can be sure we have a pageid :) nice!


            // see if we have a row for this pageid
            var pageexistingalreadymodel = _1w4w.CMS.Manager.PageManager.GetPageList().Where(x => x.id == model.id).SingleOrDefault();
            if (pageexistingalreadymodel == null)
            {
                // create 1 new row for us
                pageid = new _1w4w.CMS.Manager.PageManager().Create(model);
            }
            else
            {
                // update our existing row
                pageid = new _1w4w.CMS.Manager.PageManager().Update(model);
            }

            return Redirect("/home/index/" + pageid);
        }


    }
}