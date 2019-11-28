using OCISDK.Core.Core.Model.Compute;

namespace OCISDK.Core.Core.Response.Compute
{
    /// <summary>
    /// LaunchInstance Response
    /// </summary>
    public class LaunchInstanceResponse
    {
        /// <summary>
        /// response header parameter ETag
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the work request. Use GetWorkRequest with this ID to track the status of the request.
        /// </summary>
        public string OpcWorkRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single Instance resource.
        /// </summary>
        public Instance Instance { get; set; }
    }
}
