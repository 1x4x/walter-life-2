using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class ContentPartModel
    {
        public int id { get; set; }
        public int contentid { get; set; }
        public int sortorderweight { get; set; }
        public int websiteid { get; set; }
        public int contentparttypeid { get; set; }
    }
}