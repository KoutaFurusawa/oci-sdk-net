using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Compute
{
    public class GetVolumeAttachmentRequest
    {
        /// <summary>
        /// The OCID of the volume attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeAttachmentId { get; set; }
    }
}
