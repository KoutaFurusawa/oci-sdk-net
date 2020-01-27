using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Request;
using OCISDK.Core.Notification;
using OCISDK.Core.Notification.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class NotificationExample
    {
        public static void ResourcesExample(ClientConfig config)
        {
            var client = new NotificationClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var listCompartmentRequest = new ListCompartmentRequest()
            {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var compartments = identityClient.ListCompartment(listCompartmentRequest).Items;

            Console.WriteLine("* Notification Topics------------------------");
            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }

                Console.WriteLine($" Compartment<{com.Name}>--------");

                var listTopicsRequest = new ListTopicsRequest()
                {
                    CompartmentId = com.Id,
                    Limit = 10
                };

                var topics = client.ListTopics(listTopicsRequest);

                foreach (var topic in topics.Items)
                {
                    Console.WriteLine($"\t|- Name:{topic.Name}");
                    Console.WriteLine($"\t|- Description:{topic.Description}");
                    Console.WriteLine($"\t|- LifecycleState:{topic.LifecycleState}");
                    Console.WriteLine($"\t|- TimeCreated:{topic.TimeCreated}");
                }
            }

            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }

                Console.WriteLine($" Compartment<{com.Name}>--------");

                var listSubscriptionsRequest = new ListSubscriptionsRequest()
                {
                    CompartmentId = com.Id,
                    Limit = 10
                };
                var subscriptions = client.ListSubscriptions(listSubscriptionsRequest);

                foreach (var subscription in subscriptions.Items)
                {
                    Console.WriteLine($"\t|- protocol:{subscription.Protocol}");
                    Console.WriteLine($"\t|- policy:{subscription.DeliverPolicy}");
                    Console.WriteLine($"\t|- LifecycleState:{subscription.LifecycleState}");
                    Console.WriteLine($"\t|- CreatedTime:{subscription.CreatedTime}");
                }
            }
        }
    }
}
