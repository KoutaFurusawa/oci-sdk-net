using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A resource to be used only with the Oracle Cloud VMware Solution.
    /// 
    /// Conceptually, a virtual LAN (VLAN) is a broadcast domain that is created by partitioning and isolating a 
    /// network at the data link layer (a layer 2 network). VLANs work by using IEEE 802.1Q VLAN tags. Layer 2 traffic is 
    /// forwarded within the VLAN based on MAC learning.
    /// 
    /// In the Networking service, a VLAN is an object within a VCN. You use VLANs to partition the VCN at the data 
    /// link layer (layer 2). A VLAN is analagous to a subnet, which is an object for partitioning the VCN at the IP layer 
    /// (layer 3).
    /// </summary>
    public class VlanDetails
    {
        /// <summary>
        /// The availability domain of the VLAN.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The range of IPv4 addresses that will be used for layer 3 communication with hosts outside the VLAN.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 32</para>
        /// </summary>
        public string CidrBlock { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the VLAN.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The VLAN's Oracle ID (OCID).
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The VLAN's current state.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// A list of the OCIDs of the network security groups (NSGs) to use with this VLAN. All VNICs in the VLAN belong to 
        /// these NSGs. For more information about NSGs, see NetworkSecurityGroup.
        /// <para>Required: no</para>
        /// <para>[string (length: 1–255), ...]</para>
        /// <para>Max Items: 5</para>
        /// </summary>
        public List<string> NsgIds { get; set; }

        /// <summary>
        /// The OCID of the route table that the VLAN uses.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string RouteTableId { get; set; }

        /// <summary>
        /// The date and time the VLAN was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the VCN the VLAN is in.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VcnId { get; set; }

        /// <summary>
        /// The IEEE 802.1Q VLAN tag of this VLAN.
        /// <para>Required: no</para>
        /// </summary>
        public int? VlanTag { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. For more information, see Resource Tags.
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. For more information, see Resource Tags.
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
