using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Search;
using OCISDK.Core.Search.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class SearchExample
    {
        public static void SearchResourcesExample(ClientConfig config)
        {
            var client = new SearchClient(config)
            {
                Region = Regions.US_ASHBURN_1
            };

            var param = new SearchResourcesRequest()
            {
                SearchDetails = new OCISDK.Core.Search.Model.SearchDetails()
                {
                    Type = "Structured",
                    Query = "query instance resources where lifeCycleState = 'RUNNING'"
                }
            };
            var runningInstances = client.SearchResources(param);
            Console.WriteLine($"query:{param.SearchDetails.Query}");
            foreach(var run in runningInstances.ResourceSummaryCollection.Items)
            {
                Console.WriteLine($"\tname:{run.DisplayName}, state:{run.LifecycleState}");
            }

            param = new SearchResourcesRequest()
            {
                SearchDetails = new OCISDK.Core.Search.Model.SearchDetails()
                {
                    Type = "Structured",
                    Query = "query user resources where displayName = 'jone@example.com'"
                }
            };
            var user = client.SearchResources(param);
            Console.WriteLine($"query:{param.SearchDetails.Query}");
            foreach (var u in user.ResourceSummaryCollection.Items)
            {
                Console.WriteLine($"\tname:{u.DisplayName}, state:{u.LifecycleState}");
            }

            param = new SearchResourcesRequest()
            {
                SearchDetails = new OCISDK.Core.Search.Model.SearchDetails()
                {
                    Type = "FreeText",
                    MatchingContextType = "HIGHLIGHTS",
                    Text = "admin"
                }
            };
            Console.WriteLine($"query:{param.SearchDetails.Query}");
            var freeSearch = client.SearchResources(param);
            foreach (var free in freeSearch.ResourceSummaryCollection.Items)
            {
                Console.WriteLine($"\tname:{free.DisplayName}, state:{free.LifecycleState}");
            }
        }
    }
}
