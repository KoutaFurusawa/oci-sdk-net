using System.Collections.Generic;


namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A virtual cloud network (VCN). For more information, see
    /// [Overview of the Networking Service](https://docs.us-phoenix-1.oraclecloud.com/Content/Network/Concepts/overview.htm).
    /// </summary>
    public class Vcn
    {
        /// <summary>
        /// The VCN's Oracle ID (OCID).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The CIDR IP address block of the VCN.
        /// </summary>
        public string CidrBlock { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the VCN.
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID for the VCN's default set of DHCP options.
        /// </summary>
        public string DefaultDhcpOptionsId { get; set; }

        /// <summary>
        /// The OCID for the VCN's default route table.
        /// </summary>
        public string DefaultRouteTableId { get; set; }

        /// <summary>
        /// The OCID for the VCN's default security list.
        /// </summary>
        public string DefaultSecurityListId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A DNS label for the VCN, used in conjunction with the VNIC's hostname and subnet's DNS label to form a fully qualified domain name (FQDN) 
        /// for each VNIC within this subnet (for example, bminstance-1.subnet123.vcn1.oraclevcn.com). Must be an alphanumeric string that begins 
        /// with a letter. The value cannot be changed.
        /// </summary>
        public string DnsLabel { get; set; }

        /// <summary>
        /// For an IPv6-enabled VCN, this is the IPv6 CIDR block for the VCN's private IP address space. The VCN size is always /48. If you don't provide a 
        /// value when creating the VCN, Oracle provides one and uses that same CIDR for the ipv6PublicCidrBlock. If you do provide a value, Oracle provides 
        /// a different CIDR for the ipv6PublicCidrBlock. Note that IPv6 addressing is currently supported only in the Government Cloud.
        /// </summary>
        public string Ipv6CidrBlock { get; set; }

        /// <summary>
        /// For an IPv6-enabled VCN, this is the IPv6 CIDR block for the VCN's public IP address space. The VCN size is always /48. This CIDR is always provided 
        /// by Oracle. If you don't provide a custom CIDR for the ipv6CidrBlock when creating the VCN, Oracle assigns that value and also uses it for 
        /// ipv6PublicCidrBlock. Oracle uses addresses from this block for the publicIpAddress attribute of an Ipv6 that has internet access allowed.
        /// </summary>
        public string Ipv6PublicCidrBlock { get; set; }

        /// <summary>
        /// The VCN's current state.
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the VCN was created, in the format defined by RFC3339.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The VCN's domain name, which consists of the VCN's DNS label, and the oraclevcn.com domain.
        /// </summary>
        public string VcnDomainName { get; set; }

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
