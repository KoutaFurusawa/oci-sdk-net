using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// CreateSubnetDetails
    /// </summary>
    public class CreateSubnetDetails
    {
        /// <summary>
        /// Controls whether the subnet is regional or specific to an availability domain. 
        /// Oracle recommends creating regional subnets because they're more flexible and make 
        /// it easier to implement failover across availability domains. Originally, AD-specific 
        /// subnets were the only kind available to use.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The CIDR IP address range of the subnet.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 32</para>
        /// </summary>
        public string CidrBlock { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the set of DHCP options the subnet will use.
        /// If you don't provide a value, the subnet uses the VCN's default set of DHCP options.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DhcpOptionsId { get; set; }

        /// <summary>
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
        /// Whether VNICs within this subnet can have public IP addresses. Defaults to false, which means 
        /// VNICs created in this subnet will automatically be assigned public IP addresses unless specified 
        /// otherwise during instance launch or VNIC creation (with the assignPublicIp flag in 
        /// CreateVnicDetails). If prohibitPublicIpOnVnic is set to true, VNICs created in this subnet cannot 
        /// have public IP addresses (that is, it's a private subnet).
        /// <para>Required: no</para>
        /// </summary>
        public bool ProhibitPublicIpOnVnic { get; set; }

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
        /// The OCID of the VCN the subnet is in.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VcnId { get; set; }

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
