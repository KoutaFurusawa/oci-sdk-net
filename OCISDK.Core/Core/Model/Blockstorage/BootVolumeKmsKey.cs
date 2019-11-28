using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// Kms key id associated with this volume.
    /// </summary>
    public class BootVolumeKmsKey
    {
        /// <summary>
        /// The OCID of the KMS key associated with this volume. If volume is not using KMS, then the kmsKeyId will be a null string.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }
    }
}
