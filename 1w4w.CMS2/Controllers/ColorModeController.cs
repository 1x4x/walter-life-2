using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class ColorModeController : Controller
    {
        [HttpGet]
        [Route("/colormode/setdarkmode/{id}")]
        public ActionResult setdarkmode(int id)
        {
            Manager.ColorModeManager.SetMode(_1w4w.CMS.Manager.ColorModeManager.ColorMode.Dark, id);
            return Redirect("/home/index/" + id);
        }

        [HttpGet]
        [Route("/colormode/setlightmode/{id}")]
        public ActionResult setlightmode(int id)
        {
            Manager.ColorModeManager.SetMode(_1w4w.CMS.Manager.ColorModeManager.ColorMode.Light, id);
            return Redirect("/home/index/" + id);
        }
    }
}