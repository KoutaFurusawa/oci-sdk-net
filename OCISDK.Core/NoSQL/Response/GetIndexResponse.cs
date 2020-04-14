using OCISDK.Core.NoSQL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Response
{
    /// <summary>
    /// GetIndex response
    /// </summary>
    public class GetIndexResponse
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
        /// The response body will contain a single Index resource.
        /// </summary>
        public IndexDetails Index { get; set; }
    }
}
