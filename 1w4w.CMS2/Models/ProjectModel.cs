using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class ProjectModel
    {
        public int id { get; set; } 
        public string title { get; set; } 
        public string owner { get; set; } 
        public string status { get; set; } 
        public int percentcompleted { get; set; } 
    }
}