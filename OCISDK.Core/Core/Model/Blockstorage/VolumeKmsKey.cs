using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// VolumeKmsKey
    /// </summary>
    public class VolumeKmsKey
    {
        /// <summary>
        /// The KMS key OCID associated with this volume. If the volume is not using KMS, then the kmsKeyId will be a null string.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }
    }
}
