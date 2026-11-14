using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class TodoModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int sortorder { get; set; }
        public string todotext { get; set; }
        public string color { get; set; }
        public string backgroundcolor { get; set; }
        public string status { get; set; }
        public int category { get; set; }
        public int hidden { get; set; }
        
        
        public int boardid { get; set; }
        public string todotype { get; set; }
        public string todoextratext { get; set; }
        public string todoonthesedaysinmonth { get; set; }
        public string tododate { get; set; }
        public string todotime { get; set; }
        public string todocustombordercolor { get; set; }
    }
}