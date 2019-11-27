namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// DeleteSecurityList Request
    /// </summary>
    public class DeleteSecurityListRequest
    {
        /// <summary>
        /// The OCID of the security list.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string SecurityListId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}
