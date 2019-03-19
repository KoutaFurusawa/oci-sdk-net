/// <summary>
/// GetBootVolumeAttachmentRequest class
/// 
/// author: koutaro furusawa
/// </summary>
namespace OCISDK.Core.src.Core.Request.Compute
{
    public class GetBootVolumeAttachmentRequest
    {
        /// <summary>
        /// The OCID of the boot volume attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string BootVolumeAttachmentId { get; set; }
    }
}
