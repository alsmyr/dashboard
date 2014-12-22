using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using StockholmDashboard.Data;
using StockholmDashboard.Models;

namespace StockholmDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(NotebookServiceStore.GetServices());
        }

        public ActionResult Service(string id)
        {
            var service = NotebookServiceStore.GetServices().Find(m => m.ID == id);
            return View(service);
        }

        public ActionResult ServiceVersion(string id)
        {
            var retval = "(error)";
            var service = NotebookServiceStore.GetServices().Find(m => m.ID == id);

            if (service != null)
            {
                var client = new RestClient(service.API_Url);
                var request = new RestRequest("version?timestamp=long&$format=text", Method.GET);
                retval = client.ExecuteAsGet(request, "GET").Content;

            }

            return Content(retval);

        }

        public ActionResult ServiceInfo(string id)
        {
            SystemInfo s = null;
            var service = NotebookServiceStore.GetServices().Find(m => m.ID == id);

            if (service != null)
            {
                var client = new RestClient(service.API_Url);
                client.Authenticator = new HttpBasicAuthenticator(service.Username,service.Password);
                var request = new RestRequest("systeminfo", Method.GET);

                
                var response = client.ExecuteAsGet<SystemInfo>(request, "GET");
                s = response.Data;

            }

            return PartialView("ServiceInfo",s);

        }

        
    }
}