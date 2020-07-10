using OCISDK.Core;
using OCISDK.Core.Common;
using OCISDK.Core.Usage;
using OCISDK.Core.Usage.Request;
using System;
using System.Collections.Generic;
using System.Text;
using static OCISDK.Core.Usage.Model.RequestSummarizedUsagesDetails;

namespace Example
{
    class UsageExample
    {
        public static void Example(ClientConfig config)
        {
            var client = new UsageClient(config)
            {
                Region = Regions.AP_TOKYO_1
            };

            RequestSummarizedConfigurationsRequest configurationsRequest = new RequestSummarizedConfigurationsRequest
            {
                TenantId = config.TenancyId
            };
            var configurations = client.RequestSummarizedConfigurations(configurationsRequest);

            RequestSummarizedUsagesRequest usagesRequest = new RequestSummarizedUsagesRequest
            {
                RequestSummarizedUsagesDetails = new OCISDK.Core.Usage.Model.RequestSummarizedUsagesDetails
                {
                    TenantId = config.TenancyId,
                    TimeUsageStarted = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    TimeUsageEnded = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                    Granularity = GranularityParam.DAILY
                }
            };

            Console.WriteLine("Daily cost info -----------------------------");
            do
            {
                var consts = client.RequestSummarizedUsages(usagesRequest);

                foreach (var cost in consts.UsageAggregation.Items)
                {
                    Console.WriteLine("start:" + cost.TimeUsageStarted + " - end:" + cost.TimeUsageEnded);
                    Console.WriteLine("service:" + cost.Service);
                    Console.WriteLine("resource:" + cost.ResourceName + "(" + cost.ResourceId + ")");
                    Console.WriteLine("amount:" +  cost.ComputedAmount + "(" + cost.Currency + ")");
                    Console.WriteLine("overage:" + cost.Overage + "(" + cost.Currency + ")");
                }

                if (string.IsNullOrEmpty(consts.OpcNextPage))
                {
                    break;
                }

                usagesRequest.Page = consts.OpcNextPage;
            } while (true);
        }
    }
}
