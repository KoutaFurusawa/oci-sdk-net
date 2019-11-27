using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// GetTenancy Response
    /// </summary>
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
