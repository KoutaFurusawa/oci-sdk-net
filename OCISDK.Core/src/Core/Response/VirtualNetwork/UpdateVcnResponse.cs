
using OCISDK.Core.src.Core.Model.VirtualNetwork;

namespace OCISDK.Core.src.Core.Response.VirtualNetwork
{
    /// <summary>
    /// UpdateVcn Response
    /// </summary>
    public class UpdateVcnResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Vcn instances.
        /// </summary>
        public Vcn Vcn { get; set; }
    }
}
