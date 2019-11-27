using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The configuration details for moving an alarm.
    /// </summary>
    public class ChangeAlarmCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment to move the alarm to.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}
