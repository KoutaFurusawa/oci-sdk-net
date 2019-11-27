using OCISDK.Core.UnpublishedService.Commercial.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.Commercial.Response
{
    /// <summary>
    /// GetPurchaseEntitlements Response
    /// </summary>
    public class ListPurchaseEntitlementsResponse
    {
        /// <summary>
        /// opc-request-id
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// arrary PurchaseEntitlements
        /// </summary>
        public List<PurchaseEntitlements> Items { get; set; }
    }
}
