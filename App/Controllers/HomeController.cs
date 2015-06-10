using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetCasClient;
using System.Web.Security;

namespace App.Controllers
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

        public ActionResult CasAuth()
        {
            if (!Request.IsAuthenticated) return RedirectToRoute("Home");

            HttpCookie ticketCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (ticketCookie != null && !String.IsNullOrEmpty(ticketCookie.Value))
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(ticketCookie.Value);
            }
            return View();
            
        }
    }
}