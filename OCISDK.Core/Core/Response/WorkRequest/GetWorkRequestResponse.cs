using OCISDK.Core.Core.Model.WorkRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.WorkRequest
{
    /// <summary>
    /// GetWorkRequest Response
    /// </summary>
    public class GetWorkRequestResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain an array of WorkRequestSummary resources.
        /// </summary>
        public WorkRequestModel WorkRequest { get; set; }
    }
}
