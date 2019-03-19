/// <summary>
/// IngressSecurityRule Reference
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A rule for allowing inbound IP packets.
    /// </summary>
    public class IngressSecurityRule
    {
        [JsonProperty("icmpOptions")]
        public virtual IcmpOption IcmpOptions { get; set; }

        [JsonProperty("isStateless")]
        public virtual bool IsStateless { get; set; }

        [JsonProperty("protocol")]
        public virtual string Protocol { get; set; }

        [JsonProperty("source")]
        public virtual string Source { get; set; }

        [JsonProperty("sourceType")]
        public virtual string SourceType { get; set; }

        [JsonProperty("tcpOptions")]
        public virtual TcpOption TcpOptions { get; set; }

        [JsonProperty("udpOptions")]
        public virtual UdpOption UdpOptions { get; set; }
    }
}
