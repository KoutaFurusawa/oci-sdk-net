using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// GetTagNamespace Response
    /// </summary>
    public class GetTagNamespaceResponse
    {
        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// single Compartment resource.
        /// </summary>
        public TagNamespace TagNamespace { get; set; }
    }
}
