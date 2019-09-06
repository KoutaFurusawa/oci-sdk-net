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
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, 
        /// set the if-match parameter to the value of the etag from a previous GET or POST 
        /// response for that resource. The resource will be updated or deleted only if the 
        /// etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}
