using OCISDK.Core.Core.Model.VirtualNetwork;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// UpdateDhcpOptions Request
    /// </summary>
    public class UpdateDhcpOptionsRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DhcpId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateDhcpDetails resource.
        /// </summary>
        public UpdateDhcpDetails UpdateDhcpDetails { get; set; }
    }
}
