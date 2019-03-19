/// <summary>
/// InstanceSourceDetails Reference
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.Compute
{
    public class InstanceSourceDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("sourceType")]
        public string SourceType { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("bootVolumeSizeInGBs")]
        public int? BootVolumeSizeInGBs { get; set; }

        /// <summary>
        /// The OCID of the image used to boot the instance.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("imageId")]
        public string ImageId { get; set; }

        /// <summary>
        /// The OCID of the KMS key to be used as the master encryption key for the boot volume.
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("kmsKeyId")]
        public string KmsKeyId { get; set; }

        /// <summary>
        /// The OCID of the boot volume used to boot the instance.
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        [JsonProperty("bootVolumeId")]
        public string BootVolumeId { get; set; }
    }
}
