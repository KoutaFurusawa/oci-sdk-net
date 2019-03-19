/// <summary>
/// DhcpOption Reference
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using OCISDK.Core.src.Common;
using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
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
        [JsonProperty("type")]
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
        [JsonProperty("serverType")]
        public string ServerType { get; set; }

        /// <summary>
        /// <para>Allowed values are:
        /// VcnLocal,
        /// VcnLocalPlusInternet,
        /// CustomDnsServer</para>
        /// </summary>
        /// <param name="serviceType"></param>
        public void SetServerType(ServerType serviceType)
        {
            ServerType = EnumAttribute.GetDisplayName(serviceType);
        }

        /// <summary>
        /// If you set serverType to CustomDnsServer, specify the IP address of at least one DNS 
        /// server of your choice (three maximum).
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("customDnsServers")]
        public List<string> CustomDnsServers { get; set; }

        /// <summary>
        /// A single search domain name according to RFC 952 and RFC 1123. During a DNS query, the 
        /// OS will append this search domain name to the value being queried.
        /// <para>Required: yes</para>
        /// </summary>
        [JsonProperty("searchDomainNames")]
        public List<string> SearchDomainNames { get; set; }
    }
}
