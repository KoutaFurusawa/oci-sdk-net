using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// WorkRequestError Reference
    /// </summary>
    public class WorkRequestError
    {
        /// <summary>
        /// A machine-usable code for the error that occurred. For the list of error codes, see API Errors.
        /// <para>Required: no</para>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A human-readable description of the issue that produced the error.
        /// <para>Required: no</para>
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The time the error occurred.
        /// <para>Required: no</para>
        /// </summary>
        public string Timestamp { get; set; }
    }
}
