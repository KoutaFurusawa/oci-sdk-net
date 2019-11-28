using OCISDK.Core.Identity.Model;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// Creates a new tag in the specified tag namespace.
    /// You must specify either the OCID or the name of the tag namespace that will contain this tag definition.
    /// You must also specify a name for the tag, which must be unique across all tags in the tag namespace and cannot 
    /// be changed. The name can contain any ASCII character except the space (_) or period (.) characters. 
    /// Names are case insensitive. That means, for example, "myTag" and "mytag" are not allowed in the same namespace. 
    /// If you specify a name that's already in use in the tag namespace, a 409 error is returned.
    /// You must also specify a description for the tag.It does not have to be unique, and you can change it with UpdateTag.
    /// </summary>
    /// <example>
    /// {
    ///     "name" : "CostCenter",
    ///     "description" : "This tag will show the cost center that will be used for billing of associated resources.",
    ///     "type" : "string"
    /// }</example>
    public class CreateTagRequest
    {
        /// <summary>
        /// The OCID of the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 100</para>
        /// </summary>
        public string TagNamespaceId { get; set; }

        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a 
        /// timeout or server error without risk of executing that same action again. 
        /// Retry tokens expire after 24 hours, but can be invalidated before then due to 
        /// conflicting operations (for example, if a resource has been deleted and purged 
        /// from the system, then a retry of the original creation request may be rejected).
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 64</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// The request body must contain a single CreateTagDetails resource.
        /// </summary>
        public CreateTagDetails CreateTagDetails { get; set; }
    }
}
