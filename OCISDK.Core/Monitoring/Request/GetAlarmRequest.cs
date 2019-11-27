using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Request
{
    /// <summary>
    /// GetAlarm Request
    /// </summary>
    public class GetAlarmRequest
    {
        /// <summary>
        /// Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of an alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AlarmId { get; set; }
    }
}
