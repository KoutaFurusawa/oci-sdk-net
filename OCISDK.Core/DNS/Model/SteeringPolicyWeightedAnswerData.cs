using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// SteeringPolicyWeightedAnswerData Reference
    /// </summary>
    public class SteeringPolicyWeightedAnswerData
    {
        /// <summary>
        /// An expression that is used to select a set of answers that match a condition. For example, answers with matching pool properties.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public string AnswerCondition { get; set; }

        /// <summary>
        /// The weight assigned to the set of selected answers. Answers with a higher weight will be served more frequently.
        /// Answers can be given a value between 0 and 255.
        /// <para>Required: yes</para>
        /// <para>Minimum: 0, Maximum: 255</para>
        /// </summary>
        public int Value { get; set; }
    }
}
