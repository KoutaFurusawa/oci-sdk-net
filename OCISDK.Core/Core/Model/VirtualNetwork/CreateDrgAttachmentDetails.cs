using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// CreateDrgAttachmentDetails Reference
    /// </summary>
    public class CreateDrgAttachmentDetails
    {
        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the DRG.
        /// <para>Required: yes</para>
        /// </summary>
        public string DrgId { get; set; }

        /// <summary>
        /// The OCID of the route table the DRG attachment will use.
        /// 
        /// If you don't specify a route table here, the DRG attachment is created without an associated route table. 
        /// The Networking service does NOT automatically associate the attached VCN's default route table with the DRG attachment.
        /// <para>Required: no</para>
        /// </summary>
        public string RouteTableId { get; set; }

        /// <summary>
        /// The OCID of the VCN.
        /// <para>Required: yes</para>
        /// </summary>
        public string VcnId { get; set; }
    }
}
