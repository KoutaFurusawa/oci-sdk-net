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

                var now = DateTime.UtcNow.AddHours(-4);
                var endTime = now.AddHours(3);
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
                                StartTime = now.ToString("yyy-MM-ddThh:MM:ddZ"),
                                EndTime = endTime.ToString("yyy-MM-ddThh:MM:ddZ")
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
        }

        private class DimensionFilter {
            public string ResourceId { get; set; }
        }
    }
}
