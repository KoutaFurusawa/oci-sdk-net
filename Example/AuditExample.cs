using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Audit;
using OCISDK.Core.Audit.Request;
using System;
using System.Linq;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.Audit.Response;
using System.Net;
using System.Threading;
using Polly.CircuitBreaker;

namespace Example
{
    class AuditExample
    {
        public static async void AuditDisplay(ClientConfig config)
        {
            // create client
            AuditClientAsync client = new AuditClientAsync(config)
            {
                Region = Regions.US_ASHBURN_1
            };
            IdentityClient identityClinet = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };
            
            DateTime now = DateTime.Now.AddDays(-1);
            var startDate = now.ToString("yyyy-MM-ddT00:00:00Z");
            var endDate = now.ToString("yyyy-MM-ddT10:30:00Z");

            var listCompartmentRequest = new ListCompartmentRequest()
            {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var compartments = identityClinet.ListCompartment(listCompartmentRequest).Items;

            // get Audit Events
            Console.WriteLine("* Audit Events-------------------");
            foreach (var compartment in compartments)
            {
                // get config
                var configurationRequest = new GetConfigurationRequest()
                {
                    CompartmentId = compartment.Id
                };
                var auditConfig = await client.GetConfiguration(configurationRequest);

                Console.WriteLine($"compartment<{compartment.Name}>---");
                Console.WriteLine($"startTime:{startDate}, endTime:{endDate}");
                Console.WriteLine($"retentionPeriodDays:{auditConfig.Configuration.RetentionPeriodDays}");

                DisplayAudit(config, client, identityClinet, compartment.Id, startDate, endDate, "", "");
                
            }
        }

        private static async void DisplayAudit(ClientConfig config, AuditClientAsync client, IdentityClient identityClinet, string compartmentId, string startDate, string endDate, string requestId, string pageId)
        {
            // get Audit Events
            var listEventsRequest = new ListEventsRequest()
            {
                CompartmentId = compartmentId,
                StartTime = startDate,
                EndTime = endDate,
                //Page = pageId
                //CompartmentId = "ocid1.compartment.oc1..aaaaaaaarj2edeedyk4o7rvcpdh6fckmeevwyog3k7zd4wjlyzcejib53yuq",
                //StartTime = "2019-10-29T09:33:57Z",
                //EndTime = "2019-10-29T11:33:57Z",
                OpcRequestId = requestId,
                Page = pageId
            };
        
            var events = await client.ListEvents(listEventsRequest);

            if (!string.IsNullOrEmpty(events.OpcNextPage))
            {
                DisplayAudit(config, client, identityClinet, compartmentId, startDate, endDate, events.OpcRequestId, events.OpcNextPage);
            }
            
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
        }
    }
}
