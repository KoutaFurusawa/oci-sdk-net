using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A named set of rules to add to the load balancer.
    /// </summary>
    public class CreateRuleSetDetails
    {
        /// <summary>
        /// The name for this set of rules. It must be unique and it cannot be changed. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An array of rules that compose the rule set.
        /// </summary>
        public List<RuleDetails> Items { get; set; }
    }
}
