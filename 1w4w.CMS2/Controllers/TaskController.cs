using _1w4w.CMS.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            var unfinishedProjectsList = new ProjectManager().GetUnfinishedProjects();
            var finishedProjectsList = new ProjectManager().GetFinishedProjects();
            //var finishedTasksList = new TaskManager().GetFinishedTasks();
            //var unfinishedTasksList = new TaskManager().GetUnfinishedTasks();
            ViewBag.UnfinishedProjectsList = unfinishedProjectsList;
            ViewBag.FinishedProjectsList = finishedProjectsList;
            //ViewBag.FinishedTasksList = finishedTasksList;
            //ViewBag.UnfinishedTasksList = unfinishedTasksList;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.TaskModel model)
        {
            new TaskManager().Create(model);
            //return Redirect("/home/index");
            return Redirect("/home/update/" + model.id);
        }



        public ActionResult Update(int id)
        {
            //var finishedTasksList = new TaskManager().GetFinishedTasks();
            //var unfinishedTasksList = new TaskManager().GetUnfinishedTasks();
            //ViewBag.FinishedTasksList = finishedTasksList;
            //ViewBag.UnfinishedTasksList = unfinishedTasksList;

            var model = new Models.TaskModel();
            if (id > 0)
            {
                model = new _1w4w.CMS.Manager.TaskManager().Read(id);
                ViewBag.Task = model;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Models.TaskModel model)
        {
            new TaskManager().Update(model);
            return Redirect("/home/index");
        }


        public ActionResult Delete(int id)
        {
            new TaskManager().Delete(id);
            return Redirect("/home/index");
        }
    }
}