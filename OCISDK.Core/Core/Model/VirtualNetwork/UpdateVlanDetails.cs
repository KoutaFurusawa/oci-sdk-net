using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// UpdateVlanDetails
    /// </summary>
    public class UpdateVlanDetails
    {
        /// <summary>
        /// A descriptive name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A list of the OCIDs of the network security groups (NSGs) to use with this VLAN. All VNICs in the VLAN will belong to 
        /// these NSGs. For more information about NSGs, see NetworkSecurityGroup.
        /// <para>Required: no</para>
        /// <para>Type: [string (length: 1–255), ...]</para>
        /// <para>Max Items: 5</para>
        /// </summary>
        public List<string> NsgIds { get; set; }

        /// <summary>
        /// The OCID of the route table the VLAN will use.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string RouteTableId { get; set; }
    }
}
