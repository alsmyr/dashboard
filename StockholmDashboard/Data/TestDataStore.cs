using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using StockholmDashboard.Models;
using WebGrease;
using System.Web.Caching;

namespace StockholmDashboard.Data
{
    public class TestDataStore
    {
        
        private static Cache Cache { get; set; }
        private static HashSet<int> SlackTickets { get; set; }
        public const string CacheKey = "_testSummaries";

        static TestDataStore()
        {
            
            

            Cache = new Cache();
            
            SlackTickets = new HashSet<int>();

        }

        public static void FillTestSummaries(ref NotebookService s)
        {
            List<TestSummary> _testSummaries = null;
            _testSummaries = HttpRuntime.Cache.Get(CacheKey) as List<TestSummary>;
            int id = s.TicketRequestID_API;
            int id2 = s.TicketRequestID_UI;

            if (_testSummaries == null)
            {
                _testSummaries = new List<TestSummary>();

                SqlConnection _conn = null;
                using (
                    _conn =
                        new SqlConnection(
                            "Data Source=auto-test-data;Initial Catalog=TestAutomation;Persist Security Info=True;User ID=sa;Password=Kr0ken!;Pooling=True")
                    )
                {
                    
                
                        _conn.Open();
                        var command = _conn.CreateCommand();
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select t.ticketid, startdate, tests, passed,t.ticketrequestid,ignored,tsv.version from [TestAutomation].[dbo].[TicketStatusView] tsv, [TestAutomation].[dbo].[Ticket] t where tsv.Tests = tsv.Finished and t.ticketid = tsv.ticketid and t.TicketRequestID in (1089,1090,1091,1093,1094,1095,1472,1473,1474,1475,1476,1477,2214,2215  ) order by ticketid desc";
                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            var t = new TestSummary {Executed = reader.GetDateTime(1), Passed = reader.GetInt32(3)};

                            t.TicketID = (int) reader.GetFieldValue<long>(0);
                            t.NotPassed = reader.GetInt32(2) - t.Passed - reader.GetInt32(5);
                            t.TicketRequestID = (int)reader.GetFieldValue<long>(4);
                            t.DetailsUri = string.Format("http://auto-test-data/report/Report.aspx?TicketIDs={0}&Details=true&SortExpr=Failcount desc", t.TicketID);
                            t.Build = !reader.IsDBNull(6) ? reader.GetString(6) : "(unknown)";
                            _testSummaries.Add(t);

                        }

                        reader.Close();
                        _conn.Close();

                }
               
                HttpRuntime.Cache.Add(CacheKey, _testSummaries, null, DateTime.Now.AddHours(4), Cache.NoSlidingExpiration,
                    CacheItemPriority.Default, null);

                
            }

            s.APITestSummaries = _testSummaries.FindAll(m => m.TicketRequestID == id);
            s.UITestSummaries = _testSummaries.FindAll(m => m.TicketRequestID == id2);

        }
    }
}