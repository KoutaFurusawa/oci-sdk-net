using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// TableUsageSummary represents a single usage record, or slice, that includes information about read and write throughput 
    /// consumed during that period as well as the current information regarding storage capacity. In addition the count of throttling 
    /// exceptions for the period is reported.
    /// </summary>
    public class TableUsageSummary
    {
        /// <summary>
        /// The length of the sampling period.
        /// <para>Required: no</para>
        /// </summary>
        public int? SecondsInPeriod { get; set; }

        /// <summary>
        /// Read throughput during the sampling period.
        /// <para>Required: no</para>
        /// </summary>
        public int? ReadUnits { get; set; }

        /// <summary>
        /// Write throughput during the sampling period.
        /// <para>Required: no</para>
        /// </summary>
        public int? WriteUnits { get; set; }

        /// <summary>
        /// The size of the table, in GB.
        /// <para>Required: no</para>
        /// </summary>
        public int? StorageInGBs { get; set; }

        /// <summary>
        /// The number of times reads were throttled due to exceeding the read throughput limit.
        /// <para>Required: no</para>
        /// </summary>
        public int? ReadThrottleCount { get; set; }

        /// <summary>
        /// The number of times writes were throttled due to exceeding the write throughput limit.
        /// <para>Required: no</para>
        /// </summary>
        public int? WriteThrottleCount { get; set; }

        /// <summary>
        /// The number of times writes were throttled because the table exceeded its size limit.
        /// <para>Required: no</para>
        /// </summary>
        public int? StorageThrottleCount { get; set; }
    }
}
