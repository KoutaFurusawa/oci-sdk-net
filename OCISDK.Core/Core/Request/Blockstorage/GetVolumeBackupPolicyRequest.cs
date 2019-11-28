using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// GetVolumeBackupPolicy Request
    /// </summary>
    public class GetVolumeBackupPolicyRequest
    {
        /// <summary>
        /// The OCID of the volume backup policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string PolicyId { get; set; }
    }
}
