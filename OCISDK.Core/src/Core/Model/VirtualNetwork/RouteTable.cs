/// <summary>
/// RouteRule Reference
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A collection of `RouteRule` objects, which are used to route packets
    /// based on destination IP to a particular network entity. For more information, see
    /// [Overview of the Networking Service](https://docs.us-phoenix-1.oraclecloud.com/Content/Network/Concepts/overview.htm).
    /// </summary>
    public class RouteTable
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }

        [JsonProperty("vcnId")]
        public string VcnId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("lifecycleState")]
        public string LifecycleState { get; set; }

        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }

        [JsonProperty("routeRules")]
        public List<RouteRule> RouteRules { get; set; }

        [JsonProperty("freeformTags")]
        public IDictionary<string, string> FreeformTags { get; set; }

        [JsonProperty("definedTags")]
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
