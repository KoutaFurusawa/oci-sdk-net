using OCISDK.Core.UnpublishedService.UsageCosts.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.UsageCosts.Response
{
    /// <summary>
    /// GetSubscriptionInfo Response
    /// </summary>
    public class GetSubscriptionInfoResponse
    {
        /// <summary>
        /// opc-request-id
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// SubscriptionInfo
        /// </summary>
        public SubscriptionInfo SubscriptionInfo { get; set; }
    }
}
