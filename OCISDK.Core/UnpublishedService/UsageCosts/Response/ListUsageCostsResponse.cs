using OCISDK.Core.UnpublishedService.UsageCosts.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.UsageCosts.Response
{
    /// <summary>
    /// ListUsageCosts response
    /// </summary>
    public class ListUsageCostsResponse
    {
        /// <summary>
        /// opc-request-id
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// UsageCost
        /// </summary>
        public List<UsageCostDetails> Items { get; set; }
    }
}
