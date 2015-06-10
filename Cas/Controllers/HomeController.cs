using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CasAssertionModel;
using System.Web.Security;
using DotNetCasClient;
using Newtonsoft.Json;

namespace Cas
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var authTicket = new CasAuthTicket();
            authTicket.Identity = User.Identity.Name;
            HttpCookie ticketCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (ticketCookie != null && ! String.IsNullOrEmpty(ticketCookie.Value) )
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(ticketCookie.Value);
                if (ticket != null && CasAuthentication.ServiceTicketManager != null)
                {
                    CasAuthenticationTicket casTicket = CasAuthentication.ServiceTicketManager.GetTicket(ticket.UserData);
                    if (casTicket != null)
                    {
                        authTicket.ServiceTicket = casTicket.ServiceTicket;
                        authTicket.ValidFromDate = casTicket.ValidFromDate;
                        authTicket.ValidUntilDate = casTicket.ValidUntilDate;
                        authTicket.OriginatingService = casTicket.OriginatingServiceName;
                        foreach (var item in casTicket.Assertion.Attributes)
                        {
                            //var values = new List<String>();
                            //foreach( var value in item.Value) 
                            //{
                            //    values.Add(value);
                            //}
                            authTicket.Attributes.Add(item.Key, item.Value);
                        }
                    }
                }
            }
            

            return View(authTicket);
        }
    }
}