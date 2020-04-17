using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// The details to create a retention rule.
    /// </summary>
    public class CreateRetentionRuleDetails
    {
        /// <summary>
        /// A user-specified name for the retention rule. Names can be helpful in identifying retention rules.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public Duration Duration { get; set; }

        /// <summary>
        /// The date and time as per RFC 3339 after which this rule is locked and can only be deleted by deleting the bucket. Once a rule is locked, 
        /// only increases in the duration are allowed and no other properties can be changed. This property cannot be updated for rules that are in a 
        /// locked state. Specifying it when a duration is not specified is considered an error.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeRuleLocked { get; set; }
    }
}
