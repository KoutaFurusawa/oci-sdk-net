using System;
using System.Collections.Generic;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// A bucket is a container for storing objects in a compartment within a namespace.
    /// A bucket is associated with a single compartment. The compartment has policies that indicate what 
    /// actions a user can perform on a bucket and all the objects in the bucket. 
    /// For more information, see Managing Buckets.
    /// </summary>
    public class Bucket
    {
        /// <summary>
        /// OCID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The Object Storage namespace in which the bucket lives.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// The name of the bucket. Avoid entering confidential information. Example: my-new-bucket1
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The compartment ID in which the bucket is authorized.
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Arbitrary string keys and values for user-defined metadata.
        /// </summary>
        public object Metadata { get; set; }

        /// <summary>
        /// The OCID of the user who created the bucket.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// The date and time the bucket was created, as described in RFC 2616, section 14.29.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The entity tag (ETag) for the bucket.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// The type of public access enabled on this bucket. 
        /// A bucket is set to NoPublicAccess by default, which only allows an authenticated caller 
        /// to access the bucket and its contents. When ObjectRead is enabled on the bucket, 
        /// public access is allowed for the GetObject, HeadObject, and ListObjects operations. 
        /// When ObjectReadWithoutList is enabled on the bucket, 
        /// public access is allowed for the GetObject and HeadObject operations.
        /// </summary>
        public string PublicAccessType { get; set; }

        /// <summary>
        /// The storage tier type assigned to the bucket. A bucket is set to 'Standard' tier by default, 
        /// which means objects uploaded or copied to the bucket will be in the standard storage tier. 
        /// When the 'Archive' tier type is set explicitly for a bucket, objects uploaded or copied to 
        /// the bucket will be stored in archive storage. 
        /// The 'storageTier' property is immutable after bucket is created.
        /// </summary>
        public string StorageTier { get; set; }

        /// <summary>
        /// The OCID of a KMS key id used to call KMS to generate data key or decrypt the encrypted data key.
        /// </summary>
        public string KmsKeyId { get; set; }

        /// <summary>
        /// The entity tag (ETag) for the live object lifecycle policy on the bucket.
        /// </summary>
        public string ObjectLifecyclePolicyEtag { get; set; }

        /// <summary>
        /// The approximate number of objects in the bucket. 
        /// Count statistics are reported periodically. 
        /// You will see a lag between what is displayed and the actual object count.
        /// </summary>
        public int? ApproximateCount { get; set; }

        /// <summary>
        /// The approximate total size in bytes of all objects in the bucket. 
        /// Size statistics are reported periodically. 
        /// You will see a lag between what is displayed and the actual size of the bucket.
        /// </summary>
        public int? ApproximateSize { get; set; }

        /// <summary>
        /// Free-form tags for this resource. 
        /// Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
