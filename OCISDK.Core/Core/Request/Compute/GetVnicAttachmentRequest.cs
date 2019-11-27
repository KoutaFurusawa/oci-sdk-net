namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// GetVnicAttachment Request
    /// </summary>
    public class GetVnicAttachmentRequest
    {
        /// <summary>
        /// The OCID of the VNIC attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string VnicAttachmentId { get; set; }
    }
}
