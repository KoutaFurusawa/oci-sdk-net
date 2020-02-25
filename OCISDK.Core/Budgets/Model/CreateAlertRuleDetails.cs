using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Budgets.Model
{
    /// <summary>
    /// The create alert rule details. This is a batch-create.
    /// </summary>
    public class CreateAlertRuleDetails
    {
        /// <summary>
        /// The name of the alert rule.
        /// <para>Required: yes</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The description of the alert rule.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of alert. Valid values are ACTUAL 
        /// (the alert will trigger based on actual usage) or FORECAST (the alert will trigger based on predicted usage).
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The threshold for triggering the alert. If thresholdType is PERCENTAGE, the maximum value is 10000.
        /// <para>Required: yes</para>
        /// </summary>
        public string Threshold { get; set; }

        /// <summary>
        /// The type of threshold.
        /// <para>Required: yes</para>
        /// </summary>
        public string ThresholdType { get; set; }

        /// <summary>
        /// Delimited list of email addresses to receive the alert when it triggers. 
        /// Delimiter character can be comma, space, TAB, or semicolon.
        /// <para>Required: yes</para>
        /// </summary>
        public string Recipients { get; set; }

        /// <summary>
        /// Custom message sent when alert is triggered
        /// <para>Required: no</para>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
