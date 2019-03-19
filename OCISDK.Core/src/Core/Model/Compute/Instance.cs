/// <summary>
/// Instance Reference
/// A compute host. The image used to launch the instance determines its operating system and other software. 
/// The shape specified during the launch process determines the number of CPUs and memory allocated to the instance. 
/// For more information, see Overview of the Compute Service.
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.Compute
{
    public class Instance
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
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("extendedMetadata")]
        public object ExtendedMetadata { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("faultDomain")]
        public string FaultDomain { get; set; }

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
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 10240</para>
        /// </summary>
        [JsonProperty("ipxeScript")]
        public string IpxeScript { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("launchMode")]
        public string LaunchMode { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("launchOptions")]
        public LaunchOptions LaunchOptions { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("lifecycleState")]
        public string LifecycleState { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("metadata")]
        public object Metadata { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("shape")]
        public string Shape { get; set; }

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
        /// The date and time the instance is expected to be stopped / started, in the format defined by RFC3339.
        /// After that time if instance hasn't been rebooted, Oracle will reboot the instance within 24 hours of the due time.
        /// Regardless of how the instance was stopped, the flag will be reset to empty as soon as instance reaches Stopped state.
        /// </summary>
        [JsonProperty("timeMaintenanceRebootDue")]
        public string TimeMaintenanceRebootDue { get; set; }

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
