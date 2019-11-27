using OCISDK.Core.ObjectStorage.Model;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// ListObjects Response
    /// </summary>
    public class ListObjectsResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single ListObjects resource.
        /// </summary>
        public ListObjectDetails ListObjects { get; set; }
    }
}
