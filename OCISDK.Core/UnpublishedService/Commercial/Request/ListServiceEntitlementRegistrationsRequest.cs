using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.Commercial.Request
{
    /// <summary>
    /// ListServiceEntitlementRegistrations request
    /// </summary>
    public class ListServiceEntitlementRegistrationsRequest
    {
        /// <summary>
        /// opc-request-id
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// compartmentId
        /// </summary>
        public string CompartmentId { get; set; }
    }
}
