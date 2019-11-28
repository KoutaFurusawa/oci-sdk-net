using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// A point-in-time copy of a boot volume that can then be used to create a new boot volume or recover a boot volume.
    /// For more information, see Overview of Boot Volume Backups To use any of the API operations, you must be authorized in an IAM policy.
    /// If you're not authorized, talk to an administrator.
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class BootVolumeBackup
    {
        /// <summary>
        /// The OCID of the boot volume.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string BootVolumeId { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the boot volume backup.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name for the boot volume backup. Does not have to be unique and it's changeable. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The date and time the volume backup will expire and be automatically deleted. 
        /// Format defined by RFC3339. This parameter will always be present for backups that were created automatically by a scheduled-backup policy. 
        /// For manually created backups, it will be absent, signifying that there is no expiration time and the backup will last forever until manually deleted.
        /// <para>Required: no</para>
        /// </summary>
        public string ExpirationTime { get; set; }

        /// <summary>
        /// The OCID of the boot volume backup.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The image OCID used to create the boot volume the backup is taken from.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// The OCID of the KMS key which is the master encryption key for the boot volume backup. 
        /// For more information about the Key Management service and encryption keys, see Overview of Key Management and Using Keys.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }

        /// <summary>
        /// The current state of a boot volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The size of the boot volume, in GBs.
        /// <para>Required: no</para>
        /// </summary>
        public int? SizeInGBs { get; set; }

        /// <summary>
        /// Specifies whether the backup was created manually, or via scheduled backup policy.
        /// <para>Required: no</para>
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// The date and time the boot volume backup was created. 
        /// This is the time the actual point-in-time image of the volume data was taken. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The date and time the request to create the boot volume backup was received. Format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeRequestReceived { get; set; }

        /// <summary>
        /// The type of a volume backup.
        /// <para>Required: no</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The size used by the backup, in GBs. 
        /// It is typically smaller than sizeInGBs, depending on the space consumed on the boot volume and whether the backup is full or incremental.
        /// <para>Required: no</para>
        /// </summary>
        public int? UniqueSizeInGBs { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
