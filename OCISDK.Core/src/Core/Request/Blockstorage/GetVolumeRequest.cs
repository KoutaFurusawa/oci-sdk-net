using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Blockstorage
{
    public class GetVolumeRequest
    {
        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeId { get; set; }
    }
}
