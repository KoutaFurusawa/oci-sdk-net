using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Blockstorage
{
    public class GetVolumeBackupPolicyAssignmentRequest
    {
        /// <summary>
        /// The OCID of the volume backup policy assignment.
        /// <para>Required: yes</para>
        /// </summary>
        public string PolicyAssignmentId { get; set; }
    }
}
