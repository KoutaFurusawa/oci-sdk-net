using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// CreateBucket Response
    /// </summary>
    public class CreateBucketResponse
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
        /// The entity tag (ETag) for the bucket that was created.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The full path to the bucket that was created.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The response body will contain a single Bucket resource.
        /// </summary>
        public Bucket Bucket { get; set; }
    }
}
