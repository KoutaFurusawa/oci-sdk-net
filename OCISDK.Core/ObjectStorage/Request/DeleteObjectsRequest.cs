using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// DeleteObjects request
    /// </summary>
    public class DeleteObjectsRequest
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
        /// The name list of the object. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public List<TargetDelete> Objects { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Element to enable quiet mode for the request. When you add this element, you must set its value to true.
        /// <para>Required: no</para>
        /// </summary>
        public bool? Quiet { get; set; }
    }

    /// <summary>
    /// delete target object model.
    /// </summary>
    public class TargetDelete
    {
        /// <summary>
        /// The entity tag (ETag) to match. For creating and committing a multipart upload to an object, this is the 
        /// entity tag of the target object. For uploading a part, this is the entity tag of the target part.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The name of the object. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string ObjectName { get; set; }

    }
}
