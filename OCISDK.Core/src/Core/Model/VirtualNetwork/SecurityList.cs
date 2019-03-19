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

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class SecurityList
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

        [JsonProperty("egressSecurityRules")]
        public List<EgressSecurityRule> EgressSecurityRules { get; set; }

        [JsonProperty("ingressSecurityRules")]
        public List<IngressSecurityRule> IngressSecurityRules { get; set; }

        [JsonProperty("freeformTags")]
        public IDictionary<string, string> FreeformTags { get; set; }

        [JsonProperty("definedTags")]
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
