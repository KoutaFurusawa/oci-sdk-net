using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// GetWorkRequest response
    /// </summary>
    public class GetWorkRequestResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// A decimal number representing the number of seconds the client should wait before polling this endpoint again.
        /// </summary>
        public string RetryAfter { get; set; }

        /// <summary>
        /// The response body will contain a single WorkRequest resource.
        /// </summary>
        public WorkRequestDetails WorkRequest { get; set; }
    }
}
