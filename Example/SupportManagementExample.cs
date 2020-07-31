using OCISDK.Core;
using OCISDK.Core.SupportManagement;
using OCISDK.Core.SupportManagement.Request;
using OCISDK.Core.UnpublishedService.Commercial;
using OCISDK.Core.UnpublishedService.Commercial.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example
{
    class SupportManagementExample
    {
        public static void Example(ClientConfig config)
        {
            var client = new SupportManagementClient(config)
            {
                Region = config.HomeRegion
            };

            var commercialClient = new CommercialClient(config)
            {
                Region = config.HomeRegion
            };

            ListPurchaseEntitlementsRequest listPurchaseEntitlementsRequest = new ListPurchaseEntitlementsRequest
            {
                CompartmentId = config.TenancyId
            };
            var entitys = commercialClient.ListPurchaseEntitlements(listPurchaseEntitlementsRequest);

            if (entitys.Items.Count <= 0 && entitys.Items.Where(e => !string.IsNullOrEmpty(e.CsiNumber)).Count() <= 0)
            {
                Console.WriteLine("not entity data!");
            }

            ListIncidentsRequest listIncidentsRequest = new ListIncidentsRequest
            {
                CompartmentId = config.TenancyId,
                Csi = entitys.Items[0].CsiNumber,
                Ocid = config.UserId
            };

            var incidents = client.ListIncidents(listIncidentsRequest);

            foreach (var incident in incidents.Items)
            {
                Console.WriteLine("* " + incident.Key + ": " + incident.Ticket.Title);
                Console.WriteLine("  status - "+ incident.Ticket.LifecycleState);
            }
        }
    }
}
