using OCISDK.Core.src.UnpublishedService.Commercial.Request;
using OCISDK.Core.src.UnpublishedService.Commercial.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.UnpublishedService.Commercial
{
    /// <summary>
    /// In the future, these methods will move or change the namespace.
    /// </summary>
    public interface ICommercialClient
    {
        /// <summary>
        /// setter region
        /// </summary>
        /// <param name="region"></param>
        void SetRegion(string region);

        /// <summary>
        /// getter region
        /// </summary>
        /// <returns></returns>
        string GetRegion();

        /// <summary>
        /// GetPurchaseEntitlements
        /// </summary>
        /// <param name="requets"></param>
        /// <returns></returns>
        ListPurchaseEntitlementsResponse ListPurchaseEntitlements(ListPurchaseEntitlementsRequest requets);
    }
}
