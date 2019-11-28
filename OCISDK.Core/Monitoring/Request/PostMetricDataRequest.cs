using OCISDK.Core.Monitoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Request
{
    /// <summary>
    /// PostMetricData Request
    /// </summary>
    public class PostMetricDataRequest
    {
        /// <summary>
        /// Customer part of the request identifier token. 
        /// If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single PostMetricDataDetails resource.
        /// </summary>
        public PostMetricDataDetails PostMetricDataDetails { get; set; }
    }
}
