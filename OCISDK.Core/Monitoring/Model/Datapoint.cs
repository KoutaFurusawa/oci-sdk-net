using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// Metric value for a specific timestamp.
    /// </summary>
    public class Datapoint
    {
        /// <summary>
        /// Timestamp for this metric value. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Numeric value of the metric.
        /// <para>Required: yes</para>
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// The number of occurrences of the associated value in the set of data.
        /// <para>Required: no</para>
        /// </summary>
        public int Count { get; set; }
    }
}
