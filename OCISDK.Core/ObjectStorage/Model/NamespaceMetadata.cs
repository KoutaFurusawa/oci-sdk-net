namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// A bucket is a container for storing objects in a compartment within a namespace.
    /// A bucket is associated with a single compartment. The compartment has policies that indicate what 
    /// actions a user can perform on a bucket and all the objects in the bucket. 
    /// For more information, see Managing Buckets.
    /// </summary>s
    public class NamespaceMetadata
    {
        /// <summary>
        /// The Object Storage namespace to which the metadata belongs.
        /// <para>Required: yes</para>
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// If the field is set, specifies the default compartment assignment for the Amazon S3 Compatibility API.
        /// <para>Required: yes</para>
        /// </summary>
        public string DefaultS3CompartmentId { get; set; }

        /// <summary>
        /// If the field is set, specifies the default compartment assignment for the Swift API.
        /// <para>Required: yes</para>
        /// </summary>
        public string DefaultSwiftCompartmentId { get; set; }
    }
}
