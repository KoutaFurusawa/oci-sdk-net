using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Audit;
using OCISDK.Core.src.Audit.Request;
using System;
using System.Linq;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.Identity.Request;
using OCISDK.Core.src.Audit.Response;
using System.Net;

namespace Example
{
    class AuditExample
    {
        public static void AuditDisplay(ClientConfig config)
        {
            // create client
            AuditClient client = new AuditClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };
            IdentityClient identityClinet = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            DateTime now = DateTime.Now;
            var startDate = now.ToString("yyyy-MM-ddT00:00:00Z");
            var endDate = now.ToString("yyyy-MM-ddT01:30:00Z");

            // get config
            GetConfigurationRequest configurationRequest = new GetConfigurationRequest() {
                CompartmentId = config.TenancyId
            };
            var auditConfig = client.GetConfiguration(configurationRequest);
            
            Console.WriteLine($"startTime:{startDate}, endTime:{endDate}");
            Console.WriteLine($"retentionPeriodDays:{auditConfig.Configuration.RetentionPeriodDays}");

            // get Audit Events
            Console.WriteLine("* Audit Events-------------------");
            DisplayAudit(config, client, identityClinet, startDate, endDate, "");
        }

        private static void DisplayAudit(ClientConfig config, AuditClient client, IdentityClient identityClinet, string startDate, string endDate, string pageId)
        {
            // get Audit Events
            var listEventsRequest = new ListEventsRequest()
            {
                CompartmentId = config.TenancyId,
                StartTime = startDate,
                EndTime = endDate,
                Page = pageId
            };
            var events = client.ListEvents(listEventsRequest);
            if (events.Items.Count > 0)
            {
                events.Items.ForEach(e => {
                    Console.WriteLine($"* eventName:{e.Data.EventName}");
                    Console.WriteLine($"\t id:{e.EventId}");
                    Console.WriteLine($"\t type:{e.EventType}");
                    Console.WriteLine($"\t source:{e.Source}");
                    Console.WriteLine($"\t time:{e.EventTime}");
                    Console.WriteLine($"\t resourceName:{e.Data.ResourceName}");
                    if (e.Data.Identity != null)
                    {
                        Console.WriteLine($"\t principal:{e.Data.Identity.PrincipalId}");

                        try
                        {
                            var getUserRequest = new GetUserRequest()
                            {
                                UserId = e.Data.Identity.PrincipalId
                            };
                            var user = identityClinet.GetUser(getUserRequest);
                            Console.WriteLine($"\t user:{user.User.Name}");
                        }
                        catch (WebException we)
                        {
                            if (we.Status.Equals(WebExceptionStatus.ProtocolError))
                            {
                                var code = ((HttpWebResponse)we.Response).StatusCode;
                                if (code == HttpStatusCode.NotFound)
                                {
                                    // エラーだけ残す
                                    Console.WriteLine($"\t user not found");
                                    return;
                                }
                            }
                        }
                    }
                });
            }

            if (!string.IsNullOrEmpty(events.OpcNextPage)) {
                DisplayAudit(config, client, identityClinet, startDate, endDate, events.OpcNextPage);
            }
        }
    }
}
