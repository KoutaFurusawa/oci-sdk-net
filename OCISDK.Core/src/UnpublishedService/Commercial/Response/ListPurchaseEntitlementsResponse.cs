using OCISDK.Core.src.UnpublishedService.Commercial.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.UnpublishedService.Commercial.Response
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
