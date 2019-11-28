using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The response object returned from a PostMetricData operation.
    /// </summary>
    public class PostMetricDataResponseDetails
    {
        /// <summary>
        /// The number of metric objects that failed input validation.
        /// <para>Required: yes</para>
        /// </summary>
        public int FailedMetricsCount { get; set; }

        /// <summary>
        /// A list of records identifying metric objects that failed input validation and the reasons for the failures.
        /// <para>Required: no</para>
        /// </summary>
        public List<FailedMetricRecord> FailedMetrics { get; set; }
    }
}
