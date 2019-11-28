namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// DeleteDhcpOptions Request
    /// </summary>
    public class DeleteDhcpOptionsRequest
    {
        /// <summary>
        /// The OCID for the set of DHCP options.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DhcpId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}
