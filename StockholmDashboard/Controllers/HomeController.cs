using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockholmDashboard.Data;

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

        public JsonResult ServiceVersion(string id)
        {
            var t = new JsonResult();
            t.Data = "6.0.1";
            t.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return t;
        }

        
    }
}