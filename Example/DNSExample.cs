using OCISDK.Core.src;
using OCISDK.Core.src.Common;
using OCISDK.Core.src.DNS;
using OCISDK.Core.src.DNS.Request;
using OCISDK.Core.src.Identity;
using OCISDK.Core.src.Identity.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    public class DNSExample
    {
        public static void DNSConsoleDisplay(ClientConfig config)
        {
            var identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var dnsClient = new DNSClient(config);

            var listCompartmentRequest = new ListCompartmentRequest()
            {
                CompartmentId = config.TenancyId,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE
            };
            var compartments = identityClient.ListCompartment(listCompartmentRequest).Items;

            Console.WriteLine("* DNS Zone------------------------");
            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }

                Console.WriteLine($" Compartment<{com.Name}>--------");

                var listZonesRequest = new ListZonesRequest()
                {
                    CompartmentId = com.Id,

                };
                var zones = dnsClient.ListZones(listZonesRequest).Items;

                foreach (var zone in zones)
                {
                    Console.WriteLine($"\t|- name: {zone.Name}");
                    Console.WriteLine($"\t|  version: {zone.Version}");
                    Console.WriteLine($"\t|  state: {zone.LifecycleState}");
                    Console.WriteLine($"\t|  timeCreated: {zone.TimeCreated}");
                    Console.WriteLine($"\t|  type: {zone.ZoneType}");
                    Console.WriteLine($"\t|  self: {zone.Self}");
                    Console.WriteLine($"\t|  serial: {zone.Serial}");
                }
            }

        }
    }
}
