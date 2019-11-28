using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// A point-in-time copy of a volume group that can then be used to create a new volume group or restore a volume group. For more information, see Volume Groups.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class VolumeGroupBackup
    {
        /// <summary>
        /// The OCID of the compartment that contains the volume group backup.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name for the volume group backup. 
        /// Does not have to be unique and it's changeable. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the volume group backup.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The current state of a volume group backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The aggregate size of the volume group backup, in MBs.
        /// <para>Required: no</para>
        /// </summary>
        public int? SizeInMBs { get; set; }

        /// <summary>
        /// The aggregate size of the volume group backup, in GBs.
        /// <para>Required: no</para>
        /// </summary>
        public int? SizeInGBs { get; set; }

        /// <summary>
        /// The date and time the volume group backup was created.
        /// This is the time the actual point-in-time image of the volume group data was taken. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The date and time the request to create the volume group backup was received. Format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeRequestReceived { get; set; }

        /// <summary>
        /// The type of backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The aggregate size used by the volume group backup, in MBs. 
        /// It is typically smaller than sizeInMBs, depending on the space consumed on the volume group and whether the volume backup is full or incremental.
        /// <para>Required: no</para>
        /// </summary>
        public int? UniqueSizeInMbs { get; set; }

        /// <summary>
        /// The aggregate size used by the volume group backup, in GBs. 
        /// It is typically smaller than sizeInGBs, depending on the space consumed on the volume group and whether the volume backup is full or incremental.
        /// <para>Required: no</para>
        /// </summary>
        public int? UniqueSizeInGbs { get; set; }

        /// <summary>
        /// OCIDs for the volume backups in this volume group backup.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> VolumeBackupIds { get; set; }

        /// <summary>
        /// The OCID of the source volume group.
        /// <para>Required: no</para>
        /// </summary>
        public string VolumeGroupId { get; set; }
    }
}
