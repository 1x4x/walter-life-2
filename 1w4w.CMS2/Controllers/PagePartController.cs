using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class PagePartController : Controller
    {
        // GET: PagePart
        public ActionResult Index()
        {
            return View();
        }
        // arbetsformedlingen@walters.nu / AoiupoiG34!
        [HttpPost]
        [Route("/pagepart/addparthtml")]
        //public ActionResult Add(PagePartViewModel model)
        //public ActionResult AddPartHtml(FormCollection collection)
        public ActionResult AddPartHtml(PagePartModel model)
        {
             new Manager.PagePartManager().CreateHtmlPagePart(model);
            
            // redirect back to the page we were on
            //return Redirect("/home/index/");
            return Redirect("/home/index/" + model.pageid);
        }

        
        [HttpPost]
        [Route("/pagepart/addpartimage/{id}")]
        public ActionResult AddPartImage(int id, PagePartModel model)
        {
            new Manager.PagePartManager().CreateImagePagePart(model);

            // redirect back to the page we were on
            //return Redirect("/home/index/");
            //return Redirect("/home/index/" + model.pageid);
            return Redirect("/home/index/" + id);
        }


        [HttpPost]
        [Route("/pagepart/addparttext")]
        public ActionResult AddPartText(PagePartModel model)
        {
            new Manager.PagePartManager().CreateTextPagePart(model);

            // redirect back to the page we were on
            //return Redirect("/home/index/");
            return Redirect("/home/index/" + model.pageid);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("/pagepart/pageupdate")]
        public ActionResult pageupdate(PageModelTemp model)
        //public ActionResult pageupdate([AllowHtmlAttribute] string ta1, string ta2, string ta3)
        {
            //T1Manager.UpdatePart1startHeadings(websiteid, heading1, heading2, opentimesmontofri, opentimessattosun, opentimeslunch);
            return Redirect("/home/index");
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("/pagepart/delete/{id}-{pageid}")]
        public ActionResult delete(int id, int pageid)
        //public ActionResult pageupdate([AllowHtmlAttribute] string ta1, string ta2, string ta3)
        {
            new Manager.PagePartManager().Delete(id);
            //return Redirect("/home/index");
            var referer = HttpContext.Request.UrlReferrer;

            return Redirect("/home/index/" + pageid);
        }

        //  PagePartManager
    }
}