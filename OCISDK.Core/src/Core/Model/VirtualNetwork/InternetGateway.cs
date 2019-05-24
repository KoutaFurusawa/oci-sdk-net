/// <summary>
/// InternetGateway Reference
/// Represents a router that connects the edge of a VCN with the Internet. 
/// For an example scenario that uses an internet gateway, see Typical Networking Service Scenarios.
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>


using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class InternetGateway
    {
        public string Id { get; set; }
        
        public string CompartmentId { get; set; }
        
        public string VcnId { get; set; }
        public string DisplayName { get; set; }
        
        public string LifecycleState { get; set; }
        
        public string TimeCreated { get; set; }
        
        public bool? IsEnabled { get; set; }
        
        public IDictionary<string, string> FreeformTags { get; set; }
        
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
