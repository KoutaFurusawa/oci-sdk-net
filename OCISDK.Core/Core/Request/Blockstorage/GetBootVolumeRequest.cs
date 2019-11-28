namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// GetBootVolume Request
    /// </summary>
    public class GetBootVolumeRequest
    {
        /// <summary>
        /// The OCID of the boot volume.
        /// <para>Required: yes</para>
        /// </summary>
        public string BootVolumeId { get; set; }
    }
}
