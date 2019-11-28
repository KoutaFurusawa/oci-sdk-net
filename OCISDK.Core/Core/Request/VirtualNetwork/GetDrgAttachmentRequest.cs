using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// GetDrgAttachment Request
    /// </summary>
    public class GetDrgAttachmentRequest
    {
        /// <summary>
        /// The OCID of the DRG attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string DrgAttachmentId { get; set; }
    }
}
