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
using System.Collections.Generic;
using System.Threading.Tasks;
using OCISDK.Core.Identity.Model;

namespace Example
{
    class AuditExample
    {
        private static List<Task> Tasks = new List<Task>();

        public static void AuditDisplay(ClientConfig config)
        {
            ThreadSafeSigner threadSafeSigner = new ThreadSafeSigner(new OciSigner(config));
            // create client
            IdentityClient identityClinet = new IdentityClient(config, threadSafeSigner)
            {
                Region = Regions.US_ASHBURN_1
            };

            var executeStart = DateTime.Now;

            var listRegionSubscriptionsRequest = new ListRegionSubscriptionsRequest()
            {
                TenancyId = config.TenancyId
            };
            var regions = identityClinet.ListRegionSubscriptions(listRegionSubscriptionsRequest).Items.Where(r => r.Status.Equals("READY"));

            // get compartment
            var listCompartmentRequest = new ListCompartmentRequest()
            {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var compartments = identityClinet.ListCompartment(listCompartmentRequest).Items;

            // get Audit Events
            Console.WriteLine("* Audit Events-------------------");

            var acquisitionMaxRange = 12;

            // 長時間化を見込んで時間を分割しながら取得する
            var endDate = new DateTime(2020, 3, 11);
            var startDate = new DateTime(2020, 3, 9);
            var client = new AuditClientAsync(config, threadSafeSigner);
            var option = client.GetRestOption();
            option.TimeoutSeconds = 200;
            client.SetRestOption(option);

            foreach (var region in regions)
            {
                client.SetRegion(region.RegionName);

                while (startDate < endDate)
                {
                    var valiableDay = startDate.AddDays(1);

                    var start = startDate;
                    bool finished = false;
                    while (!finished)
                    {
                        var progressEndDate = start.AddHours(acquisitionMaxRange);
                        if (progressEndDate > valiableDay)
                        {
                            progressEndDate = valiableDay;
                            finished = true;
                        }

                        if (start == progressEndDate)
                        {
                            continue;
                        }

                        foreach (var compartment in compartments)
                        {
                            if (!compartment.LifecycleState.Equals("ACTIVE", StringComparison.OrdinalIgnoreCase))
                                continue;
                            Console.WriteLine($"region:{region.RegionName}, compartment:{compartment.Name}");
                            AddTasks(DisplayAudit(client, identityClinet, compartment, start.ToString("yyyy-MM-ddTHH:mm:ssZ"), progressEndDate.ToString("yyyy-MM-ddTHH:mm:ssZ")));
                        }
                        start = progressEndDate;
                    }

                    ExecuteTasks();

                    startDate = valiableDay;
                }
            }
            ExecuteTasks();
            
            Console.WriteLine($"Count:{Count}");

            var executeEnd = DateTime.Now;

            var saDate = executeEnd - executeStart;

            Console.WriteLine($"{saDate.Hours}:{saDate.Minutes}:{saDate.Seconds}");

            Console.WriteLine("******************************************");
            Console.WriteLine("******** All Audit Task Completed ********");
            Console.WriteLine("******************************************");
        }

        private static void ExecuteTasks()
        {
            try
            {
                //t.Wait();
                Task.WaitAll(Tasks.ToArray());
            }
            catch (WebException we)
            {
                if (!(we.Status.Equals(WebExceptionStatus.ProtocolError) && ((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.NotFound))
                {
                    Console.WriteLine(we.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Tasks.Clear();
            }
        }

        static int Count = 0;
        private static async Task DisplayAudit(
            AuditClientAsync client, IdentityClient identityClinet, 
            Compartment compartment, string startDate, string endDate, 
            string requestId="", string pageId="")
        {
            // get Audit Events
            var listEventsRequest = new ListEventsRequest()
            {
                CompartmentId = compartment.Id,
                StartTime = startDate,
                EndTime = endDate,
                Page = pageId
            };

            var events = await client.ListEvents(listEventsRequest);

            if (!string.IsNullOrEmpty(events.OpcNextPage))
            {
                await DisplayAudit(client, identityClinet, compartment, startDate, endDate, events.OpcRequestId, events.OpcNextPage);
            }

            if (events.Items.Count > 0)
            {
                Count += events.Items.Count;
                Console.WriteLine($"enventset: com={compartment.Name}, start={startDate}, end={endDate}, events.Items:{events.Items.Count}");
            }
        }

        private static void AddTasks(Task task)
        {
            Tasks.Add(task);

            Console.WriteLine("Task count:" + Tasks.Count);

            if (Tasks.Count > 50)
            {
                ExecuteTasks();
            }
        }
    }
}
