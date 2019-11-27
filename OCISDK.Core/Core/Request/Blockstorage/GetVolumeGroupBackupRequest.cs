using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// GetVolumeGroupBackup Request
    /// </summary>
    public class GetVolumeGroupBackupRequest
    {
        /// <summary>
        /// The Oracle Cloud ID (OCID) that uniquely identifies the volume group backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeGroupBackupId { get; set; }
    }
}
