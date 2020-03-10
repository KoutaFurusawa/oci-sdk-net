using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// CancelWorkRequest request
    /// </summary>
    public class CancelWorkRequestRequest
    {
        /// <summary>
        /// The ID of the asynchronous request.
        /// <para>Required: yes</para>
        /// </summary>
        public string WorkRequestId { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }
    }
}
