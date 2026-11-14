using _1w4w.CMS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml;

namespace _1w4w.CMS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [Route("/user/logout")]
        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect("/home/index?m=3"); // you have been logged out
        }

        [AllowAnonymous]
        //[Route("/user/login/{magiclink}")]
        [Route("/user/magiclogin/{id}")]
        public ActionResult MagicLogin(string id)
        {
            //magiclink = Request.QueryString["magiclink"];
            //                                                                    
            if (id != "")
            {
                var usermodel = new UserManager().Login(id);
                if (usermodel != null)
                {
                    return Redirect("/home/index?m=1"); // you are logged in
                }
            }
            return Redirect("/home/index?m=2");  // failed to login
        }
    }
}