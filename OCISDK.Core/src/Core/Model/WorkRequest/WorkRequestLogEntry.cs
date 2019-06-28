using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Model.WorkRequest
{
    public class WorkRequestLogEntry
    {
        /// <summary>
        /// A human-readable log message.
        /// <para>Required: yes</para>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The date and time the log message was written.
        /// <para>Required: yes</para>
        /// </summary>
        public string Timestamp { get; set; }
    }
}
