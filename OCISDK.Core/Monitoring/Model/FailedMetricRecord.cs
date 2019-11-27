using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The record of a single metric object that failed input validation and the reason for the failure.
    /// </summary>
    public class FailedMetricRecord
    {
        /// <summary>
        /// An error message indicating the reason that the indicated metric object failed input validation.
        /// <para>Required: yes</para>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Identifier of a metric object that failed input validation.
        /// <para>Required: yes</para>
        /// </summary>
        public MetricDataDetails MetricData { get; set; }
    }
}
