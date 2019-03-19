/// <summary>
/// CreateBootVolumeDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.Blockstorage
{
    public class CreateBootVolumeDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("availabilityDomain")]
        public string AvailabilityDomain { get; set; }

        /// <summary>
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
        /// The size of the boot volume in GBs.
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("sizeInGBs")]
        public int SizeInGBs { get; set; }

        /// <summary>
        /// Specifies the boot volume source details for a new boot volume. 
        /// The volume source is either another boot volume in the same availability domain or a 
        /// boot volume backup. This is a mandatory field for a boot volume.
        /// <para>Required: yes</para>
        /// </summary>
        public BootVolumeSourceDetails SourceDetails { get; set; }

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
