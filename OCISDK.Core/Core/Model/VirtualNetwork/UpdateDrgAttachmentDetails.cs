using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// UpdateDrgAttachmentDetails Reference
    /// </summary>
    public class UpdateDrgAttachmentDetails
    {
        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the route table the DRG attachment will use.
        /// <para>Required: no</para>
        /// </summary>
        public string RouteTableId { get; set; }
    }
}
