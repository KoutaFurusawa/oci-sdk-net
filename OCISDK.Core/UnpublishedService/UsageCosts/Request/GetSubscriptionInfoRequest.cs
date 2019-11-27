using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.UsageCosts.Request
{
    /// <summary>
    /// GetSubscriptionInfo Request
    /// </summary>
    public class GetSubscriptionInfoRequest
    {
        /// <summary>
        /// opc-request-id
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Tenancy OCID
        /// </summary>
        public string TenancyId { get; set; }
    }
}
