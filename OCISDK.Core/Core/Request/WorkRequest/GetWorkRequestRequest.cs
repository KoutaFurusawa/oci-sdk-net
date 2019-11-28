using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.WorkRequest
{
    /// <summary>
    /// GetWorkRequest Request
    /// </summary>
    public class GetWorkRequestRequest
    {
        /// <summary>
        /// The OCID of the work request.
        /// <para>Required: yes</para>
        /// </summary>
        public string WorkRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}
