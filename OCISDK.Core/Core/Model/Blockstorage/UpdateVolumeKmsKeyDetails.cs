using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// UpdateVolumeKmsKeyDetails
    /// </summary>
    public class UpdateVolumeKmsKeyDetails
    {
        /// <summary>
        /// The OCID of the new KMS key which will be used to protect the specified volume. 
        /// This key has to be a valid KMS key OCID, and the user must have key delegation policy to allow them to access this key. 
        /// Even if the new KMS key is the same as the previous KMS key ID, the Block Volume service will use it to regenerate a new volume encryption key.
        /// </summary>
        public string KmsKeyId { get; set; }
    }
}
