/// <summary>
/// BootVolumeAttachment Reference
/// Represents an attachment between a boot volume and an instance.
/// 
/// Warning: Oracle recommends that you avoid using any confidential 
/// information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.Compute
{
    /// <summary>
    /// Represents an attachment between a boot volume and an instance.
    /// </summary>
    public class BootVolumeAttachment
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
        [JsonProperty("bootVolumeId")]
        public string BootVolumeId { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }

        /// <summary>
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
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("instanceId")]
        public string InstanceId { get; set; }

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
        /// The date and time the instance was created, in the format defined by RFC3339.
        /// </summary>
        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }

        /// <summary>
        /// Whether in-transit encryption for the boot volume's paravirtualized attachment is enabled or not.
        /// </summary>
        [JsonProperty("isPvEncryptionInTransitEnabled")]
        public bool IsPvEncryptionInTransitEnabled { get; set; }
    }
}
