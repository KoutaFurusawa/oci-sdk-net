using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// GetVolume Request
    /// </summary>
    public class GetVolumeRequest
    {
        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeId { get; set; }
    }
}
