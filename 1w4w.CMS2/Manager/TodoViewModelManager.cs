using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _1w4w.CMS.Manager;

namespace _1w4w.CMS.Manager
{
    public class TodoViewModelManager
    {
        public Models.TodoViewModel GetTodoViewModel()
        {
            var model = new Models.TodoViewModel();
            model.TodoList = new Manager.TodoManager().GetList();
            model.TodoCategoryList = new Manager.TodoCategoryManager().GetList();
            model.MonthModelList = new Manager.MonthManager().GetList();
            return model;
        }
    }
}