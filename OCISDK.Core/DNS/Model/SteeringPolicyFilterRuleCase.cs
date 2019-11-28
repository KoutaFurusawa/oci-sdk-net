using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// SteeringPolicyFilterRuleCase Reference
    /// </summary>
    public class SteeringPolicyFilterRuleCase
    {
        /// <summary>
        /// An expression that uses conditions at the time of a DNS query to indicate whether a case matches.
        /// Conditions may include the geographical location, IP subnet, or ASN the DNS query originated.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public string CaseCondition { get; set; }

        /// <summary>
        /// An array of SteeringPolicyFilterAnswerData objects.
        /// <para>Required: no</para>
        /// <para>Max Items: 50</para>
        /// </summary>
        public List<SteeringPolicyFilterAnswerData> AnswerData { get; set; }
    }
}
