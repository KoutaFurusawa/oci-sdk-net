/// <summary>
/// GetVnicAttachmentRequest class
/// 
/// author: koutaro furusawa
/// </summary>
namespace OCISDK.Core.src.Core.Request.Compute
{
    public class GetVnicAttachmentRequest
    {
        /// <summary>
        /// The OCID of the VNIC attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string VnicAttachmentId { get; set; }
    }
}
