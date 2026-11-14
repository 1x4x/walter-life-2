using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public int websiteid { get; set; }
        public int productcategoryid { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string extrainfo { get; set; }
    }
}