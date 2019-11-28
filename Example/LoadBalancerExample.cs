using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.LoadBalancer;
using OCISDK.Core.LoadBalancer.Request;
using OCISDK.Core.LoadBalancer.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example
{
    class LoadBalancerExample
    {
        public static void ConsoleDisplay(ClientConfig config)
        {
            var identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var lbClient = new LoadBalancerClient(config);

            var listCompartmentRequest = new ListCompartmentRequest()
            {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var compartments = identityClient.ListCompartment(listCompartmentRequest).Items;
            
            Console.WriteLine("* LB Resources------------------------");
            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }

                Console.WriteLine($" Compartment<{com.Name}>--------");
                
                var listLoadBalancersRequest = new ListLoadBalancersRequest()
                {
                    CompartmentId = com.Id,
                    SortBy = ListLoadBalancersRequest.SortByParam.DISPLAYNAME
                };
                Console.WriteLine("   LoadBalancer------");
                var loadbalancers = lbClient.ListLoadBalancers(listLoadBalancersRequest).Items;
                foreach (var lb in loadbalancers)
                {
                    var getLoadBalancerRequest = new GetLoadBalancerRequest() {
                        LoadBalancerId = lb.Id
                    };
                    var lbDetail = lbClient.GetLoadBalancer(getLoadBalancerRequest).LoadBalancer;
                    Console.WriteLine($"\t|- displayName: {lbDetail.DisplayName}");
                    Console.WriteLine($"\t|  state: {lbDetail.LifecycleState}");
                    Console.WriteLine($"\t|  shape: {lbDetail.ShapeName}");
                    Console.WriteLine($"\t|  timeCreated: {lbDetail.TimeCreated}");
                    Console.WriteLine($"\t|  ipAddresses: {lbDetail.IpAddresses}");
                    Console.WriteLine($"\t|  private: {lbDetail.IsPrivate}");
                    Console.WriteLine($"\t|  listeners:");
                    foreach (var key in lbDetail.Listeners.Keys)
                    {
                        Console.WriteLine($"\t|   |-{key} : {lbDetail.Listeners[key].DefaultBackendSetName}");
                    }
                    Console.WriteLine($"\t|  rules:");
                    foreach (var key in lbDetail.RuleSets.Keys)
                    {
                        Console.WriteLine($"\t|   |-{lbDetail.RuleSets[key].Name}");
                        foreach (var rule in lbDetail.RuleSets[key].Items)
                        {
                            Console.WriteLine($"\t|   |   |-{rule.Action}");
                        }
                    }

                    Console.WriteLine($"\t|  workRequest:");
                    var listWorkRequestsRequest = new ListWorkRequestsRequest() {
                        LoadBalancerId = lb.Id
                    };
                    var works = lbClient.ListWorkRequests(listWorkRequestsRequest).Items;
                    foreach (var work in works)
                    {
                        Console.WriteLine($"\t|   |-{work.Type}");
                        Console.WriteLine($"\t|   | {work.LifecycleState}");
                    }
                }

                Console.WriteLine("   LoadBalancerHealth------");
                var listLoadBalancerHealthsRequest = new ListLoadBalancerHealthsRequest() {
                    CompartmentId = com.Id
                };
                var lbHealths = lbClient.ListLoadBalancerHealths(listLoadBalancerHealthsRequest).Items;
                foreach (var health in lbHealths)
                {
                    var getLoadBalancerHealthRequest = new GetLoadBalancerHealthRequest() {
                        LoadBalancerId = health.LoadBalancerId
                    };
                    var healthDetail = lbClient.GetLoadBalancerHealth(getLoadBalancerHealthRequest).LoadBalancerHealth;
                    Console.WriteLine($"\t|- criticalStateBackendSetNames:");
                    foreach (var name in healthDetail.CriticalStateBackendSetNames)
                    {
                        Console.WriteLine($"\t|    |-{name}");
                    }
                    Console.WriteLine($"\t|- unknownStateBackendSetNames:");
                    foreach (var name in healthDetail.UnknownStateBackendSetNames)
                    {
                        Console.WriteLine($"\t|    |-{name}");
                    }
                    Console.WriteLine($"\t|- warningStateBackendSetNames:");
                    foreach (var name in healthDetail.WarningStateBackendSetNames)
                    {
                        Console.WriteLine($"\t|    |-{name}");
                    }
                }

                Console.WriteLine("   LoadBalancerPolicy------");
                var listLoadBalancerPoliciesRequest = new ListLoadBalancerPoliciesRequest()
                {
                    CompartmentId = com.Id
                };
                var lbPolicies = lbClient.ListLoadBalancerPolicies(listLoadBalancerPoliciesRequest).Items;
                foreach (var policy in lbPolicies)
                {
                    Console.WriteLine($"\t|- name: {policy.Name}");
                }

                Console.WriteLine("   LoadBalancerProtocol------");
                var listLoadBalancerProtocolsRequest = new ListLoadBalancerProtocolsRequest() {
                    CompartmentId = com.Id
                };
                var lbProtocols = lbClient.ListLoadBalancerProtocols(listLoadBalancerProtocolsRequest).Items;
                foreach (var protocol in lbProtocols)
                {
                    Console.WriteLine($"\t|- name: {protocol.Name}");
                }

                Console.WriteLine("   LoadBalancerShape------");
                var listLoadBalancerShapesRequest = new ListLoadBalancerShapesRequest() {
                    CompartmentId = com.Id
                };
                var lbShapes = lbClient.ListLoadBalancerShapes(listLoadBalancerShapesRequest).Items;
                foreach (var shape in lbShapes)
                {
                    Console.WriteLine($"\t|- name: {shape.Name}");
                }
            }
        }
    }
}
