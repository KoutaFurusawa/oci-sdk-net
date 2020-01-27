namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// InstanceSourceDetails
    /// </summary>
    public class InstanceSourceDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public int? BootVolumeSizeInGBs { get; set; }

        /// <summary>
        /// The OCID of the image used to boot the instance.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// The OCID of the KMS key to be used as the master encryption key for the boot volume.
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }

        /// <summary>
        /// The OCID of the boot volume used to boot the instance.
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string BootVolumeId { get; set; }
    }
}
