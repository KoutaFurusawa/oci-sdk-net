using OCISDK.Core;
using OCISDK.Core.Budgets;
using OCISDK.Core.Budgets.Request;
using OCISDK.Core.Common;
using OCISDK.Core.Identity;
using OCISDK.Core.Identity.Model;
using OCISDK.Core.Identity.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class BudgetsExample
    {
        public static void ConsoleDisplay(ClientConfig config)
        {
            var identityClient = new IdentityClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var budgetClient = new BudgetsClient(config)
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

            compartments.Add(new Compartment{ 
                Id = config.TenancyId,
                Name = "root compartment",
                LifecycleState = "ACTIVE"
            });

            Console.WriteLine("* Budgets Resources------------------------");
            foreach (var com in compartments)
            {
                if (com.LifecycleState != "ACTIVE")
                {
                    continue;
                }

                Console.WriteLine($" Compartment<{com.Name}>--------");

                ListBudgetsRequest listBudgetsRequest = new ListBudgetsRequest()
                {
                    CompartmentId = com.Id
                };

                var budgets = budgetClient.ListBudgets(listBudgetsRequest);

                foreach (var budget in budgets.Items)
                {
                    Console.WriteLine($"\t|-name:{budget.DisplayName}, state:{budget.LifecycleState}, amount:{budget.Amount}");
                }
            }
        }
    }
}
