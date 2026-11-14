using _1w4w.CMS.Views.Shared.Energy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace _1w4w.CMS.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            

            return View();
        }

        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(OrderCreateViewModel model)
        {
            if (!string.IsNullOrEmpty(model.ordercontainer2cleandata))
            {

                // Step 1. create order
                var fullname = model.fullname ?? "";
                var address = model.address ?? "";
                var zipcode = model.zipcode ?? "";
                var city = model.city ?? "";
                var orgnr = model.orgnr ?? "";
                var phone = model.phone ?? "";
                var email = model.email ?? "";

                Models.CateringOrderModel order = new Models.CateringOrderModel();
                order.fullname = fullname;
                order.address = address;
                order.zipcode = zipcode;
                order.city = city;
                order.orgnr = orgnr;
                order.phone = phone;
                order.email = email;
                var orderid = Manager.CateringOrderManager.Create(order);
                //var orderid = Manager.OrderManager.Create(name, address, zipcode, orgnr, phone, email);
                // 		Message	"You have an error in your SQL syntax; check the manual that corresponds to your MySQL server version for the right syntax to use near 'order (name, address, zipcode, city, orgnr, phone, email) VALUES ('Walter Schöt' at line 1"	string




                // Step 2. create orderrows
                var ordercontainer2cleandata = model.ordercontainer2cleandata;
                var arr = ordercontainer2cleandata.Split('¤');
                foreach (var item in arr)
                {
                    if (item != "")
                    {
                        //var item2 = item;
                        var arr2 = item.Split('_');
                        //var arr2 = ordercontainer2cleandata.Split('_');
                        var productid = arr2[0].Replace("¤","");
                        var productamount = arr2[1].Replace("¤", "");
                        var productartnr = arr2[2].Replace("¤", "");
                        var productname = arr2[3].Replace("¤", "");

                        //var orderrowid = Manager.OrderManager.CreateOrderRow(Convert.ToInt32(id2), Convert.ToInt32(orderid), Convert.ToInt32(amount2), artnr2, name2);
                        var orderrowid = Manager.CateringOrderManager.CreateOrderRow(Convert.ToInt32(orderid), Convert.ToInt32(productid), Convert.ToInt32(productamount), productartnr, productname);

                        //Manager.OrderManager.Create(
                        //    Convert.ToInt32(id2), 
                        //    Convert.ToInt32(amount2),
                        //    artnr2,
                        //    name2);

                        //Manager.OrderManager.CreateOrderRow(id2,orderid,amount2,artnr2,name2);
                    }

                    // Step 3. send email with the order
                    
                    //MailMessage mail = new MailMessage();
                    //mail.From = new MailAddress("order@energikällan.net");
                    //mail.To.Add("robert@walters.nu");
                    ////mail.To.Add("order@energikällan.net");
                    //mail.Subject = "Test av e-post";
                    //mail.Body = "<em style='color: #f11;'>Detta är ett HTML-meddelande.</em>";
                    //mail.IsBodyHtml = true;
                    //SmtpClient smtp = new SmtpClient("mailcluster.loopia.se");
                    //smtp.Credentials = new NetworkCredential("order@energikällan.net", "Nisse!Luring3453");
                    //try
                    //{
                    //    smtp.Send(mail);
                    //}
                    //catch (Exception ex)
                    //{
                    //    Response.Write("Caught exception: " + ex.ToString());
                    //}
                }
            }
            //RedirectToRoute("/home/index");
            return Redirect("/home/index");
            //Redirect("/home/index");
            //return View();
        }
    }
}