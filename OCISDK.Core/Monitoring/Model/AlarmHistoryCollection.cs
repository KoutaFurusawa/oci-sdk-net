using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The configuration details for retrieving alarm history.
    /// </summary>
    public class AlarmHistoryCollection
    {
        /// <summary>
        /// The OCID of the alarm for which to retrieve history.
        /// <para>Required: yes</para>
        /// </summary>
        public string AlarmId { get; set; }

        /// <summary>
        /// Whether the alarm is enabled.
        /// <para>Required: yes</para>
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The set of history entries retrieved for the alarm.
        /// <para>Required: yes</para>
        /// </summary>
        public List<AlarmHistoryEntry> Entries { get; set; }
    }
}
