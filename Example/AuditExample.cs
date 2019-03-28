using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Audit;
using OCISDK.Core.src.Audit.Request;
using System;

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

            DateTime now = DateTime.Now;
            var startDate = now.ToString("yyyy-MM-ddT01:00:00Z");
            var endDate = now.ToString("yyyy-MM-ddT01:30:00Z");

            // get config
            GetConfigurationRequest configurationRequest = new GetConfigurationRequest() {
                CompartmentId = config.TenancyId
            };
            var auditConfig = client.GetConfiguration(configurationRequest);
            
            Console.WriteLine($"startTime:{startDate}, endTime:{endDate}");
            Console.WriteLine($"retentionPeriodDays:{auditConfig.Configuration.RetentionPeriodDays}");

            // get Audit Events
            ListEventsRequest listEventsRequest = new ListEventsRequest()
            {
                CompartmentId = config.TenancyId,
                StartTime = startDate,
                EndTime = endDate
            };
            var events = client.ListEvents(listEventsRequest);
            if (events.Items.Count > 0)
            {
                Console.WriteLine("* Audit Events-------------------");

                events.Items.ForEach(e => {
                    Console.WriteLine($"* eventName:{e.EventName}");
                    Console.WriteLine($"\t id:{e.EventId}");
                    Console.WriteLine($"\t type:{e.EventType}");
                    Console.WriteLine($"\t source:{e.EventSource}");
                    Console.WriteLine($"\t time:{e.EventTime}");
                    Console.WriteLine($"\t user:{e.UserName}");
                    Console.WriteLine($"\t principal:{e.PrincipalId}");
                });

            }
        }
    }
}
