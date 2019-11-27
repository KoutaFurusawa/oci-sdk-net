using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// GetBootVolumeKmsKey Request
    /// </summary>
    public class GetBootVolumeKmsKeyRequest
    {
        /// <summary>
        /// The OCID of the boot volume.
        /// <para>Required: yes</para>
        /// </summary>
        public string BootVolumeId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, 
        /// set the if-match parameter to the value of the etag from a previous GET or 
        /// POST response for that resource. The resource will be updated or deleted 
        /// only if the etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}
