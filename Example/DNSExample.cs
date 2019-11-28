using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.DNS;
using OCISDK.Core.DNS.Model;
using OCISDK.Core.DNS.Request;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Request;
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
            
            Console.WriteLine("* DNS SteeringPolicy------------------------");
            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }

                Console.WriteLine($" Compartment<{com.Name}>--------");

                var listSteeringPoliciesRequest = new ListSteeringPoliciesRequest() {
                    CompartmentId = com.Id,
                    SortBy = ListSteeringPoliciesRequest.SortByParam.DisplayName
                };
                var steeringPolicies = dnsClient.ListSteeringPolicies(listSteeringPoliciesRequest).Items;
                foreach (var sp in steeringPolicies)
                {
                    var getSteeringPolicyRequest = new GetSteeringPolicyRequest() {
                        SteeringPolicyId = sp.Id
                    };
                    var steeringPolicy = dnsClient.GetSteeringPolicy(getSteeringPolicyRequest).SteeringPolicy;
                    Console.WriteLine($"\t|- displayName: {steeringPolicy.DisplayName}");
                    Console.WriteLine($"\t|  state: {steeringPolicy.LifecycleState}");
                    Console.WriteLine($"\t|  timeCreated: {steeringPolicy.TimeCreated}");
                    Console.WriteLine($"\t|  rule: {steeringPolicy.Rules.Count}");
                    foreach (var rule in steeringPolicy.Rules)
                    {
                        Console.WriteLine($"\t|  | type: {rule.RuleType}");
                    }
                    Console.WriteLine($"\t|  Answer: {steeringPolicy.Answers.Count}");
                    foreach (var answer in steeringPolicy.Answers)
                    {
                        Console.WriteLine($"\t|  | name: {answer.Name}");
                        Console.WriteLine($"\t|  | pool: {answer.Pool}");
                        Console.WriteLine($"\t|  | rtype: {answer.Rtype}");
                        Console.WriteLine($"\t|  | rdata: {answer.Rdata}");
                    }

                    var listSteeringPolicyAttachmentsRequest = new ListSteeringPolicyAttachmentsRequest() {
                        SteeringPolicyId = sp.Id,
                        CompartmentId = com.Id
                    };
                    var steeringPolicyAttachments = dnsClient.ListSteeringPolicyAttachments(listSteeringPolicyAttachmentsRequest).Items;
                    if (steeringPolicyAttachments.Count > 0)
                    {
                        Console.WriteLine($"\t|  Attach: {steeringPolicyAttachments.Count}");
                        foreach (var attach in steeringPolicyAttachments)
                        {
                            Console.WriteLine($"\t|  | state: {attach.LifecycleState}");
                            Console.WriteLine($"\t|  | rtype: {attach.Rtypes}");
                            Console.WriteLine($"\t|  | self: {attach.Self}");
                            Console.WriteLine($"\t|  | timeCreated: {attach.TimeCreated}");
                            Console.WriteLine($"\t|  | zoneId: {attach.ZoneId}");
                        }
                    }
                }
            }

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
                    SortBy = ListZonesRequest.SortByParam.Name
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
