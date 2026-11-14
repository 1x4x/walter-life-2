using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class WebsiteModel
    {
        public int id { get; set; }
        public int template { get; set; }
        public string name { get; set; }
        public string domain { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string keywords { get; set; }
        public string logoimageurl { get; set; }
        public string copyright { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string city { get; set; }
        public string opentimesmontofri { get; set; }
        public string opentimessattosun { get; set; }
        public string lunchtime { get; set; }
        public string sociallinkfacebook { get; set; }
        public string sociallinktwitter { get; set; }
        public string sociallinkinstagram { get; set; }
        public string sociallinkyoutube { get; set; }
        public string logo1 { get; set; }
        public string logo2 { get; set; }
        public string logo3 { get; set; }
    }
}