using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// CreateVolumeDetails
    /// </summary>
    public class CreateVolumeDetails
    {
        /// <summary>
        /// The availability domain of the volume.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// If provided, specifies the ID of the volume backup policy to assign to the newly created volume. 
        /// If omitted, no policy will be assigned.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string BackupPolicyId { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the volume.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the KMS key which is the master encryption key for the volume backup. 
        /// For more information about the Key Management service and encryption keys, see Overview of Key Management and Using Keys.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }
        
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
        /// Specifies the volume source details for a new Block volume. 
        /// The volume source is either another Block volume in the same availability domain or a Block volume backup. 
        /// This is an optional field. If not specified or set to null, the new Block volume will be empty. When specified, 
        /// the new Block volume will contain data from the source volume or backup.
        /// <para>Required: no</para>
        /// </summary>
        public VolumeSourceDetails SourceDetails { get; set; }

        /// <summary>
        /// The OCID of the volume backup from which the data should be restored on the newly created volume. 
        /// This field is deprecated. Use the sourceDetails field instead to specify the backup for the volume.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeBackupId { get; set; }

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
