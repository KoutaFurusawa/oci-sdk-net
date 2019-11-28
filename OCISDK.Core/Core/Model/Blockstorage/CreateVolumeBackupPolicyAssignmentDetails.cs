using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// CreateVolumeBackupPolicyAssignmentDetails
    /// </summary>
    public class CreateVolumeBackupPolicyAssignmentDetails
    {
        /// <summary>
        /// The OCID of the asset (e.g. a volume) to which to assign the policy.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AssetId { get; set; }

        /// <summary>
        /// The OCID of the volume backup policy to assign to an asset.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string PolicyId { get; set; }
    }
}
