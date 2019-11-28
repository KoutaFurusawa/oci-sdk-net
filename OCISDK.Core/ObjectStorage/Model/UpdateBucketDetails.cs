using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// To use any of the API operations, you must be authorized in an IAM policy. 
    /// If you are not authorized, talk to an administrator. If you are an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// </summary>
    public class UpdateBucketDetails
    {
        /// <summary>
        /// The Object Storage namespace in which the bucket lives.
        /// <para>Required: no</para>
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// The compartment ID in which the bucket is authorized.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the bucket. Avoid entering confidential information. Example: my-new-bucket1
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Arbitrary string keys and values for user-defined metadata.
        /// <para>Required: no</para>
        /// </summary>
        public object Metadata { get; set; }

        /// <summary>
        /// The type of public access enabled on this bucket. 
        /// A bucket is set to NoPublicAccess by default, which only allows an authenticated caller 
        /// to access the bucket and its contents. When ObjectRead is enabled on the bucket, 
        /// public access is allowed for the GetObject, HeadObject, and ListObjects operations. 
        /// When ObjectReadWithoutList is enabled on the bucket, 
        /// public access is allowed for the GetObject and HeadObject operations.
        /// <para>Required: no</para>
        /// </summary>
        public string PublicAccessType { get; set; }

        /// <summary>
        /// The OCID of a KMS key id used to call KMS to generate data key or decrypt the encrypted data key.
        /// <para>Required: no</para>
        /// </summary>
        public string KmsKeyId { get; set; }

        /// <summary>
        /// Free-form tags for this resource. 
        /// Each tag is a simple key-value pair with no predefined name, type, or namespace. For more information, see Resource Tags. 
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. 
        /// Each key is predefined and scoped to a namespace. For more information, see Resource Tags. 
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
