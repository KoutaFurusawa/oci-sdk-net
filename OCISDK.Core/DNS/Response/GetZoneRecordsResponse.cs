using OCISDK.Core.DNS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Response
{
    /// <summary>
    /// GetZoneRecords Response
    /// </summary>
    public class GetZoneRecordsResponse
    {
        /// <summary>
        /// For list pagination. When this header appears in the response, additional pages of results remain.
        /// For important details about how pagination works, see List Pagination.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The total number of items that match the query.
        /// </summary>
        public string OpcTotalItems { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The current version of the zone, ending with a representation-specific suffix.
        /// This value may be used in If-Match and If-None-Match headers for later requests of the same resource.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The response body will contain a single RecordCollection resource.
        /// </summary>
        public RecordCollection RecordCollection { get; set; }
    }
}
