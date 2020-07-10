using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.Usage.Model;

namespace OCISDK.Core.Usage.Response
{
    /// <summary>
    /// RequestSummarizedUsages response
    /// </summary>
    public class RequestSummarizedUsagesResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a 
        /// particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For list pagination. When this header appears in the response, additional pages of 
        /// results remain. For important details about how pagination works, see List Pagination.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain a single UsageAggregation resource.
        /// </summary>
        public UsageAggregation UsageAggregation { get; set; }
    }
}
