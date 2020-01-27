using OCISDK.Core.Notification.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Response
{
    /// <summary>
    /// UpdateTopic response
    /// </summary>
    public class UpdateTopicResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The response body will contain a single NotificationTopic resource.
        /// </summary>
        public NotificationTopicDetails NotificationTopic { get; set; }
    }
}
