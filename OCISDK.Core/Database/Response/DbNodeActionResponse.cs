using OCISDK.Core.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Response
{
    /// <summary>
    /// DbNodeAction response
    /// </summary>
    public class DbNodeActionResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single DbNode resource.
        /// </summary>
        public DbNodeDetails DbNode { get; set; }
    }
}
