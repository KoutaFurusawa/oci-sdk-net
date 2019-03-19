/// <summary>
/// LaunchInstanceDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;
using OCISDK.Core.src.Core.Model.VirtualNetwork;
using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.Compute
{
    public class LaunchInstanceDetails
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
        /// Details for creating a new VNIC.
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("createVnicDetails")]
        public CreateVnicDetails CreateVnicDetails { get; set; }

        /// <summary>
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
        /// A fault domain is a grouping of hardware and infrastructure within an availability domain. 
        /// Each availability domain contains three fault domains. Fault domains let you distribute your 
        /// instances so that they are not on the same physical hardware within a single availability domain. 
        /// A hardware failure or Compute hardware maintenance that affects one fault domain does not affect 
        /// instances in other fault domains.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("faultDomain")]
        public string FaultDomain { get; set; }

        /// <summary>
        /// Deprecated. Instead use hostnameLabel in CreateVnicDetails. If you provide both, the values must match.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 63</para>
        /// </summary>
        [JsonProperty("hostnameLabel")]
        public string HostnameLabel { get; set; }

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
        [JsonProperty("metadata")]
        public object Metadata { get; set; }

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
        /// Deprecated. Instead use subnetId in CreateVnicDetails. 
        /// At least one of them is required; if you provide both, the values must match.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("subnetId")]
        public string SubnetId { get; set; }

        /// <summary>
        /// Whether to enable in-transit encryption for the data volume's paravirtualized attachment. 
        /// The default value is false.
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("isPvEncryptionInTransitEnabled")]
        public bool IsPvEncryptionInTransitEnabled { get; set; }

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
