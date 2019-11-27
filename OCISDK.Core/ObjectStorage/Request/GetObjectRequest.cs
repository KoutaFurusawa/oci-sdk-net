namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// GetObject Request
    /// </summary>
    public class GetObjectRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The name of the bucket. Avoid entering confidential information. 
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        /// <example>my-new-bucket1</example>
        public string BucketName { get; set; }

        /// <summary>
        /// The name of the object. Avoid entering confidential information. 
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// The entity tag (ETag) to match. For creating and committing a multipart upload to an object, 
        /// this is the entity tag of the target object. For uploading a part, this is the entity tag of the target part.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The entity tag (ETag) to avoid matching. The only valid value is '*', which indicates that the request should 
        /// fail if the object already exists. For creating and committing a multipart upload, this is the entity tag of the 
        /// target object. For uploading a part, this is the entity tag of the target part.
        /// <para>Required: no</para>
        /// </summary>
        public string IfNoneMatch { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Optional byte range to fetch, as described in RFC 7233, section 2.1. Note that only a single range of bytes is supported.
        /// <para>Required: no</para>
        /// </summary>
        public string Range { get; set; }
    }
}
