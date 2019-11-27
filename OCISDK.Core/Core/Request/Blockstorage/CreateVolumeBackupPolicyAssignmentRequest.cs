using OCISDK.Core.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// CreateVolumeBackupPolicyAssignment Request
    /// </summary>
    public class CreateVolumeBackupPolicyAssignmentRequest
    {
        /// <summary>
        /// The request body must contain a single CreateVolumeBackupPolicyAssignmentDetails resource.
        /// </summary>
        public CreateVolumeBackupPolicyAssignmentDetails CreateVolumeBackupPolicyAssignmentDetails { get; set; }
    }
}
