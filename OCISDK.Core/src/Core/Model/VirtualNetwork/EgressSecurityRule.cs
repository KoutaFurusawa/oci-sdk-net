/// <summary>
/// EgressSecurityRule Reference
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A rule for allowing outbound IP packets.
    /// </summary>
    public class EgressSecurityRule
    {
        [JsonProperty("destination")]
        public virtual string Destination { get; set; }

        [JsonProperty("destinationType")]
        public virtual string DestinationType { get; set; }

        [JsonProperty("icmpOptions")]
        public virtual IcmpOption IcmpOptions { get; set; }

        [JsonProperty("isStateless")]
        public virtual bool IsStateless { get; set; }

        [JsonProperty("protocol")]
        public virtual string Protocol { get; set; }

        [JsonProperty("tcpOptions")]
        public virtual TcpOption TcpOptions { get; set; }

        [JsonProperty("udpOptions")]
        public virtual UdpOption UdpOptions { get; set; }
    }
}
