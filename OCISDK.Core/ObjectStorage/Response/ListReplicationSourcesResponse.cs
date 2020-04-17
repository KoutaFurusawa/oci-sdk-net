using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.ObjectStorage.Model;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// ListReplicationSources response
    /// </summary>
    public class ListReplicationSourcesResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Paginating a list of replication policies. In the GET request, set the limit to the number of buckets items that you want returned in the response. 
        /// If the opc-next-page header appears in the response, then this is a partial list and there are additional policies to get. Include the header's value as the 
        /// page parameter in the subsequent GET request to get the next batch of policies. Repeat this process to retrieve the entire list of policies.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain an array of ReplicationPolicySummary resources.
        /// </summary>
        public List<ReplicationSource> Items { get; set; }
    }
}
