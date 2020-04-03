using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// WorkRequestLogEntry Reference
    /// </summary>
    public class WorkRequestLogEntry
    {
        /// <summary>
        /// Human-readable log message.
        /// <para>Required: no</para>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The date and time the log message was written, as described in RFC 3339.
        /// <para>Required: no</para>
        /// </summary>
        public string Timestamp { get; set; }
    }
}
