using OCISDK.Core.Core.Model.Compute;

namespace OCISDK.Core.Core.Response.Compute
{
    /// <summary>
    /// GetInstanceDefaultCredentials Response
    /// </summary>
    public class GetInstanceDefaultCredentialsResponse
    {
        /// <summary>
        /// The response body will contain a single InstanceCredentials resource.
        /// </summary>
        public InstanceCredentialsDetails InstanceCredentialsDetails { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}
