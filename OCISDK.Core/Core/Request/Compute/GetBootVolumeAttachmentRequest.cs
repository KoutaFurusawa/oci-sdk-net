namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// GetBootVolumeAttachment Request
    /// </summary>
    public class GetBootVolumeAttachmentRequest
    {
        /// <summary>
        /// The OCID of the boot volume attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string BootVolumeAttachmentId { get; set; }
    }
}
