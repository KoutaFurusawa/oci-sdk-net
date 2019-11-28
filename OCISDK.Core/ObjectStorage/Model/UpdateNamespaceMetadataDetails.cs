using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Model
{
    /// <summary>
    /// UpdateNamespaceMetadata Details
    /// </summary>
    public class UpdateNamespaceMetadataDetails
    {
        /// <summary>
        /// The updated compartment id for use by an S3 client, if this field is set.
        /// <para>Required: no</para>
        /// </summary>
        public string DefaultS3CompartmentId { get; set; }

        /// <summary>
        /// The updated compartment id for use by a Swift client, if this field is set.
        /// <para>Required: no</para>
        /// </summary>
        public string DefaultSwiftCompartmentId { get; set; }
    }
}
