using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Model;
using OCISDK.Core.Identity.Request;
using System;

namespace Example
{
    class IdentityCompartmentExample
    {
        public static void CompartmentConsoleDisplay(ClientConfig config)
        {
            IdentityClient identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            Console.WriteLine("* GetTenacy------------------------");
            GetTenancyRequest getTenancyRequest = new GetTenancyRequest()
            {
                TenancyId = identityClient.Config.TenancyId
            };
            var getTenacy = identityClient.GetTenancy(getTenancyRequest);
            Console.WriteLine(" name:"+getTenacy.Tenancy.Name + ",");
            Console.WriteLine(" id:" + getTenacy.Tenancy.Id + ",");
            Console.WriteLine(" description:" + getTenacy.Tenancy.Description + ",");
            Console.WriteLine(" homeregion:" + config.GetRegionName(getTenacy.Tenancy.HomeRegionKey) + ",");
            // tagNamespaces get in tetancy(root compartment)
            Console.WriteLine(" tagNamespaces:");
            var listTagNamespacesRequest = new ListTagNamespacesRequest()
            {
                CompartmentId = getTenacy.Tenancy.Id,
                Limit = 50
            };
            var listTagNs = identityClient.ListTagNamespaces(listTagNamespacesRequest);
            listTagNs.Items.ForEach(tagNs => {
                Console.WriteLine("\t|- name: " + tagNs.Name);
                Console.WriteLine("\t|  id: " + tagNs.Id);
                Console.WriteLine("\t|  description: " + tagNs.Description);
                //tag list
                var listTagsRequest = new ListTagsRequest()
                {
                    TagNamespaceId = tagNs.Id,
                    Limit = 50
                };
                var listTags = identityClient.ListTags(listTagsRequest);
                listTags.Items.ForEach(tag=> {
                    Console.WriteLine("\t|\t|- * " + tag.Name);
                    Console.WriteLine("\t|\t| id: " + tag.Id);
                    Console.WriteLine("\t|\t| costTracking: " + tag.IsCostTracking);
                });
            });

            // tagDefaults get in tetancy(root compartment)
            Console.WriteLine(" tagDefaults:");
            var listTagsDefaultRequest = new ListTagDefaultsRequest()
            {
                CompartmentId = getTenacy.Tenancy.Id,
                Limit = 50
            };
            var listDefaultTags = identityClient.ListTagDefaults(listTagsDefaultRequest);
            listDefaultTags.Items.ForEach(tag => {
                Console.WriteLine("\t|- DefaultTags");
                Console.WriteLine("\t|  id: " + tag.Id);
                Console.WriteLine("\t|  tagDefinitionName: " + tag.TagDefinitionName);
                Console.WriteLine("\t|  tagNamespaceId: " + tag.TagNamespaceId);
                Console.WriteLine("\t|  tagDefinitionId: " + tag.TagDefinitionId);
                Console.WriteLine("\t|  lifecycleState: " + tag.LifecycleState);
            });

            var listCostTrackingTagsRequest = new ListCostTrackingTagsRequest()
            {
                CompartmentId = getTenacy.Tenancy.Id,
                Limit = 100
            };
            var listCostTrackingTags = identityClient.ListCostTrackingTags(listCostTrackingTagsRequest);
            listCostTrackingTags.Items.ForEach(tag => {
                Console.WriteLine("\t|- CostTackingTags");
                Console.WriteLine("\t|  id: " + tag.Id);
                Console.WriteLine("\t|  isCostTracking: " + tag.IsCostTracking);
                Console.WriteLine("\t|  tagNamespaceId: " + tag.TagNamespaceId);
                Console.WriteLine("\t|  tagNamespaceName: " + tag.TagNamespaceName);
                Console.WriteLine("\t|  name: " + tag.Name);
            });

            Console.WriteLine();
            Console.WriteLine("* ListRegions------------------------");
            var listRegion = identityClient.ListRegions();
            listRegion.Items.ForEach(r => {
                Console.WriteLine("\tname: " + r.Name);
                Console.WriteLine("\tkey: " + r.Key);
            });

            Console.WriteLine("* ListRegionsSubscriptions------------------------");
            var listRegionSubscriptionsRequest = new ListRegionSubscriptionsRequest()
            {
                TenancyId = getTenacy.Tenancy.Id,
            };
            var listRegionSubscriptions = identityClient.ListRegionSubscriptions(listRegionSubscriptionsRequest);
            listRegionSubscriptions.Items.ForEach(r => {
                Console.WriteLine("\tname: " + r.RegionKey);
                Console.WriteLine("\tkey: " + r.RegionName);
                Console.WriteLine("\tstatus: " + r.Status);
                Console.WriteLine("\thome: " + r.IsHomeRegion);
            });
            
            Console.WriteLine();
            Console.WriteLine("* ListAvailabilityDomain------------------------");
            var listAvailabilityDomainRequest = new ListAvailabilityDomainsRequest()
            {
                CompartmentId = getTenacy.Tenancy.Id
            };
            var listAD= identityClient.ListAvailabilityDomains(listAvailabilityDomainRequest);
            listAD.Items.ForEach(ad => {
                Console.WriteLine("\tname: " + ad.Name);
                Console.WriteLine("\tid: " + ad.Id);
            });

            Console.WriteLine();
            Console.WriteLine("* ListCompartment------------------------");
            var listCompartmenRequest = new ListCompartmentRequest()
            {
                CompartmentId = getTenacy.Tenancy.Id,
                CompartmentIdInSubtree = true,
                AccessLevel = ListCompartmentRequest.AccessLevels.ACCESSIBLE,
                Limit = 10
            };
            var listCompartment = identityClient.ListCompartment(listCompartmenRequest);
            listCompartment.Items.ForEach(comp => {
                // compartment detail get
                var getCompartmentRequest = new GetCompartmentRequest()
                {
                    CompartmentId = comp.Id
                };
                var getCompartment = identityClient.GetCompartment(getCompartmentRequest);
                Console.WriteLine("\t|- name: " + getCompartment.Compartment.Name);
                Console.WriteLine("\t|\t id: " + getCompartment.Compartment.Id);
                Console.WriteLine("\t|\t lifecycleState: " + getCompartment.Compartment.LifecycleState);
                Console.WriteLine("\t|\t timeCreated: " + getCompartment.Compartment.TimeCreated);
                Console.WriteLine("\t|\t inactiveStatus: " + getCompartment.Compartment.InactiveStatus);
                var path = GetCompartmetPath(identityClient, getCompartment.Compartment.Id);
                Console.WriteLine("\t|\t path: " + path);
                getCompartmentRequest = new GetCompartmentRequest()
                {
                    CompartmentId = getCompartment.Compartment.CompartmentId
                };
                getCompartment = identityClient.GetCompartment(getCompartmentRequest);
                Console.WriteLine("\t|\t parent: " + getCompartment.Compartment.Name);

                // tagNamespaces get in compartment
                Console.WriteLine("\t|\t tgaNamespaces:");
                listTagNamespacesRequest = new ListTagNamespacesRequest()
                {
                    CompartmentId = comp.Id,
                    Limit = 50
                };
                listTagNs = identityClient.ListTagNamespaces(listTagNamespacesRequest);
                listTagNs.Items.ForEach(tagNs => {
                    Console.WriteLine("\t|\t |- name: " + tagNs.Name);
                    Console.WriteLine("\t|\t |  id: " + tagNs.Id);
                    Console.WriteLine("\t|\t |  description: " + tagNs.Description);
                    Console.WriteLine("\t|\t |  timeCreated: " + tagNs.TimeCreated);
                });
            });
        }

        private static string GetCompartmetPath(IdentityClient identityClient, string compartmentId)
        {
            var res = "";

            var getCompartmentRequest = new GetCompartmentRequest()
            {
                CompartmentId = compartmentId
            };
            var getCompartment = identityClient.GetCompartment(getCompartmentRequest).Compartment;

            res = $"{getCompartment.Name}{res}";

            if (!string.IsNullOrEmpty(getCompartment.CompartmentId)) {
                res = $"{GetCompartmetPath(identityClient, getCompartment.CompartmentId)}/{res}";
            }

            return res;
        }
    }
}
