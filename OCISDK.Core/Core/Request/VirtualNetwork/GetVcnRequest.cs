namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// GetVcn Request
    /// </summary>
    public class GetVcnRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VcnId { get; set; }
    }
}
