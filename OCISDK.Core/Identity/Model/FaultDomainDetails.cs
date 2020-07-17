using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// A Fault Domain is a logical grouping of hardware and infrastructure within an Availability Domain that can become 
    /// unavailable in its entirety either due to hardware failure such as Top-of-rack (TOR) switch failure or due to planned 
    /// software maintenance such as security updates that reboot your instances.
    /// </summary>
    public class FaultDomainDetails
    {
        /// <summary>
        /// The name of the availabilityDomain where the Fault Domain belongs.
        /// <para>Required: no</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The OCID of the compartment. Currently only tenancy (root) compartment can be provided.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The OCID of the Fault Domain.
        /// <para>Required: no</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the Fault Domain.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }
    }
}
