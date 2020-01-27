using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Notification.Request
{
    /// <summary>
    /// GetTopic request
    /// </summary>
    public class GetTopicRequest
    {
        /// <summary>
        /// The OCID of the topic to retrieve.
        /// Transactions Per Minute (TPM) per-tenancy limit for this operation: 120.
        /// <para>Required: yes</para>
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

    }
}
