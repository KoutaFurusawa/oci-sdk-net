/// <summary>
/// Vcn Reference
/// A virtual cloud network (VCN). For more information, see Overview of the Networking Service.
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    /// <summary>
    /// A virtual cloud network (VCN). For more information, see
    /// [Overview of the Networking Service](https://docs.us-phoenix-1.oraclecloud.com/Content/Network/Concepts/overview.htm).
    /// </summary>
    public class Vcn
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cidrBlock")]
        public string CidrBlock { get; set; }

        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }

        [JsonProperty("defaultDhcpOptionsId")]
        public string DefaultDhcpOptionsId { get; set; }

        [JsonProperty("defaultRouteTableId")]
        public string DefaultRouteTableId { get; set; }

        [JsonProperty("defaultSecurityListId")]
        public string DefaultSecurityListId { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("dnsLabel")]
        public string DnsLabel { get; set; }

        [JsonProperty("lifecycleState")]
        public string LifecycleState { get; set; }

        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }

        [JsonProperty("vcnDomainName")]
        public string VcnDomainName { get; set; }

        [JsonProperty("freeformTags")]
        public IDictionary<string, string> FreeformTags { get; set; }

        [JsonProperty("definedTags")]
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
