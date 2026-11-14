using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Models
{
    public class PagePartModel
    {
        public int id { get; set; }
        // the website this content is belonging to
        public int websiteid { get; set; }
        // the page on that website that the content belongs to
        public int pageid { get; set; }
        // placementid is used to know where the content will be shown on the page.
        // for example if we have a 2 column layout the content belonging 
        // to the left column will have placementid=1 and all contentparts
        // with pageid=1 (for example) and placementid=1 will be placed in 
        // the left column. content with placementid=2 will be placed in the right column. 
        // we can use 3..4..5.. if we need more places where we want to put content on the page
        // when we want to loop out content on the page we use pageid = 1 && placementid = 1 to  
        // get all the content that should be shown in that column and sortorder to know wich
        // content will come before other content
        public int placementid { get; set; }
        // used to know in wich order the content will be shown
        public int sortorder { get; set; }
        // used to know if the content is text, html, image...
        public string parttype { get; set; }
        // if its image used to know the path of the image
        public string imagepath { get; set; }
        // if wanting to show text under the image
        [AllowHtml]
        public string imagetext { get; set; }
        // possibility to style the pagepart
        [AllowHtml]
        public string pagepartstyle { get; set; }
        // used to store the text collected from form field if type=text or type=html
        [Description ]
        [AllowHtml]
        public string pageparttext { get; set; }
        [AllowHtml]
        public string colors { get; set; }
    }
}