using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models
{
    public class MonthModel
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public string janretrospect { get; set; }
        public string febretrospect { get; set; }
        public string marretrospect { get; set; }
        public string aprretrospect { get; set; }
        public string mayretrospect { get; set; }
        public string junretrospect { get; set; }
        public string julretrospect { get; set; }
        public string augretrospect { get; set; }
        public string sepretrospect { get; set; }
        public string octretrospect { get; set; }
        public string novretrospect { get; set; }
        public string decretrospect { get; set; }


        public string janextracosts { get; set; }
        public string febextracosts { get; set; }
        public string marextracosts { get; set; }
        public string aprextracosts { get; set; }
        public string mayextracosts { get; set; }
        public string junextracosts { get; set; }
        public string julextracosts { get; set; }
        public string augextracosts { get; set; }
        public string sepextracosts { get; set; }
        public string octextracosts { get; set; }
        public string novextracosts { get; set; }
        public string decextracosts { get; set; }



        public string janbirthdays { get; set; }
        public string febbirthdays { get; set; }
        public string marbirthdays { get; set; }
        public string aprbirthdays { get; set; }
        public string maybirthdays { get; set; }
        public string junbirthdays { get; set; }
        public string julbirthdays { get; set; }
        public string augbirthdays { get; set; }
        public string sepbirthdays { get; set; }
        public string octbirthdays { get; set; }
        public string novbirthdays { get; set; }
        public string decbirthdays { get; set; }



        public string color { get; set; }
        public string text { get; set; }
    }
}