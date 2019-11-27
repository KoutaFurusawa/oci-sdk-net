using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Response
{
    /// <summary>
    /// DeleteWaasPolicy response
    /// </summary>
    public class DeleteWaasPolicyResponse
    {
        /// <summary>
        /// A unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the work request.
        /// </summary>
        public string OpcWorkRequestId { get; set; }
    }
}
