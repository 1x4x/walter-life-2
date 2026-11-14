using _1w4w.CMS.Manager;
using _1w4w.CMS.Models;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static _1w4w.CMS.Manager.ColorManager;

namespace _1w4w.CMS.Controllers
{
    public class FileController : Controller
    {
        // Upload Multiple Files In MVC ASP.NET
        // https://stackoverflow.com/questions/62447777/upload-multiple-files-in-mvc-asp-net

        // Uploada large files
        // https://stackoverflow.com/questions/16287706/how-to-upload-large-files-using-mvc-4
        /*
            <security>
                <requestFiltering>
                    <requestLimits maxAllowedContentLength="5024000000" />
                </requestFiltering>
            </security>         
         */



        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult FileUpload(HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {
        //        string filename = System.IO.Path.GetFileName(file.FileName);
        //        string path = System.IO.Path.Combine(Server.MapPath("~/content/upload/file"), filename);
        //        // file is uploaded
        //        file.SaveAs(path);

        //        // save the image path path to the database or you can send image 
        //        // directly to database
        //        // in-case if you want to store byte[] ie. for DB
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            file.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }

        //    }
        //    // after successfully uploading redirect the user
        //    return Redirect("/home/index");
        //}

        //public ActionResult ImageUpload(HttpPostedFileBase file)
        //{
        //    if (file != null)
        //    {
        //        string filename = System.IO.Path.GetFileName(file.FileName);
        //        string path = System.IO.Path.Combine(Server.MapPath("~/content/upload/image"), filename);
        //        // file is uploaded
        //        file.SaveAs(path);

        //        // save the image path path to the database or you can send image 
        //        // directly to database
        //        // in-case if you want to store byte[] ie. for DB
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            file.InputStream.CopyTo(ms);
        //            byte[] array = ms.GetBuffer();
        //        }

        //    }
        //    // after successfully uploading redirect the user
        //    return Redirect("/home/index");
        //}
        [HttpPost]
        [Route("/file/fileupload")]
        public ActionResult FileUpload(List<HttpPostedFileBase> uploadedfiles)
        {
            string path = Server.MapPath("~/content/upload/file");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (HttpPostedFileBase pFile in uploadedfiles)
            {
                if (pFile != null)
                {
                    //string path = System.IO.Path.Combine(Server.MapPath("~/content/upload/file"), filename);
                    string fileName = Path.GetFileName(pFile.FileName);
                    string pathandfilename = Path.Combine(path, fileName);
                    pFile.SaveAs(pathandfilename);
                    //save file filename to database
                    var model = new Models.UploadedFileModel();
                    model.name = fileName;
                    new _1w4w.CMS.Manager.FileManager().CreateUploadedFile(model);
                    ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                }
            }
            return Redirect("/home/index");
        }


        //[HttpPost]
        //[Route("/file/mupploadimage")]
        //public ActionResult Mupploadimage()
        //{
        //    foreach (var file in Request.Files)
        //    {
        //        file.SaveAs(Server.MapPath("~/Update/" + file.FileName));
        //    }
        //    return View();
        //}
        // 

        [HttpPost]
        [Route("/file/savecroppedimage")]
        public ActionResult SaveCroppedImage()
        {
            //string filename = Request.Form["filename"];
            string base64 = Request.Form["imgcropped"];
            byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
            //using (FileStream stream = new FileStream(Server.MapPath("/content/upload/images/cropped.png"), FileMode.Create))
            //using (FileStream stream = new FileStream(Server.MapPath("/content/upload/images/" + filename), FileMode.Create))
            using (FileStream stream = new FileStream(Server.MapPath("/content/upload/images/00test1243.png"), FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }
            return RedirectToAction("index", "home");
        }

        [HttpGet] 
        [Route("/file/updateimagepath/{pagepartid}-{uploadedimageid}")]
        public ActionResult Updateimagepath(string pagepartid, string uploadedimageid)
        {
            pagepartid = pagepartid.Replace("-","");

            // get the filename
            string filename = _1w4w.CMS.Manager.FileManager.GetImageList().SingleOrDefault(x => x.id == Convert.ToInt32(uploadedimageid)).name;

            // update filename in 
            PagePartModel pagepartmodel = new PagePartModel();
            pagepartmodel.imagepath = "/content/upload/image/" + filename;
            pagepartmodel.id = Convert.ToInt32(pagepartid);


            new _1w4w.CMS.Manager.FileManager().UpdateUploadedImage(pagepartmodel);

            return RedirectToAction("index", "home");
        }

        [HttpPost]
        [Route("/file/mupploadimage")]
        public ActionResult Mupploadimage(PagePartModel model, HttpPostedFileBase file)
        {
            // UploadedImageModel
            // "uncategorized"
            if (file != null)
            {
                string filename = System.IO.Path.GetFileName(file.FileName);
                string filenamewithoutextension = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/content/upload/image"), filename);
                string bmppath = System.IO.Path.Combine(Server.MapPath("~/content/upload/image/bmp/"), filenamewithoutextension + ".bmp");
                // file is uploaded
                file.SaveAs(path);



                //Image Dummy = Image.FromFile("image.png");
                //Image Dummy = Image.FromFile(path);
                //Dummy.Save("image.bmp", ImageFormat.Bmp);
                var bmp = ColorManager.GetBitmapFromPng(path);
                var quantize = ColorManager.Quantize(bmp, 15);
                Bitmap returnedBitmap = quantize.Item1;
                List<string> returnedListOfColors = quantize.Item2;
                foreach (var item in returnedListOfColors)
                {
                    //var hex = GetHexFromColor(item);
                    var item2 = item;
                }
                returnedBitmap.Save(bmppath);

                //var item3 = returnedListOfColors;
                if (returnedListOfColors != null)
                {
                    model.colors = string.Join(",", returnedListOfColors.ToArray());
                }

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();

                    
                    var uploadedimagemodel = new Models.UploadedImageModel();
                    uploadedimagemodel.name = filename;
                    

                    // placementid
                    //PagePartModel pagepartmodel = new PagePartModel();
                    //pagepartmodel = "1";
                    model.parttype = "image";
                    model.imagepath = "/content/upload/image/" + filename;
                    //new Manager.PagePartManager().CreateImagePagePart(model);



                    // update imagefilename in db
                    //new _1w4w.CMS.Manager.FileManager().CreateUploadedImage(uploadedimagemodel);
                    new _1w4w.CMS.Manager.FileManager().UpdateUploadedImage(model);
                }

            }
            //return RedirectToAction("index", "home");
            
            return Redirect("/home/index/" + model.pageid);
        }

        [HttpPost]
        [Route("/file/muppdateimagepath")]
        public ActionResult Muppdateimagepath(PagePartModel model)
        {
            string filename = System.IO.Path.GetFileName(model.imagepath);
            string path = System.IO.Path.Combine(Server.MapPath("~/content/upload/image"), filename);


            model.parttype = "image";
            model.imagepath = "/content/upload/image/" + filename;

            new _1w4w.CMS.Manager.FileManager().UpdateUploadedImage(model);
            
            return RedirectToAction("index", "home");
        }



        [HttpPost]
        [Route("/file/imageupload")]
        public ActionResult ImageUpload(List<HttpPostedFileBase> uploadedimages)
        {
            string path = Server.MapPath("~/content/upload/image");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (HttpPostedFileBase pFile in uploadedimages)
            {
                if (pFile != null)
                {
                    // make sure we really have an image
                    if (IsFileTypeValid(pFile))
                    {
                        //string path = System.IO.Path.Combine(Server.MapPath("~/content/upload/image"), filename);
                        string fileName = Path.GetFileName(pFile.FileName);
                        string pathandfilename = Path.Combine(path, fileName);
                        pFile.SaveAs(pathandfilename);
                        //save image filename to database
                        var model = new Models.UploadedImageModel();
                        model.name = fileName;
                        new _1w4w.CMS.Manager.FileManager().CreateUploadedImage(model);
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
                    }
                }
            }
            return Redirect("/home/index");
        }

        private bool IsFileTypeValid(HttpPostedFileBase file)
        {
            bool isValid = false;

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    if (IsOneOfValidFormats(img.RawFormat))
                    {
                        isValid = true;
                    }
                }
            }
            catch
            {
                //Image is invalid
            }
            return isValid;
        }

        private bool IsOneOfValidFormats(ImageFormat rawFormat)
        {
            List<ImageFormat> formats = GetValidFormats();

            foreach (ImageFormat format in formats)
            {
                if (rawFormat.Equals(format))
                {
                    return true;
                }
            }
            return false;
        }

        private List<ImageFormat> GetValidFormats()
        {
            List<ImageFormat> formats = new List<ImageFormat>();
            formats.Add(ImageFormat.Png);
            formats.Add(ImageFormat.Jpeg);
            formats.Add(ImageFormat.Gif);
            //add types here
            return formats;
        }
    }
}