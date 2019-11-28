namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListAvailabilityDomains Request
    /// </summary>
    public class ListAvailabilityDomainsRequest
    {
        /// <summary>
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            return $"compartmentId={this.CompartmentId}";
        }
    }
}
