using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Throughput and storage limits configuration of a table.
    /// </summary>
    public class TableLimits
    {
        /// <summary>
        /// Maximum sustained read throughput limit for the table.
        /// <para>Required: yes</para>
        /// </summary>
        public int MaxReadUnits { get; set; }

        /// <summary>
        /// Maximum sustained write throughput limit for the table.
        /// <para>Required: yes</para>
        /// </summary>
        public int MaxWriteUnits { get; set; }

        /// <summary>
        /// Maximum size of storage used by the table.
        /// <para>Required: yes</para>
        /// </summary>
        public int MaxStorageInGBs { get; set; }
    }
}
