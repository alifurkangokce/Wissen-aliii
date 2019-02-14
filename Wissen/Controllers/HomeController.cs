using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wissen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string Name,string LastName,string Email,string Phone,string Message,string department)
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("alifurkangokce@gmail.com","ali");
            mailMessage.Subject = "İletişim Formu: " + Name + "" + LastName;
            mailMessage.To.Add("alifurkangokce@gmail.com alifurkangokce@gmail.com");
            string body;
            body = "Ad Soyad: " + Name + "<br />";
            body += "Telefon: " + LastName+ "<br />";
            body += "E-posta: " + Email+ "<br />";
            body += "Telefon: " + Phone+ "<br />";
            body += "Mesaj: " + Message + "<br />";
            body += "Departman: " + department + "<br />";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("mail","şifre");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
            ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";



            //TODO:Mail gönderme işlemi yapılacak
            ViewBag.Message = "Form başarıyla iletildi";
            return View();
        }
    }
}