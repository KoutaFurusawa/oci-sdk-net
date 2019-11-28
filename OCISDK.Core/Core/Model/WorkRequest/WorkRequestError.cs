using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.WorkRequest
{
    /// <summary>
    /// WorkRequestError
    /// </summary>
    public class WorkRequestError
    {
        /// <summary>
        /// A machine-usable code for the error that occured.
        /// <para>Required: yes</para>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A human-readable error string.
        /// <para>Required: yes</para>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The date and time the error occurred.
        /// <para>Required: yes</para>
        /// </summary>
        public string Timestamp { get; set; }
    }
}
