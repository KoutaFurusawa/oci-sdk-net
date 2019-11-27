using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// UpdateTagNamespace Request
    /// </summary>
    public class UpdateTagNamespaceRequest
    {
        /// <summary>
        /// The OCID of the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 100</para>
        /// </summary>
        public string TagNamespaceId { get; set; }


        /// <summary>
        /// The request body must contain a single UpdateTagNamespaceDetails resource.
        /// </summary>
        public UpdateTagNamespaceDetails UpdateTagNamespaceDetails { get; set; }
    }
}
