using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Response
{
    /// <summary>
    /// DeleteTable response
    /// </summary>
    public class DeleteTableResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the asynchronous request. You can use this to query status of the asynchronous operation.
        /// </summary>
        public string OpcWorkRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}
