/// <summary>
/// LaunchOptions Reference
/// 
/// author: koutaro furusawa
/// </summary>
using Newtonsoft.Json;

namespace OCISDK.Core.src.Core.Model.Compute
{
    public class LaunchOptions
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Allowed values are:
        /// ISCSI, 
        /// SCSI, 
        /// IDE, 
        /// VFIO, 
        /// PARAVIRTUALIZED</para>
        /// </summary>
        [JsonProperty("bootVolumeType")]
        public string BootVolumeType { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Allowed values are: BIOS, UEFI_64</para>
        /// </summary>
        [JsonProperty("firmware")]
        public string Firmware { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Allowed values are: E1000, VFIO</para>
        /// </summary>
        [JsonProperty("networkType")]
        public string NetworkType { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Allowed values are:
        /// ISCSI, 
        /// SCSI, 
        /// IDE, 
        /// VFIO, 
        /// PARAVIRTUALIZED</para>
        /// </summary>
        [JsonProperty("remoteDataVolumeType")]
        public string RemoteDataVolumeType { get; set; }

        /// <summary>
        /// Whether to enable in-transit encryption for the boot volume's paravirtualized attachment.
        /// The default value is false.
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("isPvEncryptionInTransitEnabled")]
        public string IsPvEncryptionInTransitEnabled { get; set; }

        /// <summary>
        /// Whether to enable consistent volume naming feature. Defaults to false.
        /// <para>Required: no</para>
        /// </summary>
        [JsonProperty("isConsistentVolumeNamingEnabled")]
        public string IsConsistentVolumeNamingEnabled { get; set; }
    }
}
