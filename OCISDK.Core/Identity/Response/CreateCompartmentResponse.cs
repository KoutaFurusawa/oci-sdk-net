using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// CreateCompartment Response
    /// </summary>
    public class CreateCompartmentResponse
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
        /// The response body will contain a single Compartment resource.
        /// </summary>
        public Compartment Compartment { get; set; }
    }
}
