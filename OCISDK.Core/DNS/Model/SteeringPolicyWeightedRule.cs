﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// SteeringPolicyWeightedRule Reference
    /// </summary>
    // TODO: Cannot parse JSON with multiple subtype structures.
    public class SteeringPolicyWeightedRule : SteeringPolicyRule
    {
        /// <summary>
        /// An array of caseConditions. A rule may optionally include a sequence of cases defining alternate configurations for how it should 
        /// behave during processing for any given DNS query. When a rule has no sequence of cases, it is always evaluated with the same configuration during 
        /// processing. When a rule has an empty sequence of cases, it is always ignored during processing. When a rule has a non-empty sequence of cases, 
        /// its behavior during processing is configured by the first matching case in the sequence. When a rule has no matching cases the rule is ignored. 
        /// A rule case with no caseCondition always matches. A rule case with a caseCondition matches only when that expression evaluates to true for the given query.
        /// <para>Required: no</para>
        /// <para>Max Items: 50</para>
        /// </summary>
        public new List<SteeringPolicyWeightedRuleCase> Cases { get; set; }

        /// <summary>
        /// Defines a default set of answer conditions and values that are applied to an answer when cases is not defined for the rule or a matching case does not have any 
        /// matching answerConditions in its answerData. defaultAnswerData is not applied if cases is defined and there are no matching cases.
        /// In this scenario, the next rule will be processed.
        /// <para>Required: no</para>
        /// <para>Max Items: 50</para>
        /// </summary>
        public new List<SteeringPolicyWeightedAnswerData> DefaultAnswerData { get; set; }
    }
}
