using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class CateringOrderModel
    {
        public int id { get; set; }
        public int websiteid { get; set; }
        public string status { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string orgnr { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}