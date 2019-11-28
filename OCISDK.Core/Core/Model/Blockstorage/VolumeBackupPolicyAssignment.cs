using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// Specifies that a particular volume backup policy is assigned to an asset such as a volume.
    /// </summary>
    public class VolumeBackupPolicyAssignment
    {
        /// <summary>
        /// The OCID of the asset (e.g. a volume) to which the policy has been assigned.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AssetId { get; set; }

        /// <summary>
        /// The OCID of the volume backup policy assignment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the volume backup policy that has been assigned to an asset.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string PolicyId { get; set; }

        /// <summary>
        /// The date and time the volume backup policy assignment was created. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }
    }
}
