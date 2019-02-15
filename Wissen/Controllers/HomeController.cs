using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public ActionResult DenemeForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DenemeForm(Wissen.Models.DenemeForm model1)
        {
            if (ModelState.IsValid)
            {
                bool hasError = false;
                try
                {
                    
                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                    mailMessage.From = new System.Net.Mail.MailAddress("alifurkangokce@gmail.com", "ali");
                    mailMessage.Subject = "İletişim Formu: " + model1.FirstName + "" + model1.LastName;
                    mailMessage.To.Add("alifurkangokce@gmail.com alifurkangokce@gmail.com");
                    string body;
                    body = "Ad Soyad: " + model1.FirstName + "<br />";
                    body += "Telefon: " + model1.LastName + "<br />";
                    body += "E-posta: " + model1.Email + "<br />";
                    body += "Telefon: " + model1.Phone + "<br />";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;

                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new System.Net.NetworkCredential("mail", "şifre");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                    ViewBag.Message = "Mesajınız gönderildi. Teşekkür ederiz.";
                   
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    hasError = true;
                }
                if (hasError == false)
                {
                    ViewBag.Message = "Mail başarıyla gönderildi";
                    
                }
                return View();




            }
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
            Name = Name.Trim();
            LastName = LastName.Trim();
            
            if (Name == "")
            {
                ViewBag.Message = "Ad alanı gereklidir";
                ViewBag.IsError = true;
                return View();
            }
            if (Name.Length>50)
            {
                ViewBag.Message = "Ad alanı 50 karakteri geçemez";
                ViewBag.IsError = true;
                return View();
            }
            if (LastName == "")
            {
                ViewBag.Message = "SoyAd alanı gereklidir";
                ViewBag.IsError = true;
                return View();
            }
            if (LastName.Length > 50)
            {
                ViewBag.Message = "SoyAd alanı 50 karakteri geçemez";
                ViewBag.IsError = true;
                return View();
            }
            Regex regex = new Regex(@"^ 5(0[5 - 7] |[3 - 5]\d) \d{ 3 } \d{ 4}$");
            Match match = regex.Match(Phone);
            if (match.Success==false)
            {
                ViewBag.Message = "Telefon 5XX XXX XXXX biçiminde olmalıdır";
                ViewBag.IsError = true;
                return View();
            }



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