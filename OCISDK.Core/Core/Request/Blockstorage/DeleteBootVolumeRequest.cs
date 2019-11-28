namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// DeleteBootVolume Request
    /// </summary>
    public class DeleteBootVolumeRequest
    {
        /// <summary>
        /// The OCID of the boot volume.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string BootVolumeId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}
