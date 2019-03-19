/// <summary>
/// ListAvailabilityDomains Request
/// 
/// author: koutaro furusawa
/// </summary>
namespace OCISDK.Core.src.Identity.Request
{
    public class ListAvailabilityDomainsRequest
    {
        /// <summary>
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// <para>Max Length: 255</para>>
        /// </summary>
        public string CompartmentId { get; set; }

        public string GetOptionQuery()
        {
            return $"compartmentId={this.CompartmentId}";
        }
    }
}
