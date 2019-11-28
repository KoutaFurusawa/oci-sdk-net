using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// A timestamp-value pair returned for the specified request.
    /// </summary>
    public class AggregatedDatapoint
    {
        /// <summary>
        /// The date and time associated with the value of this data point. Format defined by RFC3339.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Numeric value of the metric.
        /// </summary>
        public double Value { get; set; }
    }
}
