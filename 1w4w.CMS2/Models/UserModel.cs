using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public int companyid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string isblocked { get; set; }
        public string magiclink { get; set; }
        public string accesslevel { get; set; }
        public string status { get; set; }
        public string imagepath { get; set; }
    }
}