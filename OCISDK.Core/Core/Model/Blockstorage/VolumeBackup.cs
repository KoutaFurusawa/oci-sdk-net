using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// A point-in-time copy of a volume that can then be used to create a new block volume or recover a block volume. 
    /// For more information, see Overview of Cloud Volume Storage.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class VolumeBackup
    {
        /// <summary>
        /// The OCID of the compartment that contains the volume backup.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name for the volume backup. Does not have to be unique and it's changeable. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The date and time the volume backup will expire and be automatically deleted. Format defined by RFC3339. 
        /// This parameter will always be present for backups that were created automatically by a scheduled-backup policy. 
        /// For manually created backups, it will be absent, signifying that there is no expiration time and the backup will last forever until manually deleted.
        /// <para>Required: no</para>
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// The OCID of the volume backup.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the KMS key which is the master encryption key for the volume backup. 
        /// For more information about the Key Management service and encryption keys, see Overview of Key Management and Using Keys.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }
        
        /// <summary>
        /// The current state of a volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The size of the volume, in GBs.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 16384</para>
        /// </summary>
        public int? SizeInGBs { get; set; }

        /// <summary>
        /// The size of the volume in MBs. The value must be a multiple of 1024. This field is deprecated. Please use sizeInGBs.
        /// <para>Required: no</para>
        /// <para>Minimum: 1024, Maximum: 16777216</para>
        /// </summary>
        [Obsolete("This field is deprecated. Please use sizeInGBs.")]
        public int? SizeInMBs { get; set; }

        /// <summary>
        /// Specifies whether the backup was created manually, or via scheduled backup policy.
        /// <para>Required: no</para>
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// The OCID of the source volume backup.
        /// <para>Required: no</para>
        /// </summary>
        public string SourceVolumeBackupId { get; set; }

        /// <summary>
        /// The date and time the request to create the volume backup was received. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The date and time the request to create the volume backup was received. Format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeRequestReceived { get; set; }

        /// <summary>
        /// The type of a volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The size used by the backup, in GBs. It is typically smaller than sizeInGBs, 
        /// depending on the space consumed on the volume and whether the backup is full or incremental.
        /// <para>Required: no</para>
        /// <para>Minimum: 0, Maximum: 16384</para>
        /// </summary>
        public int? UniqueSizeInGBs { get; set; }

        /// <summary>
        /// The size used by the backup, in MBs. It is typically smaller than sizeInMBs, 
        /// depending on the space consumed on the volume and whether the backup is full or incremental. 
        /// This field is deprecated. Please use uniqueSizeInGBs.
        /// <para>Required: no</para>
        /// </summary>
        [Obsolete("This field is deprecated. Please use uniqueSizeInGBs.")]
        public int? UniqueSizeInMbs { get; set; }

        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
