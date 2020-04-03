using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// UploadPart request
    /// </summary>
    public class UploadPartRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The name of the bucket. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// The name of the object. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// The upload ID for a multipart upload.
        /// <para>Required: yes</para>
        /// </summary>
        public string UploadId { get; set; }

        /// <summary>
        /// The part number that identifies the object part currently being uploaded.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 10000</para>
        /// </summary>
        public string UploadPartNum { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The entity tag (ETag) to match. For creating and committing a multipart upload to an object, this is the 
        /// entity tag of the target object. For uploading a part, this is the entity tag of the target part.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The entity tag (ETag) to avoid matching. The only valid value is '*', which indicates that the request should fail if the 
        /// object already exists. For creating and committing a multipart upload, this is the entity tag of the target object. For 
        /// uploading a part, this is the entity tag of the target part.
        /// <para>Required: no</para>
        /// </summary>
        public string IfNoneMatch { get; set; }

        /// <summary>
        /// 100-continue
        /// <para>Required: no</para>
        /// <para>Default: 100-continue</para>
        /// </summary>
        public string Expect { get; set; }

        /// <summary>
        /// The content length of the body.
        /// <para>Required: yes</para>
        /// </summary>
        public long ContentLength { get; set; }

        /// <summary>
        /// The optional base-64 header that defines the encoded MD5 hash of the body. If the optional Content-MD5 header is present, Object Storage 
        /// performs an integrity check on the body of the HTTP request by computing the MD5 hash for the body and comparing it to the MD5 hash supplied in the 
        /// header. If the two hashes do not match, the object is rejected and an HTTP-400 Unmatched Content MD5 error is returned with the message:
        /// 
        /// "The computed MD5 of the request body (ACTUAL_MD5) does not match the Content-MD5 header (HEADER_MD5)"
        /// <para>Required: no</para>
        /// </summary>
        public string ContentMD5 { get; set; }

        /// <summary>
        /// The part being uploaded to the Object Storage service.
        /// <para>Required: yes</para>
        /// </summary>
        public Stream UploadPartBody { get; set; }
    }
}
