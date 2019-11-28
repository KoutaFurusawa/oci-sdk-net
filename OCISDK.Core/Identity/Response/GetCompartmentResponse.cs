using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// GetCompartment Response
    /// </summary>
    public class GetCompartmentResponse
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
        public Compartment Compartment { get; set; } 
    }
}
