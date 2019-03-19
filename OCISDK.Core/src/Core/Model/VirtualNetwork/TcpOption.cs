/// <summary>
/// TcpOption Reference
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// Optional object to specify ports for a TCP rule.
    /// If you specify TCP as the protocol but omit this object, then all ports are allowed.
    /// </summary>
    public class TcpOption
    {
        [JsonProperty("destinationPortRange")]
        public virtual PortRange DestinationPortRange { get; set; }

        [JsonProperty("sourcePortRange")]
        public virtual PortRange SourcePortRange { get; set; }
    }
}
