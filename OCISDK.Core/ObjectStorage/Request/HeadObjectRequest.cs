using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// HeadObject request
    /// </summary>
    public class HeadObjectRequest
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
        /// <para>Min Length: 0, Max Length: 1</para>
        /// </summary>
        public string IfNoneMatch { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// </summary>
        public string OpcClientRequestId { get; set; }
    }
}
