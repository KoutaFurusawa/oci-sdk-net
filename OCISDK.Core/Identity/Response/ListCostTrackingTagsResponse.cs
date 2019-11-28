using OCISDK.Core.Identity.Model;
using System.Collections.Generic;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// ListCostTrackingTags Response
    /// </summary>
    public class ListCostTrackingTagsResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.If you need to contact Oracle about a particular request, 
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain an array of TagNamespaceSummary resources.
        /// </summary>
        public List<Tag> Items { get; set; }
    }
}
