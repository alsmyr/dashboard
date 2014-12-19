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

        
    }
}