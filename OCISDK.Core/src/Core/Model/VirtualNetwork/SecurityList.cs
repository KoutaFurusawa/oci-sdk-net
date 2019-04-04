/// <summary>
/// SecurityList Reference
/// A set of virtual firewall rules for your VCN. Security lists are configured at the subnet level, 
/// but the rules are applied to the ingress and egress traffic for the individual instances in the subnet. 
/// The rules can be stateful or stateless. For more information, see Security Lists.
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>


using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class SecurityList
    {
        public string Id { get; set; }
        
        public string CompartmentId { get; set; }
        
        public string VcnId { get; set; }
        
        public string DisplayName { get; set; }
        
        public string LifecycleState { get; set; }
        
        public string TimeCreated { get; set; }
        
        public List<EgressSecurityRule> EgressSecurityRules { get; set; }
        
        public List<IngressSecurityRule> IngressSecurityRules { get; set; }
        
        public IDictionary<string, string> FreeformTags { get; set; }
        
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
