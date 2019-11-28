using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// AlarmStatusSummary
    /// </summary>
    public class AlarmStatusSummary
    {
        /// <summary>
        /// The OCID of the alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The configured name of the alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        /// <example>High CPU Utilization</example>
        public string DisplayName { get; set; }

        /// <summary>
        /// The configured severity of the alarm.
        /// <para>Required: yes</para>
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Timestamp for the transition of the alarm state. 
        /// For example, the time when the alarm transitioned from OK to Firing.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimestampTriggered { get; set; }

        /// <summary>
        /// The status of this alarm.
        /// <para>Required: yes</para>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The configuration details for suppressing an alarm.
        /// <para>Required: no</para>
        /// </summary>
        public SuppressionModel Suppression { get; set; }
    }
}
