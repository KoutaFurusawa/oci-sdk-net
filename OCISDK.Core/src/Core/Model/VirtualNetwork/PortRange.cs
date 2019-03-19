/// <summary>
/// PortRange Reference
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// An inclusive range of allowed destination ports.
    /// Use the same number for the min and max to indicate a single port.
    /// Defaults to all ports if not specified.
    /// </summary>
    public class PortRange
    {
        [JsonProperty("max")]
        public virtual int Max { get; set; }

        [JsonProperty("min")]
        public virtual int Min { get; set; }
    }
}
