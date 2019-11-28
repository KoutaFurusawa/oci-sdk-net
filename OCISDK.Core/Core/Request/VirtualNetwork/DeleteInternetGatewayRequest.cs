namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// DeleteInternetGateway Request
    /// </summary>
    public class DeleteInternetGatewayRequest
    {
        /// <summary>
        /// The OCID of the internet gateway.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string IgId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}
