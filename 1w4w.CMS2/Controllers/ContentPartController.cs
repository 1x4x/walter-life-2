using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class ContentPartController : Controller
    {
        // GET: ContentPart
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("/contentpart/addtopic")]
        //public ActionResult Add(ContentPartViewModel model)
        public ActionResult AddTopic(FormCollection collection)
        {
            // iterate form collection items
            //foreach (string key in collection.AllKeys)
            //{
            //    Response.Write("Key=" + key + " ");
            //    var value = collection[key];
            //    Response.Write("Value=" + value);
            //    Response.Write("<br/>");
            //}



            // get values from form fields
            var topictextinput = collection[0];
            var topicHeading = collection[1];
            var contentId = collection[2];


            // init & read from file
            //var manager = new JsonManager();


            // ContentPartModel
            // ContentPartTopicModel
            var contentpartlist = new Manager.ContentPartManager().GetContentPartList();
            var contentparttopicmodellist = new Manager.ContentPartManager().GetContentPartTopicModelList();


            // if we have items in the list find the highest id
            var highestid = contentparttopicmodellist.Count();


            // map values to the correct names in contentparttopic.json and add to the json file
            ContentPartTopicModel modeltoadd = new ContentPartTopicModel();
            modeltoadd.id = (highestid + 1);
            modeltoadd.topictextinput = topictextinput;
            modeltoadd.topicHeading = topicHeading;


            // map values to the correct names in contentpart.json and add to the json file
            ContentPartModel contentPartModelToAdd = new ContentPartModel();
            contentPartModelToAdd.id = (highestid + 1);
            contentPartModelToAdd.contentid = Convert.ToInt32(contentId);
            contentPartModelToAdd.contentparttypeid = 1;
            contentPartModelToAdd.sortorderweight = (highestid + 1);
            //contentPartModelToAdd.SiteId = ;


            // add our new contentpartmodel to our list of contentpartmodels
            contentpartlist.Add(contentPartModelToAdd);


            // add our new model to our list of models
            contentparttopicmodellist.Add(modeltoadd);
            new Manager.ContentPartManager().AddContentPart(contentPartModelToAdd);
            new Manager.ContentPartManager().AddContentPartTopic(modeltoadd);

            // write to contentparttopic.json file
            // write to contentpart.json file

            // redirect back to the page we were on
            return Redirect("/home/index/" + contentId);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("/contentpart/pageupdate")]
        public ActionResult pageupdate(PageModelTemp model)
        //public ActionResult pageupdate([AllowHtmlAttribute] string ta1, string ta2, string ta3)
        {
            //T1Manager.UpdatePart1startHeadings(websiteid, heading1, heading2, opentimesmontofri, opentimessattosun, opentimeslunch);
            return Redirect("/home/index");
        }

        
    }
}