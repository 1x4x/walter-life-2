using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class TodoBoardModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int sortorder { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public string backgroundcolor { get; set; }
        public string status { get; set; }
        public int hidden { get; set; }
    }
}