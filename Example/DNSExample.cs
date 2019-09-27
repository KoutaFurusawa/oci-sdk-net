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
                    var getZoneRequest = new GetZoneRequest()
                    {
                        CompartmentId = com.Id,
                        ZoneNameOrId = zone.Id
                    };
                    var zoneDetails = dnsClient.GetZone(getZoneRequest).Zone;

                    Console.WriteLine($"\t|- name: {zone.Name}");
                    Console.WriteLine($"\t|  version: {zone.Version}");
                    Console.WriteLine($"\t|  state: {zone.LifecycleState}");
                    Console.WriteLine($"\t|  timeCreated: {zone.TimeCreated}");
                    Console.WriteLine($"\t|  type: {zone.ZoneType}");
                    Console.WriteLine($"\t|  self: {zone.Self}");
                    Console.WriteLine($"\t|  serial: {zone.Serial}");
                    Console.WriteLine($"\t|  nameservers:");
                    if (zoneDetails.Nameservers != null) {
                        zoneDetails.Nameservers.ForEach(n => {
                            Console.WriteLine($"\t|  |- {n.Hostname}");
                        });
                    }
                    Console.WriteLine($"\t|  externalMasters:");
                    if (zoneDetails.ExternalMasters != null)
                    {
                        zoneDetails.ExternalMasters.ForEach(e => {
                            Console.Write($"\t|  |- {e.Addres}");
                        });
                    }

                    var getZoneRecordsRequest = new GetZoneRecordsRequest() {
                        ZoneNameOrId = zone.Id,
                        CompartmentId = com.Id
                    };
                    var zrecordRes = dnsClient.GetZoneRecords(getZoneRecordsRequest);
                    var zrecords = zrecordRes.RecordCollection.Items;

                    Console.WriteLine($"\t|  zone records");
                    foreach (var zr in zrecords)
                    {
                        Console.WriteLine($"\t|  |- domain: {zr.Domain}");
                        Console.WriteLine($"\t|  |  rrsetVersion: {zr.RrsetVersion}");
                        Console.WriteLine($"\t|  |  rtype: {zr.Rtype}");
                        Console.WriteLine($"\t|  |  rdata: {zr.Rdata}");

                        var getDomainRecordsRequest = new GetDomainRecordsRequest() {
                            ZoneNameOrId = zone.Id,
                            Domain = zr.Domain,
                            CompartmentId = com.Id
                        };

                        var drecords = dnsClient.GetDomainRecords(getDomainRecordsRequest).RecordCollection.Items;

                        Console.WriteLine($"\t|  |- domain records");
                        foreach (var dr in drecords)
                        {
                            Console.WriteLine($"\t|  |  |- domain: {dr.Domain}");
                        }

                        var getRRSetRequest = new GetRRSetRequest() {
                            ZoneNameOrId = zone.Id,
                            Domain = zr.Domain,
                            Rtype = zr.Rtype,
                            CompartmentId = com.Id
                        };

                        var rrsets = dnsClient.GetRRSet(getRRSetRequest).RRSet.Items;
                        Console.WriteLine($"\t|  |- rrset");
                        foreach (var rrset in rrsets)
                        {
                            Console.WriteLine($"\t|  |  |- rdata: {rrset.Rdata}");
                            Console.WriteLine($"\t|  |  |  ttl: {rrset.Ttl}");
                            Console.WriteLine($"\t|  |  |  rrsetVersion: {rrset.RrsetVersion}");
                        }
                    }
                }
            }
        }
    }
}
