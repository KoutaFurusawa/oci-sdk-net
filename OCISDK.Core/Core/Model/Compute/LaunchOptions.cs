namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// LaunchOptions
    /// </summary>
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
        public string BootVolumeType { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Allowed values are: BIOS, UEFI_64</para>
        /// </summary>
        public string Firmware { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Allowed values are: E1000, VFIO</para>
        /// </summary>
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
        public string RemoteDataVolumeType { get; set; }

        /// <summary>
        /// Whether to enable in-transit encryption for the boot volume's paravirtualized attachment.
        /// The default value is false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsPvEncryptionInTransitEnabled { get; set; }

        /// <summary>
        /// Whether to enable consistent volume naming feature. Defaults to false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsConsistentVolumeNamingEnabled { get; set; }
    }
}
