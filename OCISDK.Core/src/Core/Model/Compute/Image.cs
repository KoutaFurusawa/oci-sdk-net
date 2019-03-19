/// <summary>
/// Image Reference
/// A boot disk image for launching an instance. For more information, see Overview of the Compute Service.
/// 
/// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
/// 
/// author: koutaro furusawa
/// </summary>

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Model.Compute
{
    public class Image
    {
        /// <summary>
        /// The OCID of the image originally used to launch the instance.
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        [JsonProperty("baseImageId")]
        public string BaseImageId { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the instance you want to use as the basis for the image.
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        [JsonProperty("compartmentId")]
        public string CompartmentId { get; set; }

        /// <summary>
        /// Whether instances launched with this image can be used to create new images.
        /// For example, you cannot create an image of an Oracle Database instance. 
        /// <para></para>
        /// </summary>
        [JsonProperty("createImageAllowed")]
        public bool CreateImageAllowed { get; set; }

        /// <summary>
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Specifies the configuration mode for launching virtual machine (VM) instances. 
        /// <para>Allowed values are:
        /// NATIVE, 
        /// EMULATED, 
        /// CUSTOM</para>
        /// </summary>
        [JsonProperty("launchMode")]
        public string LaunchMode { get; set; }

        [JsonProperty("launchOptions")]
        public LaunchOptions LaunchOptions { get; set; }
        
        [JsonProperty("lifecycleState")]
        public string LifecycleState { get; set; }

        /// <summary>
        /// The image's operating system.
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        [JsonProperty("operatingSystem")]
        public string OperatingSystem { get; set; }

        /// <summary>
        /// The image's operating system version.
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>
        /// </summary>
        [JsonProperty("operatingSystemVersion")]
        public string OperatingSystemVersion { get; set; }
        
        /// <summary>
        /// Image size (1 MB = 1048576 bytes)
        /// </summary>
        [JsonProperty("sizeInMBs")]
        public int SizeInMBs { get; set; }

        /// <summary>
        /// The date and time the image was created, in the format defined by RFC3339.
        /// </summary>
        [JsonProperty("TimeCreated")]
        public string timeCreated { get; set; }

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
