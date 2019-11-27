using OCISDK.Core.UnpublishedService.Commercial.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.Commercial.Response
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

        /// <summary>
        /// arrary ServiceEntitlementRegistrations
        /// </summary>
        public List<ServiceEntitlementRegistrations> Items { get; set; }
    }
}
