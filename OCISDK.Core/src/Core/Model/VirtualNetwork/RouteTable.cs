/// <summary>
/// RouteRule Reference
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>


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
        public string Id { get; set; }
        
        public string CompartmentId { get; set; }
        
        public string VcnId { get; set; }
        
        public string DisplayName { get; set; }
        
        public string LifecycleState { get; set; }
        
        public string TimeCreated { get; set; }
        
        public List<RouteRule> RouteRules { get; set; }
        
        public IDictionary<string, string> FreeformTags { get; set; }
        
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
