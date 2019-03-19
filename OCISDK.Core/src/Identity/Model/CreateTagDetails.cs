/// <summary>
/// CreateTagDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OCISDK.Core.src.Identity.Model
{
    public class CreateTagDetails
    {
        /// <summary>
        /// The name you assign to the tag during creation. 
        /// The name must be unique within the tag namespace and cannot be changed.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// The description you assign to the tag during creation.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 400</para>
        /// </summary>
        [JsonProperty("description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Indicates whether the tag is enabled for cost tracking.
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("isCostTracking")]
        public bool IsCostTracking { get; set; }

        /// <summary>
        /// Free-form tags for this resource. 
        /// Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// </summary>
        [JsonProperty("freeformTags")]
        public virtual IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// </summary>
        [JsonProperty("definedTags")]
        public virtual IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
