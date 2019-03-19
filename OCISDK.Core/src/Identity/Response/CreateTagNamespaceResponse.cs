/// <summary>
/// CreateTagNamespace Response
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Identity.Model;

namespace OCISDK.Core.src.Identity.Response
{
    public class CreateTagNamespaceResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, 
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single TagNamespace resource.
        /// </summary>
        public TagNamespace TagNamespace { get; set; }
    }
}
