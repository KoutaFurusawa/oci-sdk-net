using OCISDK.Core.ObjectStorage.Model;
using System.Collections.Generic;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// ListBuckets Response
    /// </summary>
    public class ListBucketsResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Paginating a list of buckets. In the GET request, set the limit to the number of buckets 
        /// items that you want returned in the response. If the opc-next-page header appears in the response, 
        /// then this is a partial list and there are additional buckets to get. Include the header's value as 
        /// the page parameter in the subsequent GET request to get the next batch of buckets. Repeat this process 
        /// to retrieve the entire list of buckets. By default, the page limit is set to 25 buckets per page, 
        /// but you can specify a value from 1 to 1000.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain an array of BucketSummary resources.
        /// </summary>
        public List<BucketSummary> Items { get; set; }
    }
}
