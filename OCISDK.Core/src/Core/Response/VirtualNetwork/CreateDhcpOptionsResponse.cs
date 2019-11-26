using OCISDK.Core.src.Core.Model.VirtualNetwork;

namespace OCISDK.Core.src.Core.Response.VirtualNetwork
{
    /// <summary>
    /// CreateDhcpOptions Response
    /// </summary>
    public class CreateDhcpOptionsResponse
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
        /// The response body will contain a single DhcpOptions resource.
        /// </summary>
        public DhcpOptions DhcpOptions { get; set; }
    }
}
