using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Views.Shared.Energy
{
    public class OrderCreateViewModel
    {       
        public string fullname { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string orgnr { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        [AllowHtml]
        public string ordercontainer2 { get; set; }
        [AllowHtml]
        public string ordercontainer2cleandata { get; set; }
    }
}