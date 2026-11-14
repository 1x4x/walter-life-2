using _1w4w.CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Manager
{
    public class ContentPartManager
    {
        public List<ContentPartModel> GetContentPartList()
        {
            var list = new List<ContentPartModel>();
            return list;
        }
        public List<ContentPartTopicModel> GetContentPartTopicModelList()
        {
            var list = new List<ContentPartTopicModel>();
            return list;
        }

        public void AddContentPart(ContentPartModel model)
        {
        
        }

        public void AddContentPartTopic(ContentPartTopicModel model)
        {

        }

    }
}