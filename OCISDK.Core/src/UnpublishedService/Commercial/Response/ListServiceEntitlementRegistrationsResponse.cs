using OCISDK.Core.src.UnpublishedService.Commercial.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.UnpublishedService.Commercial.Response
{
    /// <summary>
    /// ListServiceEntitlementRegistrations response
    /// </summary>
    public class ListServiceEntitlementRegistrationsResponse
    {
        /// <summary>
        /// opc-request-id
        /// </summary>
        public string OpcRequestId { get; set; }

        public List<ServiceEntitlementRegistrations> Items { get; set; }
    }
}
