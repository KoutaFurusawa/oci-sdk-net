namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// AvailabilityDomain Reference
    /// One or more isolated, fault-tolerant Oracle data centers that host cloud resources such as instances, 
    /// volumes, and subnets. A region contains several Availability Domains. For more information, see Regions 
    /// and Availability Domains.
    /// </summary>
    public class AvailabilityDomain
    {
        /// <summary>
        /// The OCID of the Availability Domain.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the tenancy.
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the Availability Domain.
        /// </summary>
        public string Name { get; set; }
    }
}
