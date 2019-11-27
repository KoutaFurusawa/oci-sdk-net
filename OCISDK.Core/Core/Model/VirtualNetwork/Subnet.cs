using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// Subnet Reference
    /// A logical subdivision of a VCN. Each subnet exists in a single availability domain and consists of a 
    /// contiguous range of IP addresses that do not overlap with other subnets in the VCN. Example: 172.16.1.0/24. For 
    /// more information, see Overview of the Networking Service and VCNs and Subnets.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// 
    /// author: koutaro furusawa
    /// </summary>
    public class Subnet
    {
        /// <summary>
        /// The subnet's availability domain. This attribute will be null if this is a regional subnet 
        /// instead of an AD-specific subnet. Oracle recommends creating regional subnets.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The subnet's CIDR block.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CidrBlock { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the set of DHCP options that the subnet uses.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DhcpOptionsId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A DNS label for the subnet, used in conjunction with the VNIC's hostname and VCN's 
        /// DNS label to form a fully qualified domain name (FQDN) for each VNIC within this
        /// subnet (for example, bminstance-1.subnet123.vcn1.oraclevcn.com). Must be an alphanumeric 
        /// string that begins with a letter and is unique within the VCN. The value cannot be changed.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 15</para>
        /// </summary>
        public string DnsLabel { get; set; }

        /// <summary>
        /// The subnet's Oracle ID (OCID).
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The subnet's current state.
        /// <para>Required: no</para>
        /// <para>
        /// Allowed values are:
        /// PROVISIONING, 
        /// AVAILABLE,
        /// TERMINATING,
        /// TERMINATED
        /// </para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// Whether VNICs within this subnet can have public IP addresses. 
        /// Defaults to false, which means VNICs created in this subnet will automatically be 
        /// assigned public IP addresses unless specified otherwise during instance launch or 
        /// VNIC creation (with the assignPublicIp flag in CreateVnicDetails). If prohibitPublicIpOnVnic 
        /// is set to true, VNICs created in this subnet cannot have public IP addresses 
        /// (that is, it's a private subnet).
        /// <para>Required: no</para>
        /// </summary>
        public bool? ProhibitPublicIpOnVnic { get; set; }

        /// <summary>
        /// The OCID of the route table that the subnet uses.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string RouteTableId { get; set; }

        /// <summary>
        /// The OCIDs of the security list or lists that the subnet uses. 
        /// Remember that security lists are associated with the subnet, but the rules are applied to 
        /// the individual VNICs in the subnet.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> SecurityListIds { get; set; }

        /// <summary>
        /// The subnet's domain name, which consists of the subnet's DNS label, the VCN's DNS label, 
        /// and the oraclevcn.com domain.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 253</para>
        /// </summary>
        public string SubnetDomainName { get; set; }

        /// <summary>
        /// The date and time the instance was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the VCN the subnet is in.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VcnId { get; set; }

        /// <summary>
        /// The IP address of the virtual router.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 32</para>
        /// </summary>
        public string VirtualRouterIp { get; set; }

        /// <summary>
        /// The MAC address of the virtual router.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 32</para>
        /// </summary>
        public string VirtualRouterMac { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
