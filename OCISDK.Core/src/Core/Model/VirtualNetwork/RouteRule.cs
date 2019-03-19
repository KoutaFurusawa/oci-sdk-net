/// <summary>
/// RouteRule Reference
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A mapping between a destination IP address range and a virtual device to route matching packets to (a target).
    /// </summary>
    public class RouteRule
    {
        [JsonProperty("cidrBlock")]
        public string CidrBlock { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("destinationType")]
        public string DestinationType { get; set; }

        [JsonProperty("networkEntityId")]
        public string NetworkEntityId { get; set; }
    }
}
