/// <summary>
/// DeleteCompartment Response
/// 
/// author: koutaro furusawa
/// </summary>

namespace OCISDK.Core.src.Identity.Response
{
    public class DeleteCompartmentResponse
    {
        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the work request.
        /// </summary>
        public string opcWorkRequestId { get; set; }
    }
}
