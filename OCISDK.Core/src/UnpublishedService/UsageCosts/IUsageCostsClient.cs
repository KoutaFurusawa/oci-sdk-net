using OCISDK.Core.src.UnpublishedService.UsageCosts.Request;
using OCISDK.Core.src.UnpublishedService.UsageCosts.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.UnpublishedService.UsageCosts
{
    /// <summary>
    /// UsageCosts Client
    /// 
    /// In the future, these methods will move or change the namespace.
    /// </summary>
    public interface IUsageCostsClient
    {
        /// <summary>
        /// GetSubscriptionInfo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetSubscriptionInfoResponse GetSubscriptionInfo(GetSubscriptionInfoRequest request);
    }
}
