using OCISDK.Core.Waas.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Response
{
    /// <summary>
    /// GetWaasPolicy response
    /// </summary>
    public class GetWaasPolicyResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The response body will contain a single WaasPolicy resource.
        /// </summary>
        public WaasPolicyDetails WaasPolicy { get; set; }
    }
}
