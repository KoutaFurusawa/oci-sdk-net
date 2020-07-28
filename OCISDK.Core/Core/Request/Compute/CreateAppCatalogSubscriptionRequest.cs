using OCISDK.Core.Core.Model.Compute;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// CreateAppCatalogSubscription request
    /// </summary>
    public class CreateAppCatalogSubscriptionRequest
    {
        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a timeout or 
        /// server error without risk of executing that same action again. Retry tokens expire after 
        /// 24 hours, but can be invalidated before then due to conflicting operations (for 
        /// example, if a resource has been deleted and purged from the system, then a retry of 
        /// the original creation request may be rejected).
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// The request body must contain a single CreateAppCatalogSubscriptionDetails resource.
        /// </summary>
        public CreateAppCatalogSubscriptionDetails CreateAppCatalogSubscriptionDetails { get; set; }
    }
}
