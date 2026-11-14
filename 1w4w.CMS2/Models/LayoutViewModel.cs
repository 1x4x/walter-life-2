using _1w4w.CMS.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Models
{
    public class LayoutViewModel
    {
        public List<CateringOrderModel> CateringOrderModels { get; set; }
        public List<CateringOrderRowModel> CateringOrderRowModels { get; set; }
        public List<ProductModel> Products { get; set; }
        public List<ProductCategoryModel> ProductCategories { get; set; }
        public List<TemplateModel> Templates { get; set; }
        public TemplateModel Template { get; set; }
        public List<WebsiteModel> Websites { get; set; }
        public WebsiteModel Website { get; set; }
        public List<PageModel> PageModels { get; set; }
        public List<PagePartModel> PagePartModels { get; set; }
        //public PageModel PageModel { get; set; }
        public T1catefoodModel t1catefoodModel { get; set; }
        public string tellink { get; set; }
        public string baseUrl { get; set; }
        public List<UploadedFileModel> UploadedFileModels { get; set; }
        public List<UploadedImageModel> UploadedImageModels { get; set; }
        public List<UploadedImageCategoryModel> UploadedImageCategoryModels { get; set; }
        public List<UploadedFileCategoryModel> UploadedFileCategoryModels { get; set; }
        public List<TodaysLunchModel> TodaysLunchModels { get; set; }
        public List<TodoModel> TodoList { get; set; }
        public List<TodoCategoryModel> TodoCategoryList { get; set; }
        
        //public TemplateModel template = Manager.TemplateManager.GetTemplate();
        //public List<TemplateModel> templates = Manager.TemplateManager.GetTemplateList();
        //public List<WebsiteModel> websites = new Manager.WebsiteManager().GetWebsiteList();
        //public WebsiteModel website = new Manager.WebsiteManager().GetWebsiteList().First(x => x.id == 1);
        //public WebsiteModel website = new _1w4w.CMS.Manager.WebsiteManager().GetWebsiteList().SingleOrDefault(x => x.id == 1);
        //public string tellink = new _1w4w.CMS.Manager.WebsiteManager().GetTelLinkFromPhonenumber(new _1w4w.CMS.Manager.WebsiteManager().GetWebsiteList().FirstOrDefault(x => x.id == 1).phone);
        //public List<NavigationModel> navigationModels = new _1w4w.CMS.Manager.NavigationManager().GetNavigationList().Where(x => x.websiteid.Equals(website.id)).ToList();
        //public t1catefood t1catefood = new _1w4w.CMS.Models.template.t1catefood();
        // model WebSite.Models.BaseViewModel
        // ViewBag.LayoutViewModel.BaseUrl
        //[ChildActionOnly]
        //public ActionResult Alerts()
        //{
        //    var vm = new LayoutViewModel { BaseUrl = "abcdefg/aaa" };
        //    return PartialView(vm);
        //}
        //public List<ProductCategoryModel> productCategoryModelList = _1w4w.CMS.Manager.ProductCategoryManager.GetTemplate();

        public UserModel usermodel { get; set; }
        public TodoListCountsModel listcounts { get; set; }


    }
}