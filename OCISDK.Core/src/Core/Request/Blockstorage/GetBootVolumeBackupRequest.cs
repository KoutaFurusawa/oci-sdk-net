using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Blockstorage
{
    public class GetBootVolumeBackupRequest
    {
        /// <summary>
        /// The OCID of the boot volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string BootVolumeBackupId { get; set; }
    }
}
