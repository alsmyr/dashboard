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
                ID = "trunksql",
                Name = "Trunk SQL",
                Description = "",
                API_Url = new Uri("https://trunk-sql-12.accelrys.net/api/v1"),
                UI_Url = new Uri("https://trunk-sql-12.accelrys.net/notebook"),
                Username = "superuser",
                Password = "superuser"
            };

            var n2 = new NotebookService
            {
                ID = "trunkora",
                Name = "Trunk ORA",
                Description = "",
                API_Url = new Uri("https://trunk-ora-12.accelrys.net/api/v1"),
                UI_Url = new Uri("https://trunk-ora-12.accelrys.net/notebook"),
                Username = "superuser",
                Password = "superuser"
            };

            var n3 = new NotebookService
            {
                ID = "trunkcloud",
                Name = "Trunk Cloud",
                Description = "",
                API_Url = new Uri("http://trunk-cloud.accelrys.net/api/v1"),
                UI_Url = new Uri("http://trunk-cloud.accelrys.net/notebook"),
                Username = "superuser",
                Password = "superuser"
            };

            var n4 = new NotebookService
            {
                ID = "regsql",
                Name = "Reg SQL",
                Description = "",
                API_Url = new Uri("http://reg-sql.ilabber.com/api/v1"),
                UI_Url = new Uri("http://reg-sql.ilabber.com/notebook"),
                Username = "superuser",
                Password = "superuser"
            };

            var n5 = new NotebookService
            {
                ID = "regora",
                Name = "Reg ORA",
                Description = "",
                API_Url = new Uri("http://reg-ora-ilabber.accelrys.net/api/v1"),
                UI_Url = new Uri("http://reg-ora-ilabber.accelrys.net/notebook"),
                Username = "superuser",
                Password = "superuser"
            };

            var n6 = new NotebookService
            {
                ID = "regcloud",
                Name = "Reg Cloud",
                Description = "",
                API_Url = new Uri("https://eln.reg-cloud-prod.ilabber.com/api/v1"),
                UI_Url = new Uri("https://eln.reg-cloud-prod.ilabber.com/notebook"),
                Username = "superuser",
                Password = "superuser"
            };

            _services.Add(n1);
            _services.Add(n2);
            _services.Add(n3);
            _services.Add(n4);
            _services.Add(n5);
            _services.Add(n6);

        }

        public static List<NotebookService> GetServices()
        {
            return _services;
        }
    }
}