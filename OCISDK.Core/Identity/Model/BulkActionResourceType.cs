using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// BulkActionResourceType Reference
    /// </summary>
    public class BulkActionResourceType
    {
        /// <summary>
        /// List of metadata keys required to identify a specific resource. Some 
        /// resource-types require information besides an OCID to identify a 
        /// specific resource. For example, the resource-type buckets requires 
        /// metadataKeys ["namespaceName", "bucketName"] to identify a 
        /// specific bucket. The required information to identify a resource is in 
        /// the API documentation for the resource-type. For example, the required 
        /// information for buckets is found in the DeleteBucket API.
        /// <para>Type: [string (length: 1–255), ...]</para>
        /// <para>Required: no</para>
        /// </summary>
        public List<string> MetadataKeys { get; set; }

        /// <summary>
        /// The unique name of the resource-type.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Name { get; set; }
    }
}
