namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// GetTenancy Request
    /// </summary>
    public class GetTenancyRequest
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string TenancyId { get; set; }
    }
}
