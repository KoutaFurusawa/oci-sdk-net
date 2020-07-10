using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Result of GetTableUsage.
    /// </summary>
    public class TableUsageCollection
    {
        /// <summary>
        /// A page of TableUsageSummary objects.
        /// <para>Required: no</para>
        /// </summary>
        public List<TableUsageSummary> Items { get; set; }
    }
}
