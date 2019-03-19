/// <summary>
/// DetachBootVolumeRequest class
/// 
/// author: koutaro furusawa
/// </summary>
namespace OCISDK.Core.src.Core.Request.Compute
{
    public class DetachBootVolumeRequest
    {
        /// <summary>
        /// The OCID of the boot volume attachment.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string BootVolumeAttachmentId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}
