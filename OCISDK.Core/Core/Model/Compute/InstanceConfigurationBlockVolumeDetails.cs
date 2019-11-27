using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Create new block volumes or attach to an existing volume. Specify either createDetails or volumeId.
    /// </summary>
    public class InstanceConfigurationBlockVolumeDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public InstanceConfigurationAttachVolumeDetails AttachDetails { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public InstanceConfigurationCreateVolumeDetails CreateDetails { get; set; }

        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: no</para>
        /// </summary>
        public string VolumeId { get; set; }
    }
}
