using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.Commercial.Request
{
    /// <summary>
    /// GetPurchaseEntitlements Request
    /// </summary>
    public class ListPurchaseEntitlementsRequest
    {
        /// <summary>
        /// opc-request-id
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// compartment OCID
        /// </summary>
        public string CompartmentId { get; set; }
    }
}
