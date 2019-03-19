/// <summary>
/// Tenancy Reference
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OCISDK.Core.src.Identity.Model
{
    public class Tenancy
    {
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("description")]
        public virtual string Description { get; set; }

        [JsonProperty("homeRegionKey")]
        public virtual string HomeRegionKey { get; set; }

        [JsonProperty("freeformTags")]
        public virtual IDictionary<string, string> FreeformTags { get; set; }

        [JsonProperty("definedTags")]
        public virtual IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
