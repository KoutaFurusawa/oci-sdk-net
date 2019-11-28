using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// BucketSummary
    /// </summary>
    public class BucketSummary
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
