using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Blockstorage
{
    public class GetVolumeBackupRequest
    {
        /// <summary>
        /// The OCID of the volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeBackupId { get; set; }
    }
}
