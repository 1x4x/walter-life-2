using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class TodoViewModel
    {
        public List<TodoModel> TodoList { get; set; }
        public List<TodoCategoryModel> TodoCategoryList { get; set; }
        public List<MonthModel> MonthModelList { get; set; }
    }
}