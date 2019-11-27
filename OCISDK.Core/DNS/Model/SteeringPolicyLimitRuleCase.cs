using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// SteeringPolicyLimitRuleCase Reference
    /// </summary>
    public class SteeringPolicyLimitRuleCase
    {
        /// <summary>
        /// An expression that uses conditions at the time of a DNS query to indicate whether a case matches.
        /// Conditions may include the geographical location, IP subnet, or ASN the DNS query originated.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public string CaseCondition { get; set; }

        /// <summary>
        /// The number of answers allowed to remain after the limit rule has been processed, keeping only the first of the remaining answers in the list.
        /// Example: If the count property is set to 2 and four answers remain before the limit rule is processed, only the first two answers in the list 
        /// will remain after the limit rule has been processed.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 65535</para>
        /// </summary>
        public int Count { get; set; }
    }
}
