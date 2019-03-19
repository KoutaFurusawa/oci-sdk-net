/// <summary>
/// Drg Reference
/// 
/// author: koutaro furusawa
/// </summary>

using System.Collections.Generic;
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.VirtualNetwork
{
    public class Drg
    {
        /// <summary>
        /// The OCID of the compartment containing the DRG.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The DRG's Oracle ID (OCID).
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The DRG's current state.
        /// <para>Required: yes</para>
        /// </summary>
        [JsonProperty("lifecycleState")]
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the DRG was created, in the format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("freeformTags")]
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("definedTags")]
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
