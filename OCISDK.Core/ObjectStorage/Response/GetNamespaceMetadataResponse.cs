using OCISDK.Core.ObjectStorage.Model;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// GetNamespaceMetadata Response
    /// </summary>
    public class GetNamespaceMetadataResponse
    {
        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single NamespaceMetadata resource.
        /// </summary>
        public NamespaceMetadata NamespaceMetadata { get; set; }
    }
}
