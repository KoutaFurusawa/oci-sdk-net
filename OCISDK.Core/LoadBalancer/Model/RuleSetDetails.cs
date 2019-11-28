using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A named set of rules associated with a load balancer. 
    /// Rules are objects that represent actions to apply to a listener, such as adding, altering, or removing HTTP headers. 
    /// For more information, see Managing Rule Sets.
    /// </summary>
    public class RuleSetDetails
    {
        /// <summary>
        /// The name for this set of rules. It must be unique and it cannot be changed. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An array of rules that compose the rule set.
        /// <para>Required: yes</para>
        /// </summary>
        public List<RuleDetails> Items { get; set; }
    }
}
