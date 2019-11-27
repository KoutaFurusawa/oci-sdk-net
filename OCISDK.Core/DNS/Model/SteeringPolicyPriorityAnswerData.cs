using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// SteeringPolicyPriorityAnswerData Reference
    /// </summary>
    public class SteeringPolicyPriorityAnswerData
    {
        /// <summary>
        /// An expression that is used to select a set of answers that match a condition. For example, answers with matching pool properties.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public string AnswerCondition { get; set; }

        /// <summary>
        /// The rank assigned to the set of answers that match the expression in answerCondition. 
        /// Answers with the lowest values move to the beginning of the list without changing the relative order of those with the same value. 
        /// Answers can be given a value between 0 and 255.
        /// <para>Required: yes</para>
        /// <para>Minimum: 0, Maximum: 255</para>
        /// </summary>
        public int Value { get; set; }
    }
}
