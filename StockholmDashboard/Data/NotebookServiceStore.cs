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
                Description = "",
                API_Url = new Uri("https://trunk-sql-12.accelrys.net/api/v1"),
                UI_Url = new Uri("https://trunk-sql-12.accelrys.net/notebook"),
                Version = "6.0",
                Environment = ""
            };

            var n2 = new NotebookService
            {
                Name = "Trunk ORA",
                Description = "",
                API_Url = new Uri("https://trunk-ora-12.accelrys.net/api/v1"),
                UI_Url = new Uri("https://trunk-ora-12.accelrys.net/notebook"),
                Version = "6.0"
            };

            var n3 = new NotebookService
            {
                Name = "Trunk Cloud",
                Description = "",
                API_Url = new Uri("http://trunk-cloud.accelrys.net/api/v1"),
                UI_Url = new Uri("http://trunk-cloud.accelrys.net/notebook"),
                Version = "6.0"
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