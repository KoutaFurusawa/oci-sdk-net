namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// DeleteCompartment Response
    /// </summary>
    public class DeleteCompartmentResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the work request.
        /// </summary>
        public string OpcWorkRequestId { get; set; }
    }
}
