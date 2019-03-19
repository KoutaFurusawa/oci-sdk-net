/// <summary>
/// BootVolume Reference
/// A detachable boot volume device that contains the image used to boot a Compute instance. 
/// For more information, see Overview of Boot Volumes.
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using OCISDK.Core.src.Core.Model.Compute;
using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.Blockstorage
{
    public class BootVolume
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
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("imageId")]
        public string ImageId { get; set; }

        /// <summary>
        /// Specifies whether the boot volume's data has finished copying from the source boot volume or boot volume backup.
        /// </summary>
        [JsonProperty("isHydrated")]
        public bool IsHydrated { get; set; }

        /// <summary>
        /// The current state of a boot volume.
        /// <para>Allowed values are:
        /// PROVISIONING
        /// RESTORING
        /// AVAILABLE
        /// TERMINATING
        /// TERMINATED
        /// FAULTY</para>
        /// </summary>
        [JsonProperty("lifecycleState")]
        public string LifecycleState { get; set; }

        /// <summary>
        /// The size of the boot volume in GBs.
        /// </summary>
        [JsonProperty("sizeInGBs")]
        public int SizeInGBs { get; set; }

        /// <summary>
        /// The size of the volume in MBs. The value must be a multiple of 1024.
        /// This field is deprecated. Please use sizeInGBs.
        /// </summary>
        [JsonProperty("sizeInMBs")]
        public int SizeInMBs { get; set; }

        /// <summary>
        /// Details for creating an instance
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("sourceDetails")]
        public InstanceSourceDetails SourceDetails { get; set; }

        /// <summary>
        /// The date and time the instance was created, in the format defined by RFC3339.
        /// </summary>
        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the source volume group.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("volumeGroupId")]
        public string VolumeGroupId { get; set; }

        /// <summary>
        /// The OCID of the source volume group.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("kmsKeyId")]
        public string KmsKeyId { get; set; }

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
