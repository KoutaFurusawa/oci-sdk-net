using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// UpdateTag Request
    /// </summary>
    public class UpdateTagRequest
    {
        /// <summary>
        /// The OCID of the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 100</para>
        /// </summary>
        public string TagNamespaceId { get; set; }

        /// <summary>
        /// The name of the tag.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 100</para>
        /// </summary>
        public string TagName { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateTagDetails resource.
        /// </summary>
        public UpdateTagDetails UpdateTagDetails { get; set; }
    }
}
