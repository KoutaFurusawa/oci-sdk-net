using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Model
{
    /// <summary>
    /// AccessRuleCriteria Details
    /// </summary>
    public class AccessRuleCriteriaDetails
    {
        /// <summary>
        /// The criteria the access rule uses to determine if action should be taken on a request.
        /// <para>Required: yes</para>
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// The criteria value.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 5000</para>
        /// </summary>
        public string Value { get; set; }
    }
}
