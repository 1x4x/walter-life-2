using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class CateringOrderController : Controller
    {
        // GET: CateringOrder
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("/cateringorder/setasordered/{id}")]
        public ActionResult setasordered(int? id)
        {
            Manager.CateringOrderManager.UpdateStatus(Convert.ToInt32(id), "ordered");
            return Redirect("/home/index/" + id);
        }

        [HttpGet]
        [Route("/cateringorder/setasdelivered/{id}")]
        public ActionResult setasdelivered(int? id)
        {
            Manager.CateringOrderManager.UpdateStatus(Convert.ToInt32(id), "delivered");
            return Redirect("/home/index/" + id);
        }

        [HttpGet]
        [Route("/cateringorder/setasannulled/{id}")]
        public ActionResult setasannulled(int? id)
        {
            Manager.CateringOrderManager.UpdateStatus(Convert.ToInt32(id), "annulled");
            return Redirect("/home/index/" + id);
        }

        //[HttpPost]
        //[Route("/cateringorder/updatestatus")]
        ////public ActionResult UpdateStatus(int id, string status)
        //public ActionResult UpdateStatus(FormCollection collection)
        //{
        //    // update status of a cateringorder (ordered, delivered, annulled)
        //    var id = collection["id"];
        //    var status = collection["status"];
        //    Manager.CateringOrderManager.UpdateStatus(Convert.ToInt32(id), status);
        //    return Redirect("/home/index/" + id);
        //}
    }
}