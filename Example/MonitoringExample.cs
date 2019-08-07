using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Core;
using OCISDK.Core.src.Core.Request.Compute;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.Identity.Request;
using OCISDK.Core.src.Monitoring;
using OCISDK.Core.src.Monitoring.Model;
using OCISDK.Core.src.Monitoring.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    public class MonitoringExample
    {
        public static void MonitoringResourceExample(ClientConfig config)
        {
            // create client
            var identityClient = new IdentityClient(config);

            var computeClient = new ComputeClient(config);

            var monitoringClient = new MonitoringClient(config);

            var listCompartmenRequest = new ListCompartmentRequest()
            {
                CompartmentId = identityClient.Config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE,
                Limit = 10
            };
            // get compartment
            var listCompartment = identityClient.ListCompartment(listCompartmenRequest).Items;

            Console.WriteLine("* List Instance Metrics------------------------");
            foreach (var compartment in listCompartment)
            {
                var listInstanceRequest = new ListInstancesRequest()
                {
                    CompartmentId = compartment.Id,
                    Limit = 50,
                    LifecycleState = ListInstancesRequest.LifecycleStates.RUNNING,
                    SortOrder = SortOrder.ASC
                };

                var now = DateTime.UtcNow.AddHours(-2);
                var endTime = DateTime.UtcNow;
                // get instance
                var listInstance = computeClient.ListInstances(listInstanceRequest).Items;
                foreach (var instance in listInstance)
                {
                    Console.WriteLine($" |-{instance.DisplayName}------------");

                    // get all computeagent
                    var listMetricsRequest = new ListMetricsRequest()
                    {
                        CompartmentId = compartment.Id,
                        CompartmentIdInSubtree = false,
                        ListMetricsDetails = new ListMetricsDetails()
                        {
                            Namespace = "oci_computeagent",
                            DimensionFilters = new DimensionFilter()
                            {
                                ResourceId = instance.Id
                            }
                        }
                    };
                    // get Metrics
                    var listMetrics = monitoringClient.ListMetrics(listMetricsRequest).Items;
                    foreach (var metrics in listMetrics)
                    {
                        Console.WriteLine($"\t| Mertics: {metrics.Name}");
                        Console.WriteLine($"\t| NameSpace: {metrics.Namespace}");
                        // metric dimensions
                        //Console.WriteLine($"\t| {metrics.Dimensions}".Replace("\n", ""));

                        var summarizeMetricsDataRequest = new SummarizeMetricsDataRequest()
                        {
                            CompartmentId = compartment.Id,
                            CompartmentIdInSubtree = false,
                            SummarizeMetricsDataDetails = new SummarizeMetricsDataDetails()
                            {
                                Namespace = "oci_computeagent",
                                Query = metrics.Name + "[1h]{resourceId = \"" + instance.Id + "\"}.mean()",
                                StartTime = now.ToString("yyyy-MM-ddThh:MM:ssZ"),
                                EndTime = endTime.ToString("yyyy-MM-ddThh:MM:ssZ")
                            }
                        };

                        var SummarizeMetricsDatas = monitoringClient.SummarizeMetricsData(summarizeMetricsDataRequest).Items;
                        foreach (var summaryData in SummarizeMetricsDatas)
                        {
                            foreach (var aggregatedDatapoint in summaryData.AggregatedDatapoints)
                            {
                                Console.WriteLine("\t| {");
                                Console.WriteLine($"\t| \tTimeStamp: {aggregatedDatapoint.Timestamp}");
                                Console.WriteLine($"\t| \tValue: {aggregatedDatapoint.Value}");
                                Console.WriteLine("\t| }");
                            }
                        }
                    }
                }
            }
            Console.WriteLine("* List compartment Alarms------------------------");
            foreach (var compartment in listCompartment)
            {
                var listAlarmsRequest = new ListAlarmsRequest() {
                    CompartmentId = compartment.Id,
                    Limit = 10
                };

                var listAlarms = monitoringClient.ListAlarms(listAlarmsRequest);
                if (listAlarms.Items.Count > 0)
                {
                    Console.WriteLine($" |-{compartment.Name}------------");

                    foreach (var alarm in listAlarms.Items)
                    {
                        Console.WriteLine($"\tname:{alarm.DisplayName}");
                        Console.WriteLine($"\tdestinations:{alarm.Destinations}");
                        Console.WriteLine($"\tenable:{alarm.IsEnabled}");
                        Console.WriteLine($"\tstate:{alarm.LifecycleState}");
                    }
                }

                // Transactions Per Second (TPS) per-tenancy limit for this operation: 1.
                System.Threading.Thread.Sleep(1000); ;
            }
        }

        private class DimensionFilter {
            public string ResourceId { get; set; }
        }
    }
}
