using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StockholmDashboard.Models
{
    public class NotebookService
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Open")]
        public Uri UI_Url { get; set; }

        [DisplayName("API")]
        public Uri API_Url { get; set; }

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
    }
}