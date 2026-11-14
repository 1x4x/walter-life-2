using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Models.Template
{
    public class T1catefoodModel
    {
        public int id {  get; set; }
        public int websiteid {  get; set; }

        // part1start
        public string heading1 { get; set; }
        public string heading2 { get; set; }
        public string backgroundimage { get; set; }
        public string opentimesmontofri { get; set; }
        public string opentimessattosun { get; set; }
        public string opentimeslunch { get; set; }

        // part2services
        public string box1heading { get; set; }
        public string box2heading { get; set; }
        public string box3heading { get; set; }
        public string box4heading { get; set; }
        public string box1text { get; set; }
        public string box2text { get; set; }
        public string box3text { get; set; }
        public string box4text { get; set; }
        public string box1icon { get; set; }
        public string box2icon { get; set; }
        public string box3icon { get; set; }
        public string box4icon { get; set; }
        
        // part3takeaway
        public string part3takeaway_heading1 { get; set; }
        public string part3takeaway_heading2 { get; set; }
        public string part3takeaway_text { get; set; }
        public string part3takeaway_image { get; set; }

        // part4videocarusel
        public string part4videocarusel_slide1_heading1 { get; set; }
        public string part4videocarusel_slide1_heading2 { get; set; }
        public string part4videocarusel_slide1_heading3 { get; set; }
        public string part4videocarusel_slide1_heading4 { get; set; }
        public string part4videocarusel_slide1_text { get; set; }
        public string part4videocarusel_slide1_videourl { get; set; }

        public string part4videocarusel_slide2_heading1 { get; set; }
        public string part4videocarusel_slide2_heading2 { get; set; }
        public string part4videocarusel_slide2_heading3 { get; set; }
        public string part4videocarusel_slide2_heading4 { get; set; }
        public string part4videocarusel_slide2_text { get; set; }
        public string part4videocarusel_slide2_videourl { get; set; }

        public string part4videocarusel_slide3_heading1 { get; set; }
        public string part4videocarusel_slide3_heading2 { get; set; }
        public string part4videocarusel_slide3_heading3 { get; set; }
        public string part4videocarusel_slide3_heading4 { get; set; }
        public string part4videocarusel_slide3_text { get; set; }
        public string part4videocarusel_slide3_videourl { get; set; }


        // part5tablebooking
        public string part5tablebooking_heading1 { get; set; }
        public string part5tablebooking_heading2 { get; set; }
        public string part5tablebooking_buttontext { get; set; }


        // part6contact
        public string part6contactheading1 { get; set; }
        public string part6contactheading2 { get; set; }

        //part6contactcolumn1
        public string part6contactcolumn1heading1 { get; set; }
        public string part6contactcolumn1text1 { get; set; }
        public string part6contactcolumn1text2 { get; set; }

        //part6contactcolumn2
        public string part6contactcolumn2heading1 { get; set; }
        public string part6contactcolumn2text1 { get; set; }
        public string part6contactcolumn2text2 { get; set; }

        // part6contactcolumn3
        public string part6contactcolumn3heading1 { get; set; }
        public string part6contactcolumn3text1 { get; set; }
        public string part6contactcolumn3text2 { get; set; }

        // part6contactcolumn4
        public string part6contactcolumn4heading1 { get; set; }
        public string part6contactcolumn4text1 { get; set; }
        public string part6contactcolumn4text2 { get; set; }


        // part7map
        public string part7mapmapurl { get; set; }

        // part8copyright
        public string part8copyrighttext { get; set; }
        
    }
}