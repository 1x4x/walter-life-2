using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class UserReadBookModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string authors { get; set; }
        public string isbn { get; set; }
        public string published { get; set; }
        public string language { get; set; }
        public int pagecount { get; set; }
        public int userid { get; set; }
        public int currentreadingpage { get; set; }
        public string imageurl { get; set; }
    }
}