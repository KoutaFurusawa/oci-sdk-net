using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Request
{
    /// <summary>
    /// GetSubscription request
    /// </summary>
    public class GetSubscriptionRequest
    {
        /// <summary>
        /// Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the subscription to retrieve.
        /// <para>Required: yes</para>
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}
