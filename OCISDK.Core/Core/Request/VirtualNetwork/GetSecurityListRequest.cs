namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// GetSecurityList Request
    /// </summary>
    public class GetSecurityListRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string SecurityListId { get; set; }
    }
}
