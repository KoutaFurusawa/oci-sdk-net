using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.Identity.Request;
using OCISDK.Core.src.LoadBalancer;
using OCISDK.Core.src.LoadBalancer.Request;
using OCISDK.Core.src.LoadBalancer.Response;
using System;
using System.Collections.Generic;
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
            
            Console.WriteLine("* LB------------------------");
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
                }
            }
        }
    }
}
