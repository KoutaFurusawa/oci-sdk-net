using OCISDK.Core.Core.Model.Compute;

namespace OCISDK.Core.Core.Response.Compute
{
    /// <summary>
    /// GetImage Response
    /// </summary>
    public class GetImageResponse
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
        /// The response body will contain a single Image resource.
        /// </summary>
        public Image Image { get; set; }
    }
}
