namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you are not authorized, talk to an administrator. If you are an administrator 
    /// who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class ObjectSummary
    {
        /// <summary>
        /// The name of the object. Avoid entering confidential information. 
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>test/object1.log</example>
        public string Name { get; set; }

        /// <summary>
        /// Size of the object in bytes.
        /// <para>Required: no</para>
        /// </summary>
        public long? Size { get; set; }

        /// <summary>
        /// Base64-encoded MD5 hash of the object data.
        /// <para>Required: no</para>
        /// </summary>
        public string Md5 { get; set; }

        /// <summary>
        /// The date and time the object was created, as described in RFC 2616, section 14.29.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }
    }
}
