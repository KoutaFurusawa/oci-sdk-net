/// <summary>
/// GetVnicAttachmentResponse class
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Core.Model.Compute;

namespace OCISDK.Core.src.Core.Response.Compute
{
    public class GetVnicAttachmentResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single VnicAttachment resource.
        /// </summary>
        public VnicAttachment Attachment { get; set; }
    }
}
