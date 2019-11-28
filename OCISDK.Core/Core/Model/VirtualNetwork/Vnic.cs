using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// Vnic Reference
    /// A virtual network interface card. Each VNIC resides in a subnet in a VCN. An instance attaches to a VNIC to obtain a 
    /// network connection into the VCN through that subnet. Each instance has a primary VNIC that is automatically created and 
    /// attached during launch. You can add secondary VNICs to an instance after it's launched. For more information, see 
    /// Virtual Network Interface Cards (VNICs).
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class Vnic
    {
        /// <summary>
        /// The VNIC's availability domain. Example: Uocm:PHX-AD-1
        /// <para>Required: yes</para>
        /// <para>Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The hostname for the VNIC's primary private IP. 
        /// Used for DNS. The value is the hostname portion of the primary private IP's fully qualified 
        /// domain name (FQDN) (for example, bminstance-1 in FQDN bminstance-1.subnet123.vcn1.oraclevcn.com). 
        /// Must be unique across all VNICs in the subnet and comply with RFC 952 and RFC 1123.
        /// <para>Required: no</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 63</para>
        /// </summary>
        public string HostnameLabel { get; set; }

        /// <summary>
        /// The OCID of the VNIC.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Whether the VNIC is the primary VNIC (the VNIC that is automatically created and attached during 
        /// instance launch).
        /// <para>Required: no</para>
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// The current state of the VNIC.
        /// <para>Allowed values are:
        /// PROVISIONING, AVAILABLE, TERMINATING, TERMINATED
        /// </para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The MAC address of the VNIC.
        /// <para>Required: no</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 32</para>
        /// </summary>
        public string MacAddress { get; set; }

        /// <summary>
        /// The private IP address of the primary privateIp object on the VNIC.
        /// The address is within the CIDR of the VNIC's subnet.
        /// <para>Required: no</para>
        /// </summary>
        public string PrivateIp { get; set; }

        /// <summary>
        /// The public IP address of the VNIC, if one is assigned.
        /// <para>Required: no</para>
        /// </summary>
        public string PublicIp { get; set; }

        /// <summary>
        /// Whether the source/destination check is disabled on the VNIC.
        /// Defaults to false, which means the check is performed. For information about why you would 
        /// skip the source/destination check, see Using a Private IP as a Route Target.
        /// <para>Required: no</para>
        /// </summary>
        public bool SkipSourceDestCheck { get; set; }

        /// <summary>
        /// The OCID of the subnet the VNIC is in.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 255</para>
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// The date and time the VNIC was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

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
