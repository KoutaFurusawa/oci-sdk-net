/// <summary>
/// Compartment Reference
/// A collection of related resources. Compartments are a fundamental component of 
/// Oracle Cloud Infrastructure for organizing and isolating your cloud resources. 
/// You use them to clearly separate resources for the purposes of measuring usage 
/// and billing, access (through the use of IAM Service policies), and isolation 
/// (separating the resources for one project or business unit from another). A common 
/// approach is to create a compartment for each major part of your organization. 
/// For more information, see Overview of the IAM Service and also Setting Up Your 
/// Tenancy.
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OCISDK.Core.src.Identity.Model
{
    public class Compartment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }

        [JsonProperty("lifecycleState")]
        public string LifecycleState { get; set; }

        [JsonProperty("inactiveStatus")]
        public int InactiveStatus { get; set; }

        [JsonProperty("isAccessible")]
        public bool IsAccessible { get; set; }

        [JsonProperty("freeformTags")]
        public IDictionary<string, string> FreeformTags { get; set; }

        [JsonProperty("definedTags")]
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
