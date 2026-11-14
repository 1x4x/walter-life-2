using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class CateringOrderRowModel
    {
        public int id { get; set; }
        public int websiteid { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
        public string status { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public int amount { get; set; }
        public string artnr { get; set; }
        public string name { get; set; }
    }
}