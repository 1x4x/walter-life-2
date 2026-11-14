using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class TodoController : Controller
    {
        public ActionResult Index()
        {
            var model = new Manager.TodoViewModelManager().GetTodoViewModel();
            return View(model);
        }

        public ActionResult Calendar()
        {
            var model = new Manager.TodoViewModelManager().GetTodoViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("/todo/createtodo")]
        public ActionResult CreateTodo(TodoModel model)
        {
            new Manager.TodoManager().Create(model);
            return Redirect("/home/index");
        }

        [HttpGet]
        [Route("/todo/setstatuscomplete/{id}")]
        public ActionResult SetStatusComplete(int id)
        {

            new Manager.TodoManager().SetStatus("complete", id);
            return Redirect("/home/index");
        }
        [HttpGet]
        [Route("/todo/setstatusincomplete/{id}")]
        public ActionResult SetStatusIncomplete(int id)
        {

            new Manager.TodoManager().SetStatus("incomplete", id);
            return Redirect("/home/index");
        }

        [HttpGet]
        [Route("/todo/deletetodo")]
        public ActionResult DeleteTodo(int id)
        {
            new Manager.TodoManager().Delete(id);
            return Redirect("/home/index");
        }
    }
}