using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.DNS.Model
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

        public List<SteeringPolicyRuleCase> Cases { get; set; }

        public List<SteeringPolicyAnswerData> DefaultAnswerData { get; set; }

        public int? DefaultCount { get; set; }
    }

    public class SteeringPolicyRuleCase
    {
        public string CaseCondition { get; set; }

        public List<SteeringPolicyAnswerData> AnswerData { get; set; }

        public int? Count { get; set; }
    }

    public class SteeringPolicyAnswerData
    {
        public string AnswerCondition { get; set; }

        public bool? ShouldKeep { get; set; }

        public int? Value { get; set; }
    }
}
