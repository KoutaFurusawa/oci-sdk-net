using OCISDK.Core.Monitoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Response
{
    /// <summary>
    /// PostMetricData Response
    /// </summary>
    public class PostMetricDataResponse
    {
        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single PostMetricDataDetails resource.
        /// </summary>
        public PostMetricDataResponseDetails PostMetricDataResponseDetails { get; set; }
    }
}
