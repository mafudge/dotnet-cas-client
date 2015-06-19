using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CasAssertionModel;


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
                string base64String = Request.QueryString["ticket"];
                CasAuthTicket casAuthTicket = new CasAuthTicket().fromBase64(base64String);                
            }

            // TODO: Make view
            return View();
            
        }
    }
}