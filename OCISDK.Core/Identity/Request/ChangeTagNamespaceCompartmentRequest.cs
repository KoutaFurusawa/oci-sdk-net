using OCISDK.Core.Identity.Model;
namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ChangeTagNamespaceCompartmentDetail Request
    /// </summary>
    public class ChangeTagNamespaceCompartmentRequest
    {
        /// <summary>
        /// The OCID of the tag namespace.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 100</para>
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
        /// The request body must contain a single ChangeTagNamespaceCompartmentDetail resource.
        /// </summary>
        public ChangeTagNamespaceCompartmentDetail ChangeTagNamespaceCompartmentDetail { get; set; }
    }
}
