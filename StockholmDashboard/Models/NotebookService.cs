using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockholmDashboard.Models
{
    public class NotebookService
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UI_Url { get; set; }
        public string API_Url { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
        public List<string> Integrations { get; set; }
        public string PerformanceMetricsUrl { get; set; }
        public string LogErrorsUrl { get; set; }
    }
}