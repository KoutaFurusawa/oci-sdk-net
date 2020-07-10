using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// Retention rule collection.
    /// </summary>
    public class RetentionRuleCollection
    {
        /// <summary>
        /// An array of retention rule summaries.
        /// </summary>
        public List<RetentionRuleSummary> Items { get; set; }
    }
}
