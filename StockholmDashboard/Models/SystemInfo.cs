using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StockholmDashboard.Models
{
    public class SystemInfo
    {
        [DisplayName("Database")]
        public string DBVersion { get; set; }

        [DisplayName("Cartridge")]
        public string DBCartridge { get; set; }

        [DisplayName("Foundation URL")]
        public string AEPEndpoint { get; set; }

        [DisplayName("Application Server")]
        public Uri OSVersion { get; set; }

        [DisplayName("Uptime")]
        public Uri Uptime { get; set; }

        [DisplayName("Connected Clients")]
        public Uri ConnectedClients { get; set; }

    }
}