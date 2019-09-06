using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Blockstorage
{
    public class GetVolumeGroupRequest
    {
        /// <summary>
        /// The Oracle Cloud ID (OCID) that uniquely identifies the volume group.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeGroupId { get; set; }
    }
}
