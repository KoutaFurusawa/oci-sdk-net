using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// GetVolumeAttachment Request
    /// </summary>
    public class GetVolumeAttachmentRequest
    {
        /// <summary>
        /// The OCID of the volume attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeAttachmentId { get; set; }
    }
}
