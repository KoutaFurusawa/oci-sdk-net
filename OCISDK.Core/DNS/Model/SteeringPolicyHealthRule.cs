using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// SteeringPolicyHealthRule Reference
    /// </summary>
    // TODO: Cannot parse JSON with multiple subtype structures.
    public class SteeringPolicyHealthRule : SteeringPolicyRule
    {
        /// <summary>
        /// An array of caseConditions. A rule may optionally include a sequence of cases defining alternate configurations for how it 
        /// should behave during processing for any given DNS query. When a rule has no sequence of cases, it is always evaluated with 
        /// the same configuration during processing. When a rule has an empty sequence of cases, it is always ignored during processing. 
        /// When a rule has a non-empty sequence of cases, its behavior during processing is configured by the first matching case in the sequence. 
        /// When a rule has no matching cases the rule is ignored. A rule case with no caseCondition always matches. 
        /// A rule case with a caseCondition matches only when that expression evaluates to true for the given query.
        /// <para>Required: no</para>
        /// </summary>
        public new List<SteeringPolicyHealthRuleCase> Cases { get; set; }
    }
}
