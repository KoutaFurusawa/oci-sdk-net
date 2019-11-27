using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Response
{
    /// <summary>
    /// ChangeDbSystemCompartment Response
    /// </summary>
    public class ChangeDbSystemCompartmentResponse
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
        /// Unique Oracle-assigned identifier of the work request.
        /// </summary>
        public string OpcWorkRequestId { get; set; }
    }
}
