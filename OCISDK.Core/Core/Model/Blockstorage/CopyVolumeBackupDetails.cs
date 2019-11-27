using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// CopyVolumeBackupDetails
    /// </summary>
    public class CopyVolumeBackupDetails
    {
        /// <summary>
        /// The name of the destination region.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DestinationRegion { get; set; }

        /// <summary>
        /// A user-friendly name for the volume backup. 
        /// Does not have to be unique and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the KMS key in the destination region which will be the master encryption key for the copied volume backup. 
        /// If you do not specify this attribute the volume backup will be encrypted with the Oracle-provided encryption key when it is copied to the destination region.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }
    }
}
