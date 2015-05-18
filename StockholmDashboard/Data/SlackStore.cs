using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;


namespace StockholmDashboard.Data
{
    public class SlackStore
    {
        private static readonly Uri Uri = null;
        private readonly static Encoding _encoding = new UTF8Encoding();

        static SlackStore()
        {
            var conf = ConfigurationManager.AppSettings["SlackUrl"];

            if (conf != null)
            {
                Uri = new Uri(conf);
            }
        }

        public static void PostMessage(string text, string username = null, string channel = null,string icon_emoji = null)
        {
            if (Uri != null)
            {
                Payload payload = new Payload()
                {
                    Channel = channel,
                    Username = username,
                    Text = text,
                    IconEmoji = icon_emoji
                };

                PostMessage(payload);
            }
            
        }

        public static void PostMessage(Payload payload)
        {
            string payloadJson = JsonConvert.SerializeObject(payload);

            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;

                var response = client.UploadValues(Uri, "POST", data);

                //The response text is usually "ok"
                string responseText = _encoding.GetString(response);
            }
        }
    }

    public class Payload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }

        
    }
}