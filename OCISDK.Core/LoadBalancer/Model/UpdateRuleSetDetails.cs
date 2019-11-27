using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// An updated set of rules that overwrites the existing set of rules.
    /// </summary>
    public class UpdateRuleSetDetails
    {
        /// <summary>
        /// An array of rules that compose the rule set.
        /// <para>Required: yes</para>
        /// </summary>
        public List<RuleDetails> Items { get; set; }
    }
}
