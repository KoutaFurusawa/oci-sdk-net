using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The configuration details for suppressing an alarm. For information about alarms, see Alarms Overview.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class SuppressionModel
    {
        /// <summary>
        /// Human-readable reason for suppressing alarm notifications. 
        /// It does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// Oracle recommends including tracking information for the event or associated work, such as a ticket number.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        /// <example>Planned outage due to change IT-1234.</example>
        public string Description { get; set; }

        /// <summary>
        /// The start date and time for the suppression to take place, inclusive. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>2019-02-01T01:02:29.600Z</example>
        public string TimeSuppressFrom { get; set; }

        /// <summary>
        /// The end date and time for the suppression to take place, inclusive. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>2019-02-01T01:02:29.600Z</example>
        public string TimeSuppressUntil { get; set; }
    }
}
