namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// GetDhcp Request
    /// </summary>
    public class GetDhcpRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DhcpId { get; set; }
    }
}
