using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// AbortMultipartUpload request
    /// </summary>
    public class AbortMultipartUploadRequest
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
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// The upload ID for a multipart upload.
        /// <para>Required: yes</para>
        /// </summary>
        public string UploadId { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }
    }
}
