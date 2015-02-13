using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StockholmDashboard.Models
{
    public class TestSummary
    {
        [DisplayName("Executed")]
        public DateTime Executed { get; set; }

        [DisplayName("Passed")]
        public int Passed { get; set; }

        [DisplayName("Not Passed")]
        public int NotPassed { get; set; }

        [DisplayName("Details")]
        public string DetailsUri { get; set; }

        
        public int TicketRequestID { get; set; }
    }
}