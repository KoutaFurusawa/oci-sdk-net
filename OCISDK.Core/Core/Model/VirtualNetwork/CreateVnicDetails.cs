using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// CreateVnicDetails
    /// </summary>
    public class CreateVnicDetails
    {
        /// <summary>
        /// Whether the VNIC should be assigned a public IP address. 
        /// Defaults to whether the subnet is public or private. 
        /// If not set and the VNIC is being created in a private subnet (that is, 
        /// where prohibitPublicIpOnVnic = true in the Subnet), then no public IP address 
        /// is assigned. If not set and the subnet is public (prohibitPublicIpOnVnic = false), 
        /// then a public IP address is assigned. 
        /// If set to true and prohibitPublicIpOnVnic = true, an error is returned.
        /// <para>Required: no</para>
        /// </summary>
        public bool AssignPublicIp { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The hostname for the VNIC's primary private IP. Used for DNS. 
        /// The value is the hostname portion of the primary private IP's fully qualified domain name 
        /// (FQDN) (for example, bminstance-1 in FQDN bminstance-1.subnet123.vcn1.oraclevcn.com). 
        /// Must be unique across all VNICs in the subnet and comply with RFC 952 and RFC 1123. The value 
        /// appears in the Vnic object and also the PrivateIp object returned by ListPrivateIps and 
        /// GetPrivateIp.
        /// <para>Required: no</para>
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 63</para>
        /// </summary>
        public string HostnameLabel { get; set; }

        /// <summary>
        /// A private IP address of your choice to assign to the VNIC. 
        /// Must be an available IP address within the subnet's CIDR. 
        /// If you don't specify a value, Oracle automatically assigns a private IP address from the subnet. 
        /// This is the VNIC's primary private IP address. The value appears in the Vnic object and also 
        /// the PrivateIp object returned by ListPrivateIps and GetPrivateIp.
        /// Example: 10.0.3.3
        /// <para>Required: no</para>
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 46</para>
        /// </summary>
        public string PrivateIp { get; set; }

        /// <summary>
        /// Whether the source/destination check is disabled on the VNIC. 
        /// Defaults to false, which means the check is performed. For information about why you would skip 
        /// the source/destination check, see Using a Private IP as a Route Target.
        /// <para>Required: no</para>
        /// </summary>
        public bool? SkipSourceDestCheck { get; set; }

        /// <summary>
        /// The OCID of the subnet to create the VNIC in. 
        /// When launching an instance, use this subnetId instead of the deprecated subnetId in 
        /// LaunchInstanceDetails. At least one of them is required; if you provide both, 
        /// the values must match.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string SubnetId { get; set; }

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
