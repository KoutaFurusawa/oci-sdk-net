using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you are not authorized, talk to an administrator. 
    /// If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class CreateBucketDetails
    {
        /// <summary>
        /// The name of the bucket. Valid characters are uppercase or lowercase letters, numbers, and dashes. 
        /// Bucket names must be unique within an Object Storage namespace. 
        /// Avoid entering confidential information. example: Example: my-new-bucket1
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 256</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The ID of the compartment in which to create the bucket.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Arbitrary string, up to 4KB, of keys and values for user-defined metadata.
        /// <para>Required: no</para>
        /// </summary>
        public object Metadata { get; set; }

        /// <summary>
        /// The type of public access enabled on this bucket. 
        /// A bucket is set to NoPublicAccess by default, which only allows an authenticated caller to access the bucket and its contents. 
        /// When ObjectRead is enabled on the bucket, public access is allowed for the GetObject, HeadObject, and ListObjects operations. 
        /// When ObjectReadWithoutList is enabled on the bucket, public access is allowed for the GetObject and HeadObject operations.
        /// <para>Required: no</para>
        /// </summary>
        public string PublicAccessType { get; set; }

        /// <summary>
        /// The type of storage tier of this bucket. 
        /// A bucket is set to 'Standard' tier by default, which means the bucket will be put in the standard storage tier. 
        /// When 'Archive' tier type is set explicitly, the bucket is put in the Archive Storage tier. 
        /// The 'storageTier' property is immutable after bucket is created.
        /// <para>Required: no</para>
        /// </summary>
        public string StorageTier { get; set; }

        /// <summary>
        /// The OCID of a master encryption key used to call the Key Management service to generate a data encryption key or to encrypt or decrypt a data encryption key.
        /// <para>Required: no</para>
        /// </summary>
        public string KmsKeyId { get; set; }

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