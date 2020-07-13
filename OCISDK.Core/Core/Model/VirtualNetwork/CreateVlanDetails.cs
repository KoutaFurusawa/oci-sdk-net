using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// CreateVlanDetails
    /// </summary>
    public class CreateVlanDetails
    {
        /// <summary>
        /// The availability domain of the VLAN.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The range of IPv4 addresses that will be used for layer 3 
        /// communication with hosts outside the VLAN. The CIDR must maintain the following rules -
        /// a.The CIDR block is valid and correctly formatted.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 32</para>
        /// <para>Example: 192.0.2.0/24</para>
        /// </summary>
        public string CidrBlock { get; set; }

        /// <summary>
        /// The OCID of the compartment to contain the VLAN.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A descriptive name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A list of the OCIDs of the network security groups (NSGs) to add all VNICs in the VLAN to. For more information about 
        /// NSGs, see NetworkSecurityGroup.
        /// <para>Required: no</para>
        /// <para>Type: [string (length: 1–255), ...]</para>
        /// <para>Max Items: 5</para>
        /// </summary>
        public List<string> NsgIds { get; set; }

        /// <summary>
        /// The OCID of the route table the VLAN will use. If you don't provide a value, the VLAN uses the VCN's default route table.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string RouteTableId { get; set; }

        /// <summary>
        /// The OCID of the VCN to contain the VLAN.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VcnId { get; set; }

        /// <summary>
        /// The IEEE 802.1Q VLAN tag for this VLAN. The value must be unique across all VLANs in the VCN. If you don't provide a value, 
        /// Oracle assigns one. You cannot change the value later. VLAN tag 0 is reserved for use by Oracle.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 4094</para>
        /// </summary>
        public int? VlanTag { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
