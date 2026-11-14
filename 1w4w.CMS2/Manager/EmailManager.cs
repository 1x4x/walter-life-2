using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;

namespace _1w4w.CMS.Manager
{
    public class EmailManager
    {
        public static void Send()
        {
            Console.WriteLine("Email Sent!");

            var smtp = new System.Net.Mail.MailMessage("from@walters.nu", "to@walters.nu", "subject", "body");
            // mailcluster.loopia.se

            //smtp.From.Host = "localhost";
            //smtp.From.Address = "";
            ////smtp.To = "";
            //smtp.Bcc.Add("");
            //smtp.Sender.Address = "";
            //smtp.Body = "";
            //smtp.IsBodyHtml = true;

        }
    }
}