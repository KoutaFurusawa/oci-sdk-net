using OCISDK.Core.Core.Model.VirtualNetwork;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// CreateVcnRequest
    /// </summary>
    public class CreateVcnRequest
    {
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
        /// CreateVcn
        /// </summary>
        public CreateVcnDetails CreateVcnDetails { get; set; }
    }
}
