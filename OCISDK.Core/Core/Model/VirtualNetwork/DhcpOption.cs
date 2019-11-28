using OCISDK.Core.Common;
using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A single DHCP option according to [RFC 1533](https://tools.ietf.org/html/rfc1533).
    /// </summary>
    public class DhcpOption
    {
        /// <summary>
        /// The specific DHCP option.
        /// Either DomainNameServer (for DhcpDnsOption) or SearchDomain (for DhcpSearchDomainOption).
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// <para>VcnLocal: Reserved for future use.</para>
        /// <para>VcnLocalPlusInternet: Also referred to as "Internet and VCN Resolver".
        /// Instances can resolve internet hostnames (no internet gateway is required), 
        /// and can resolve hostnames of instances in the VCN.
        /// This is the default value in the default set of DHCP options in the VCN.For 
        /// the Internet and VCN Resolver to work across the VCN, there must also be a 
        /// DNS label set for the VCN, a DNS label set for each subnet, and a hostname 
        /// for each instance. The Internet and VCN Resolver also enables reverse DNS 
        /// lookup, which lets you determine the hostname corresponding to the private 
        /// IP address. For more information</para>
        /// <para>CustomDnsServer: Instances use a DNS server of your choice (three maximum).</para>
        /// <para>Required: yes</para>
        /// <para>Allowed values are:
        /// VcnLocal,
        /// VcnLocalPlusInternet,
        /// CustomDnsServer</para>
        /// </summary>
        public string ServerType { get; set; }

        /// <summary>
        /// <para>Allowed values are:
        /// VcnLocal,
        /// VcnLocalPlusInternet,
        /// CustomDnsServer</para>
        /// </summary>
        /// <param name="serviceType"></param>
        public void SetServerType(ServerTypes serviceType)
        {
            ServerType = serviceType.Value;
        }

        /// <summary>
        /// ServerTypes
        /// </summary>
        public class ServerTypes : ExpandableEnum<ServerTypes>
        {
            /// <summary>
            /// ServerTypes
            /// </summary>
            /// <param name="value"></param>
            public ServerTypes(string value) : base(value) { }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator ServerTypes(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// VcnLocal
            /// </summary>
            public static readonly ServerTypes VcnLocal = new ServerTypes("VcnLocal");

            /// <summary>
            /// VcnLocalPlusInternet
            /// </summary>
            public static readonly ServerTypes VcnLocalPlusInternet = new ServerTypes("VcnLocalPlusInternet");

            /// <summary>
            /// CustomDnsServer
            /// </summary>
            public static readonly ServerTypes CustomDnsServer = new ServerTypes("CustomDnsServer");
        }

        /// <summary>
        /// If you set serverType to CustomDnsServer, specify the IP address of at least one DNS 
        /// server of your choice (three maximum).
        /// <para>Required: no</para>
        /// </summary>
        public List<string> CustomDnsServers { get; set; }

        /// <summary>
        /// A single search domain name according to RFC 952 and RFC 1123. During a DNS query, the 
        /// OS will append this search domain name to the value being queried.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> SearchDomainNames { get; set; }
    }
}
