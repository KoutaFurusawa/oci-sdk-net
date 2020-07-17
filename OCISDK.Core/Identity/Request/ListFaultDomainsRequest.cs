using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListFaultDomains request
    /// </summary>
    public class ListFaultDomainsRequest
    {
        /// <summary>
        /// The OCID of the compartment (remember that the tenancy is simply the root compartment).
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the availibilityDomain.
        /// <para>Required: yes</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }
    }
}
