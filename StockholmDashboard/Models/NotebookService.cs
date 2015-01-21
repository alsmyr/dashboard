using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StockholmDashboard.Models
{
    public class NotebookService
    {
        [DisplayName("ID")]
        public string ID { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Open")]
        public Uri UI_Url { get; set; }

        [DisplayName("API")]
        public Uri API_Url { get; set; }

        [DisplayName("Log Errors")]
        public Uri ListLogURL { get; set; }

        [DisplayName("Version")]
        public string Version { get; set; }

        [DisplayName("Environment")]
        public string Environment { get; set; }

        [DisplayName("Integrations")]
        public List<string> Integrations { get; set; }

        [DisplayName("Performance")]
        public string PerformanceMetricsUrl { get; set; }

        [DisplayName("Errors")]
        public string LogErrorsUrl { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int TicketRequestID_UI { get; set; }
        public int TicketRequestID_API { get; set; }

        public List<TestSummary> UITestSummaries { get; set; }
        public List<TestSummary> APITestSummaries { get; set; }

      

    }
}