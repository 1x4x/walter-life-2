using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class ThemeController : Controller
    {
        [HttpGet]
        [Route("/theme/settheme/{id}")]
        public ActionResult settheme(int? id)
        {
            //Manager.ThemeManager.UpdateTheme(Convert.ToInt32(id), "dark");
            return Redirect("/home/index/" + id);
        }
    }
}