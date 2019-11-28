
namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListRegionSubscriptions Request
    /// </summary>
    public class ListRegionSubscriptionsRequest
    {
        /// <summary>
        /// The OCID of the tenancy.
        /// <para>Required: yes</para>
        /// </summary>
        public string TenancyId { get; set; }
    }
}
