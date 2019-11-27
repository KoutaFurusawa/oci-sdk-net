using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// An alarm history entry indicating a description of the entry and the time that the entry occurred. 
    /// If the entry corresponds to a state transition, such as OK to Firing, then the entry also includes a transition timestamp.
    /// </summary>
    public class AlarmHistoryEntry
    {
        /// <summary>
        /// Description for this alarm history entry. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Timestamp for this alarm history entry. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// Timestamp for the transition of the alarm state. For example, the time when the alarm transitioned from OK to Firing. 
        /// Available for state transition entries only. Note: A three-minute lag for this value accounts for any late-arriving metrics.
        /// <para>Required: no</para>
        /// </summary>
        public string TimestampTriggered { get; set; }
    }
}
