using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Model
{
    /// <summary>
    /// The account (tenant) usage.
    /// </summary>
    public class UsageAggregation
    {
        /// <summary>
        /// Aggregate the result by.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> GroupBy { get; set; }

        /// <summary>
        /// A list of usage items.
        /// <para>Required: yes</para>
        /// </summary>
        public List<UsageSummary> Items { get; set; }
    }
}
