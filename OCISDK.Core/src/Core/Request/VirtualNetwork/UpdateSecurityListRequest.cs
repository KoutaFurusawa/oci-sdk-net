using OCISDK.Core.src.Core.Model.VirtualNetwork;

namespace OCISDK.Core.src.Core.Request.VirtualNetwork
{
    /// <summary>
    /// UpdateSecurityList Request
    /// </summary>
    public class UpdateSecurityListRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string SecurityListId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateSecurityListDetails resource.
        /// </summary>
        public UpdateSecurityListDetails UpdateSecurityListDetails { get; set; }
    }
}
