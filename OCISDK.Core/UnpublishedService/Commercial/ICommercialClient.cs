using OCISDK.Core.UnpublishedService.Commercial.Request;
using OCISDK.Core.UnpublishedService.Commercial.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.UnpublishedService.Commercial
{
    /// <summary>
    /// In the future, these methods will move or change the namespace.
    /// </summary>
    public interface ICommercialClient : IClientSetting
    {
        /// <summary>
        /// GetPurchaseEntitlements
        /// </summary>
        /// <param name="requets"></param>
        /// <returns></returns>
        ListPurchaseEntitlementsResponse ListPurchaseEntitlements(ListPurchaseEntitlementsRequest requets);

        /// <summary>
        /// ListServiceEntitlementRegistrations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListServiceEntitlementRegistrationsResponse ListServiceEntitlementRegistrations(ListServiceEntitlementRegistrationsRequest request);
    }
}
