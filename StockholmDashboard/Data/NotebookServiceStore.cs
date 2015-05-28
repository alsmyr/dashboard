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
                Name = "Notebook Trunk SQL",
                Description = "",
                API_Url = new Uri("https://trunk-sql-12.accelrys.net/api/v1"),
                ListLogURL = new Uri("https://trunk-sql-12.accelrys.net/CheckErrorWeb.pl"),
                UI_Url = new Uri("https://trunk-sql-12.accelrys.net/notebook"),
                Username = "superuser",
                Password = "superuser",
                TicketRequestID_UI = 1090,
                TicketRequestID_API = 1094

            };

            

            var n2 = new NotebookService
            {
                ID = "trunkora",
                Name = "Notebook Trunk ORA",
                Description = "",
                API_Url = new Uri("https://trunk-ora-12.accelrys.net/api/v1"),
                UI_Url = new Uri("https://trunk-ora-12.accelrys.net/notebook"),
                ListLogURL = new Uri("https://trunk-ora-12.accelrys.net/CheckErrorWeb.pl"),
                Username = "superuser",
                Password = "superuser",
                TicketRequestID_UI = 1089,
                TicketRequestID_API = 1093
            };

            var n3 = new NotebookService
            {
                ID = "trunkcloud",
                Name = "Notebook Trunk Cloud",
                Description = "",
                API_Url = new Uri("https://trunk-cloud-1.accelrys.net/api/v1"),
                ListLogURL = new Uri("https://trunk-cloud-1.accelrys.net/CheckErrorWeb.pl"),
                UI_Url = new Uri("https://trunk-cloud-1.accelrys.net/notebook"),
                Username = "superuser",
                Password = "superuser",
                TicketRequestID_UI = 1091,
                TicketRequestID_API = 1095
            };

            var n4 = new NotebookService
            {
                ID = "regsql",
                Name = "Notebook Reg SQL",
                Description = "",
                API_Url = new Uri("http://reg-sql.ilabber.com/api/v1"),
                UI_Url = new Uri("http://reg-sql.ilabber.com/notebook"),
                Username = "superuser",
                Password = "superuser",
                TicketRequestID_UI = 1476,
                TicketRequestID_API = 1473
            };

            var n5 = new NotebookService
            {
                ID = "regora",
                Name = "Notebook Reg ORA",
                Description = "",
                API_Url = new Uri("http://reg-ora-ilabber.accelrys.net/api/v1"),
                UI_Url = new Uri("http://reg-ora-ilabber.accelrys.net/notebook"),
                Username = "superuser",
                Password = "superuser",
                TicketRequestID_UI = 1475,
                TicketRequestID_API = 1472
            };

            var n6 = new NotebookService
            {
                ID = "regcloud",
                Name = "Notebook Reg Cloud",
                Description = "",
                API_Url = new Uri("https://reg-cloud-1.accelrys.net/api/v1"),
                UI_Url = new Uri("https://reg-cloud-1.accelrys.net"),
                Username = "superuser",
                Password = "superuser",
                TicketRequestID_UI = 1477,
                TicketRequestID_API = 1474
            };

            var n7 = new NotebookService
            {
                ID = "perfectlab_dev",
                Name = "Perfect Lab (Integration Dev)",
                Description = "",
                API_Url = new Uri("https://nb.perfectlab-dev.accelrys.net/api/v1"),
                UI_Url = new Uri("https://nb.perfectlab-dev.accelrys.net"),
                Username = "superuser",
                Password = "superuser",
                TicketRequestID_UI = 1477,
                TicketRequestID_API = 1474
            };

            TestDataStore.FillTestSummaries(ref n1);
            _services.Add(n1);

            TestDataStore.FillTestSummaries(ref n2);
            _services.Add(n2);

            TestDataStore.FillTestSummaries(ref n3);
            _services.Add(n3);

            TestDataStore.FillTestSummaries(ref n4);
            _services.Add(n4);

            TestDataStore.FillTestSummaries(ref n5);
            _services.Add(n5);

            TestDataStore.FillTestSummaries(ref n6);
            _services.Add(n6);

            n7.APITestSummaries = new List<TestSummary>();
            n7.UITestSummaries = new List<TestSummary>();
            _services.Add(n7);

        }

        public static void Refresh(string id)
        {
            HttpRuntime.Cache.Remove(TestDataStore.CacheKey);

            var service = _services.First(s => s.ID == id);
            TestDataStore.FillTestSummaries(ref service);
        }

        public static List<NotebookService> GetServices()
        {
            return _services;
        }
    }
}