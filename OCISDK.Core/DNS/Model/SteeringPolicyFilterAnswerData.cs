using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// SteeringPolicyFilterAnswerData Reference
    /// </summary>
    public class SteeringPolicyFilterAnswerData
    {
        /// <summary>
        /// An expression that is used to select a set of answers that match a condition. For example, answers with matching pool properties.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public string AnswerCondition { get; set; }

        /// <summary>
        /// Keeps the answer only if the value is true.
        /// <para>Required: no</para>
        /// </summary>
        public bool? ShouldKeep { get; set; }
    }
}
