using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The attributes of a rule associated with the specified listener, and the name of the rule set that the rule belongs to.
    /// </summary>
    public class ListenerRuleSummary
    {
        /// <summary>
        /// A rule object that applies to the listener.
        /// <para>Required: no</para>
        /// </summary>
        public RuleDetails Rule { get; set; }

        /// <summary>
        /// The name of the rule set that the rule belongs to.
        /// <para>Required: no</para>
        /// </summary>
        public string RuleSetName { get; set; }
    }
}
