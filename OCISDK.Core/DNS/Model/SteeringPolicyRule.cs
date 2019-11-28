using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// The configuration of the sorting and filtering behaviors in a steering policy. 
    /// Rules can filter and sort answers based on weight, priority, endpoint health, and other data.
    /// 
    /// A rule may optionally include a sequence of cases, each with an optional caseCondition expression. 
    /// Cases allow a sequence of conditions to be defined that will apply different parameters to the rule when the conditions are met. 
    /// For more information about cases, see Traffic Management API Guide.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    // TODO: Cannot parse JSON with multiple subtype structures.
    public class SteeringPolicyRule
    {
        /// <summary>
        /// A user-defined description of the rule's purpose or behavior.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of a rule determines its sorting/filtering behavior.
        /// <para>Required: yes</para>
        /// </summary>
        public string RuleType { get;set;}

        /// <summary>
        /// An array of caseConditions. 
        /// A rule may optionally include a sequence of cases defining alternate configurations for how it should behave during processing for any given DNS query. 
        /// When a rule has no sequence of cases, it is always evaluated with the same configuration during processing. 
        /// When a rule has an empty sequence of cases, it is always ignored during processing. 
        /// When a rule has a non-empty sequence of cases, its behavior during processing is configured by the first matching case in the sequence. 
        /// When a rule has no matching cases the rule is ignored. A rule case with no caseCondition always matches. 
        /// A rule case with a caseCondition matches only when that expression evaluates to true for the given query.
        /// </summary>
        public List<SteeringPolicyRuleCase> Cases { get; set; }

        /// <summary>
        /// Defines a default set of answer conditions and values that are applied to an answer when cases is not defined for the rule, or a matching case does not 
        /// have any matching answerConditions in its answerData. defaultAnswerData is not applied if cases is defined and there are no matching cases. In this scenario, 
        /// the next rule will be processed.
        /// </summary>
        public List<SteeringPolicyAnswerData> DefaultAnswerData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? DefaultCount { get; set; }
    }

    /// <summary>
    /// SteeringPolicyRuleCase
    /// </summary>
    public class SteeringPolicyRuleCase
    {
        /// <summary>
        /// An expression that uses conditions at the time of a DNS query to indicate whether a case matches. Conditions may include the geographical location, 
        /// IP subnet, or ASN the DNS query originated. Example: If you have an office that uses the subnet 192.0.2.0/24 you could use a caseCondition expression 
        /// query.client.subnet in ('192.0.2.0/24') to define a case that matches queries from that office.
        /// </summary>
        public string CaseCondition { get; set; }

        /// <summary>
        /// An array of SteeringPolicyPriorityAnswerData objects.
        /// </summary>
        public List<SteeringPolicyAnswerData> AnswerData { get; set; }

        /// <summary>
        /// case count.
        /// </summary>
        public int? Count { get; set; }
    }

    /// <summary>
    /// SteeringPolicyAnswerData
    /// </summary>
    public class SteeringPolicyAnswerData
    {
        /// <summary>
        /// An expression that is used to select a set of answers that match a condition. For example, answers with matching pool properties.
        /// </summary>
        public string AnswerCondition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? ShouldKeep { get; set; }

        /// <summary>
        /// The rank assigned to the set of answers that match the expression in answerCondition. 
        /// Answers with the lowest values move to the beginning of the list without changing the relative order of those with the same value. 
        /// Answers can be given a value between 0 and 255.
        /// </summary>
        public int? Value { get; set; }
    }
}
