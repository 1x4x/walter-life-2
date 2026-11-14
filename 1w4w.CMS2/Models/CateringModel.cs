using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class CateringModel
    {
        public int id { get; set; }
        public int websiteid { get; set; }
        public string name { get; set; }
        public string artnr { get; set; }
        public string imageurl { get; set; }
        public string barcodeimageurl { get; set; }
    }
}