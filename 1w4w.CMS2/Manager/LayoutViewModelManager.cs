using _1w4w.CMS.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1w4w.CMS.Manager
{
    public class LayoutViewModelManager
    {
        public static _1w4w.CMS.Models.LayoutViewModel GetLayoutViewModel()
        {
            //new _1w4w.CMS.Manager.PageManager().aaa();

            //string host = HttpContext.Current.Request.Url.Host.ToLower();

            //var templateList = TemplateManager.GetTemplateList();
            var layoutViewModel = new Models.LayoutViewModel
            {
                //templates = templateList
            };

            // cateringorder + cateringorderrow
            layoutViewModel.CateringOrderModels = CateringOrderManager.GetCateringOrderList();
            layoutViewModel.CateringOrderRowModels = CateringOrderManager.GetCateringOrderRowList();
            
            
            
            layoutViewModel.TodoList = new Manager.TodoManager().GetList();
            layoutViewModel.TodoCategoryList = new Manager.TodoCategoryManager().GetList();
            
            layoutViewModel.UploadedFileModels = Manager.FileManager.GetFileList();
            layoutViewModel.UploadedImageModels = Manager.FileManager.GetImageList();
            
            layoutViewModel.UploadedImageCategoryModels = new UploadedImageCategoryManager().GetUploadedImageCategoryList();
            layoutViewModel.UploadedFileCategoryModels = new UploadedFileCategoryManager().GetUploadedFileCategoryList();


            layoutViewModel.Templates = TemplateManager.GetTemplateList();
            if (new ProductCategoryManager().GetProductCategoryList() != null)
            {
                layoutViewModel.ProductCategories = new ProductCategoryManager().GetProductCategoryList();
            }
            var products = new ProductManager().GetProductList();
            if (products != null)
            {
                layoutViewModel.Products = new ProductManager().GetProductList().ToList();
            }

            var pagePartModels = PagePartManager.GetPagePartList();
            layoutViewModel.PagePartModels = pagePartModels;

            var pageModels = PageManager.GetPageList();
            layoutViewModel.PageModels = pageModels;

            //layoutViewModel.PageModel = new PageManager().GetPageList().FirstOrDefault(x => x.websiteid == 1);

            string websiteid = System.Web.Configuration.WebConfigurationManager.AppSettings["websiteid"];

            var websites = new WebsiteManager().GetWebsiteList();
            layoutViewModel.Websites = websites;
            var website = websites.Single(x => x.id == Convert.ToInt32(websiteid));
            layoutViewModel.Website = website;

            // settings
            string domainfromcurrenturl = HttpContext.Current.Request.Url.Host.ToLower();
            var domainfromwebsitetable = websites.SingleOrDefault(x => x.domain == domainfromcurrenturl);
            var domainfromwebsitetablestring = "";
            if (domainfromwebsitetable != null)
            {
                domainfromwebsitetablestring = domainfromwebsitetable.domain;
            }
            if (domainfromcurrenturl == "localhost") { domainfromwebsitetablestring = "walter.nu"; }




            //if (host == "localhost" || host.Contains("energikällan.net") || host.Contains("dev.xn--energikllan-r8a.net"))
            if (domainfromcurrenturl.Contains(domainfromwebsitetablestring))
            {
                //var website = new WebsiteManager().GetWebsiteByDomain(domainfromwebsitetablestring);
                
                
                //var website = new WebsiteManager().GetWebsiteByDomain("energikällan.net");
                //layoutViewModel.Website  = website;
                layoutViewModel.Template = TemplateManager.GetTemplate(website.template);
                //layoutViewModel.Template = TemplateManager.GetTemplate(3);
                layoutViewModel.t1catefoodModel = Template.T1Manager.GettPopulatedt1catefood("1");
                //layoutViewModel.t1catefoodModel = template.t1Manager.GettPopulatedt1catefood("1");

                layoutViewModel.CateringOrderModels = _1w4w.CMS.Manager.CateringOrderManager.GetCateringOrderList();
                layoutViewModel.CateringOrderRowModels = _1w4w.CMS.Manager.CateringOrderManager.GetCateringOrderRowList();
                
            }

            var todaysLunchModelList = _1w4w.CMS.Manager.TodaysLunchManager.GetTodaysLunchModels();
            layoutViewModel.TodaysLunchModels = todaysLunchModelList;




            //var layoutViewModel = new _1w4w.CMS.Models.LayoutViewModel
            //{
            //    templates = templateList,
            //    BaseUrl = "/content/template/catefood"
            //};

            //@Model _1w4w.CMS.Models.LayoutViewModel
            //ViewBag.LayoutViewModel = layoutViewModel;
            //var unfinishedProjectsList = new ProjectManager().GetUnfinishedProjects();
            //var finishedProjectsList = new ProjectManager().GetFinishedProjects();
            //var finishedTasksList = new TaskManager().GetFinishedTasks();
            //var unfinishedTasksList = new TaskManager().GetUnfinishedTasks();
            //ViewBag.UnfinishedProjectsList = unfinishedProjectsList;
            //ViewBag.FinishedProjectsList = finishedProjectsList;
            //ViewBag.FinishedTasksList = finishedTasksList;
            //ViewBag.UnfinishedTasksList = unfinishedTasksList;
            //layoutViewModel.Website = new WebsiteManager().GetWebsiteByDomain(host);



            // check if we have a logged in user/admin
            _1w4w.CMS.Models.UserModel usermodel = (_1w4w.CMS.Models.UserModel)HttpContext.Current.Session["User"] as _1w4w.CMS.Models.UserModel;
            layoutViewModel.usermodel = (_1w4w.CMS.Models.UserModel)HttpContext.Current.Session["User"] as _1w4w.CMS.Models.UserModel;
            //var accesslevel = usermodel.accesslevel ?? "";

            
            
            // counts
            var listCounts = new _1w4w.CMS.Manager.TodoManager().GetListCounts();
            layoutViewModel.listcounts = listCounts;

            return layoutViewModel;
        }
    }
}