using _1w4w.CMS.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Models
{
    public class PageModel
    {
        public int id { get; set; }
        public int websiteid { get; set; }
        public int parentid { get; set; }
        public string name { get; set; }
        public string href { get; set; }
        [AllowHtml]
        public string text1 { get; set; }
        [AllowHtml]
        public string text2 { get; set; }
        [AllowHtml]
        public string text3 { get; set; }
        [AllowHtml]
        public string text4 { get; set; }
        [AllowHtml]
        public string text5 { get; set; }
        [AllowHtml]
        public string text6 { get; set; }
        [AllowHtml]
        public string text7 { get; set; }
        [AllowHtml]
        public string text8 { get; set; }
        [AllowHtml]
        public string text9 { get; set; }
        [AllowHtml]
        public string text10 { get; set; }
    }

    public class PageModelTemp
    {
        [AllowHtml]
        public string ta1 { get; set; }
        [AllowHtml]
        public string ta2 { get; set; }
        [AllowHtml]
        public string ta3 { get; set; }
    }
}