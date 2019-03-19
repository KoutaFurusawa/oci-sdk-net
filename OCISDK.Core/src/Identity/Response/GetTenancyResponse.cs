/// <summary>
/// GetTenancy Response
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Identity.Model;

namespace OCISDK.Core.src.Identity.Response
{
    public class GetTenancyResponse
    {
        /// <summary>
        /// response header parameter ETag
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// single Compartment resource.
        /// </summary>
        public Tenancy Tenancy { get; set; } 
    }
}
