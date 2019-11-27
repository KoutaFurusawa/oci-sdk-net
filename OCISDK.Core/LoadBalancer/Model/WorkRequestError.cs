using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// An object returned in the event of a work request error.
    /// </summary>
    public class WorkRequestError
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// A human-readable error string.
        /// <para>Required: yes</para>
        /// </summary>
        public string Message { get; set; }
    }
}
