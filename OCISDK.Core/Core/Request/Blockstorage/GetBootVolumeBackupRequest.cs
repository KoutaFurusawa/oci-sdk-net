using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// GetBootVolumeBackup Request
    /// </summary>
    public class GetBootVolumeBackupRequest
    {
        /// <summary>
        /// The OCID of the boot volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string BootVolumeBackupId { get; set; }
    }
}
