using OCISDK.Core.Notification.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Response
{
    /// <summary>
    /// ResendSubscriptionConfirmation response
    /// </summary>
    public class ResendSubscriptionConfirmationResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single Subscription resource.
        /// </summary>
        public SubscriptionDetails Subscription { get; set; }
    }
}
