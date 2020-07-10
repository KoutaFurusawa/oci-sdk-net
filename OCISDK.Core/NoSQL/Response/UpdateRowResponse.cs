using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.NoSQL.Model;

namespace OCISDK.Core.NoSQL.Response
{
    /// <summary>
    /// UpdateRow response
    /// </summary>
    public class UpdateRowResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single UpdateRowResult resource.
        /// </summary>
        public UpdateRowResult UpdateRowResult { get; set; }
    }
}
