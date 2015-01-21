using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Caching;
using StockholmDashboard.Models;
using WebGrease;
using System.Web.Caching;

namespace StockholmDashboard.Data
{
    public class TestDataStore
    {
        private static SqlConnection _conn { get; set; }
        private static Cache Cache { get; set; }

        static TestDataStore()
        {
            
            _conn = new SqlConnection("Data Source=auto-test-data;Initial Catalog=TestAutomation;Persist Security Info=True;User ID=sa;Password=Kr0ken!;Pooling=False");
            _conn.Open();

            Cache = new Cache();
            

        }

        public static void FillTestSummaries(ref NotebookService s)
        {
            List<TestSummary> _testSummaries = null;
            _testSummaries = HttpRuntime.Cache.Get("_testSummaries") as List<TestSummary>;
            int id = s.TicketRequestID_API;
            int id2 = s.TicketRequestID_UI;

            if (_testSummaries == null)
            {
                _testSummaries = new List<TestSummary>();

                var command = _conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select t.ticketid, startdate, tests, passed,t.ticketrequestid from [TestAutomation].[dbo].[TicketStatusView] tsv, [TestAutomation].[dbo].[Ticket] t where t.ticketid = tsv.ticketid and t.TicketRequestID in (1089,1090,1091,1092,1093,1094,1095) order by ticketid desc";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var t = new TestSummary {Executed = reader.GetDateTime(1), Passed = reader.GetInt32(3)};

                    t.NotPassed = reader.GetInt32(2) - t.Passed;
                    t.TicketRequestID = (int)reader.GetFieldValue<long>(4);

                    _testSummaries.Add(t);

                }

                HttpRuntime.Cache.Add("_testSummaries", _testSummaries, null, DateTime.Now.AddHours(4), Cache.NoSlidingExpiration,
                    CacheItemPriority.Default, null);
            }

            s.TestSummaries = _testSummaries.FindAll(m => m.TicketRequestID == id);
            s.TestSummaries.AddRange(_testSummaries.FindAll(m => m.TicketRequestID == id2));

        }
    }
}