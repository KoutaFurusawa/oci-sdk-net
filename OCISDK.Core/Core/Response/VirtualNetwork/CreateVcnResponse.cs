using OCISDK.Core.Core.Model.VirtualNetwork;

namespace OCISDK.Core.Core.Response.VirtualNetwork
{
    /// <summary>
    /// CreateVcn Response
    /// </summary>
    public class CreateVcnResponse
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
        /// Vcn instances.
        /// </summary>
        public Vcn Vcn { get; set; }
    }
}
