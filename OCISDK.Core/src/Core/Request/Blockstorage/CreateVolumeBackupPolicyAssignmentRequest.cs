using OCISDK.Core.src.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Blockstorage
{
    public class CreateVolumeBackupPolicyAssignmentRequest
    {
        /// <summary>
        /// The request body must contain a single CreateVolumeBackupPolicyAssignmentDetails resource.
        /// </summary>
        public CreateVolumeBackupPolicyAssignmentDetails CreateVolumeBackupPolicyAssignmentDetails { get; set; }
    }
}
