using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// GetVolumeBackup Request
    /// </summary>
    public class GetVolumeBackupRequest
    {
        /// <summary>
        /// The OCID of the volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeBackupId { get; set; }
    }
}
