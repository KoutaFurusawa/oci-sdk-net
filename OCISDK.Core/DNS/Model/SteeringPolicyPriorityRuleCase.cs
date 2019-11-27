using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// SteeringPolicyPriorityRuleCase Reference
    /// </summary>
    public class SteeringPolicyPriorityRuleCase
    {
        /// <summary>
        /// An expression that uses conditions at the time of a DNS query to indicate whether a case matches.
        /// Conditions may include the geographical location, IP subnet, or ASN the DNS query originated.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        /// <example>Example: If you have an office that uses the subnet 192.0.2.0/24 you could use a caseCondition 
        /// expression query.client.subnet in ('192.0.2.0/24') to define a case that matches queries from that office.</example>
        public string CaseCondition { get; set; }

        /// <summary>
        /// An array of SteeringPolicyPriorityAnswerData objects.
        /// <para>Required: no</para>
        /// <para>Max Items: 50</para>
        /// </summary>
        public List<SteeringPolicyPriorityAnswerData> AnswerData { get; set; }
    }
}
