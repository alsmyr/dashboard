using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using StockholmDashboard.Models;

namespace StockholmDashboard.Data
{
    public class NotebookServiceStore
    {
        private static List<NotebookService> _services { get; set; } 
        static NotebookServiceStore()
        {
            _services = new List<NotebookService>();

            var n1 = new NotebookService
            {
                Name = "Trunk SQL",
                Description = "On-Prem with MS SQL Server (> 1M experiments)",
                API_Url = "https://trunk-sql-12.accelrys.net/api/v1",
                UI_Url = "https://trunk-sql-12.accelrys.net/notebook"
            };

            var n2 = new NotebookService
            {
                Name = "Trunk ORA",
                Description = "On-Prem with Oracle (> 1M experiments)",
                API_Url = "https://trunk-ora-12.accelrys.net/api/v1",
                UI_Url = "https://trunk-ora-12.accelrys.net/notebook"
            };

            var n3 = new NotebookService
            {
                Name = "Trunk Cloud",
                Description = "Cloud like environment",
                API_Url = "http://trunk-cloud.accelrys.net/api/v1",
                UI_Url = "http://trunk-cloud.accelrys.net/notebook"
            };

            _services.Add(n1);
            _services.Add(n2);
            _services.Add(n3);

        }

        public static List<NotebookService> GetServices()
        {
            return _services;
        }
    }
}