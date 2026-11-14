using _1w4w.CMS.Manager;
using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class PokerController : Controller
    {
        public ActionResult Index()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }

        public ActionResult Diary()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }
        public ActionResult Bots()
        {
            LayoutViewModel layoutViewModel = LayoutViewModelManager.GetLayoutViewModel();
            return View(layoutViewModel);
        }
    }
}