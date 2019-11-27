using System;
using System.Collections.Generic;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// GetObject Response
    /// </summary>
    public class GetObjectResponse
    {
        /// <summary>
        /// FileURL
        /// </summary>
        public string FileURL { get; set; }

        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The entity tag (ETag) for the object.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The user-defined metadata for the object.
        /// </summary>
        public IDictionary<string, string> OpcMeta;

        /// <summary>
        /// The object size in bytes.
        /// </summary>
        public long? ContentLength;

        /// <summary>
        /// Content-Range header for range requests, per [RFC 7233](https://tools.ietf.org/rfc/rfc7233), section 4.2.
        /// </summary>
        public Object ContentRange;

        /// <summary>
        /// Content-MD5 header, as described in [RFC 2616](https://tools.ietf.org/rfc/rfc2616), section 14.15.
        /// Unavailable for objects uploaded using multipart upload.
        /// </summary>
        public string ContentMd5;

        /// <summary>
        /// Only applicable to objects uploaded using multipart upload. 
        /// Base-64 representation of the multipart object hash. The multipart object hash is calculated by 
        /// taking the MD5 hashes of the parts, concatenating the binary representation of those hashes in order of 
        /// their part numbers, and then calculating the MD5 hash of the concatenated values.
        /// </summary>
        public string OpcMultipartMd5;

        /// <summary>
        /// Content-Type header, as described in [RFC 2616](https://tools.ietf.org/rfc/rfc2616), section 14.17.
        /// </summary>
        public string ContentType;

        /// <summary>
        /// Content-Language header, as described in [RFC 2616](https://tools.ietf.org/rfc/rfc2616), section 14.12.
        /// </summary>
        public string ContentLanguage;

        /// <summary>
        /// Content-Encoding header, as described in [RFC 2616](https://tools.ietf.org/rfc/rfc2616), section 14.11.
        /// </summary>
        public string ContentEncoding;

        /// <summary>
        /// The object modification time, as described in [RFC 2616](https://tools.ietf.org/rfc/rfc2616), section 14.29.
        /// </summary>
        public string LastModified;

        /// <summary>
        /// The current state of the object.
        /// </summary>
        public string ArchivalState;

        /// <summary>
        /// The returned java.io.InputStream instance, or null if {@link #isNotModified()} is true.
        /// </summary>
        public string TimeOfArchival;
        
    }
}
