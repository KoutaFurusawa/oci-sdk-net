using OCISDK.Core.NoSQL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Response
{
    /// <summary>
    /// ListTableUsage response
    /// </summary>
    public class ListTableUsageResponse
    {
        /// <summary>
        /// For pagination of a list of items. When paging through a list, if this header appears in the response, 
        /// then a partial list might have been returned. Include this value as the page parameter for the subsequent 
        /// GET request to get the next batch of items.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single TableUsageCollection resource.
        /// </summary>
        public TableUsageCollection TableUsageCollection { get; set; }
    }
}
