using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// ListMultipartUploads response
    /// </summary>
    public class ListMultipartUploadsResponse
    {
        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Paginating a list of multipart upload parts. In the GET request, set the limit to the number of multipart upload parts that you want 
        /// returned in the response. If the opc-next-page header appears in the response, then this is a partial list and there are additional 
        /// multipart upload parts to get. Include the header's value as the page parameter in the subsequent GET request to get the next batch of 
        /// multipart upload parts. Repeat this process to retrieve the entire list of multipart upload parts.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain an array of MultipartUpload resources.
        /// </summary>
        public List<MultipartUploadDetails> Items;
    }
}
