using _1w4w.CMS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            var unfinishedProjectsList = new ProjectManager().GetUnfinishedProjects();
            var finishedProjectsList = new ProjectManager().GetFinishedProjects();
            var finishedTasksList = new TaskManager().GetFinishedTasks();
            var unfinishedTasksList = new TaskManager().GetUnfinishedTasks();
            ViewBag.UnfinishedProjectsList = unfinishedProjectsList;
            ViewBag.FinishedProjectsList = finishedProjectsList;
            ViewBag.FinishedTasksList = finishedTasksList;
            ViewBag.UnfinishedTasksList = unfinishedTasksList;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.ProjectModel model)
        {
            new ProjectManager().Create(model);
            return Redirect("/home/index");
        }



        public ActionResult Update(int id)
        {
            var finishedTasksList = new TaskManager().GetFinishedTasks(id.ToString());
            var unfinishedTasksList = new TaskManager().GetUnfinishedTasks(id.ToString());
            ViewBag.FinishedTasksList = finishedTasksList;
            ViewBag.UnfinishedTasksList = unfinishedTasksList;

            var model = new Models.ProjectModel();
            if (id > 0)
            {
                model = new _1w4w.CMS.Manager.ProjectManager().Read(id);
                ViewBag.Project = model;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Models.ProjectModel model)
        {
            new ProjectManager().Update(model);
            return Redirect("/home/index");
        }


        public ActionResult Delete(int id)
        {
            new ProjectManager().Delete(id);
            return Redirect("/home/index");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}