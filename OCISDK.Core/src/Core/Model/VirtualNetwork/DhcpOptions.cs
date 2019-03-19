/// <summary>
/// DhcpOptions Reference
/// A set of DHCP options. Used by the VCN to automatically provide configuration 
/// information to the instances when they boot up. There are two options you can set:
/// 
/// * DhcpDnsOption: Lets you specify how DNS (hostname resolution) is handled in the subnets in your VCN.
/// * DhcpSearchDomainOption: Lets you specify a search domain name to use for DNS queries.
/// 
/// For more information, see DNS in Your Virtual Cloud Network and DHCP Options.
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>

using System.Collections.Generic;
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class DhcpOptions
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

        [JsonProperty("options")]
        public List<DhcpOption> Options { get; set; }

        [JsonProperty("freeformTags")]
        public IDictionary<string, string> FreeformTags { get; set; }

        [JsonProperty("definedTags")]
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
