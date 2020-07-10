using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.NoSQL.Model;

namespace OCISDK.Core.NoSQL.Response
{
    /// <summary>
    /// PrepareStatement response
    /// </summary>
    public class PrepareStatementResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single PreparedStatement resource.
        /// </summary>
        public PreparedStatement PreparedStatement { get; set; }
    }
}
