using OCISDK.Core.src.Monitoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Monitoring.Response
{
    public class SummarizeMetricsDataResponse
    {
        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain an array of MetricData resources.
        /// </summary>
        public List<MetricData> Items { get; set; }
    }
}
