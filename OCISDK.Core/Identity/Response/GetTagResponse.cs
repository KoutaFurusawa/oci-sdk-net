using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// GetTag Response
    /// </summary>
    public class GetTagResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single Tag resource.
        /// </summary>
        public Tag Tag { get; set; }
    }
}
