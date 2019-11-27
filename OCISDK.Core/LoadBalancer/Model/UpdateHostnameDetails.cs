using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The configuration details for updating a virtual hostname.
    /// For more information on virtual hostnames, see Managing Request Routing.
    /// </summary>
    public class UpdateHostnameDetails
    {
        /// <summary>
        /// The virtual hostname to update. For more information about virtual hostname string construction, see Managing Request Routing.
        /// <para>Required: no</para>
        /// </summary>
        public string Hostname { get; set; }
    }
}
