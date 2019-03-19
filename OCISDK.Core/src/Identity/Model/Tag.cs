/// <summary>
/// Tag Reference
/// A tag definition that belongs to a specific tag namespace. 
/// "Defined tags" must be set up in your tenancy before you can apply them to resources. 
/// For more information, see Managing Tags and Tag Namespaces.
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OCISDK.Core.src.Identity.Model
{
    public class Tag
    {
        /// <summary>
        /// The OCID of the compartment that contains the tag definition.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the namespace that contains the tag definition.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        [JsonProperty("tagNamespaceId")]
        public string TagNamespaceId { get; set; }

        /// <summary>
        /// The name of the tag namespace that contains the tag definition.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        [JsonProperty("tagNamespaceName")]
        public string TagNamespaceName { get; set; }

        /// <summary>
        /// The OCID of the tag definition.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the tag. The name must be unique across all tags in the namespace and can't be changed.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 100</para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description you assign to the tag.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1</para>
        /// <para>Maximum: 400</para>
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Whether the tag namespace is retired. 
        /// See Retiring Key Definitions and Namespace Definitions.
        /// <para>Required: yes</para>
        /// </summary>
        [JsonProperty("isRetired")]
        public bool IsRetired { get; set; }

        /// <summary>
        /// Date and time the tag namespace was created, in the format defined by RFC3339. Example: 2016-08-25T21:10:29.600Z
        /// <para>Required: yes</para>
        /// </summary>
        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }

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
