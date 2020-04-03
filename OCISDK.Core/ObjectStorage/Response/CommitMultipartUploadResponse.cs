using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// CommitMultipartUpload response
    /// </summary>
    public class CommitMultipartUploadResponse
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
        /// Base-64 representation of the multipart object hash. The multipart object hash is calculated by taking the MD5 hashes of the parts passed to this 
        /// call, concatenating the binary representation of those hashes in order of their part numbers, and then calculating the MD5 hash of the concatenated values. 
        /// The multipart object hash is followed by a hyphen and the total number of parts (for example, '-6').
        /// </summary>
        public string OpcMultipartMd5 { get; set; }

        /// <summary>
        /// The entity tag (ETag) for the object.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The time the object was last modified, as described in RFC 2616.
        /// </summary>
        public string LastModified { get; set; }
    }
}
