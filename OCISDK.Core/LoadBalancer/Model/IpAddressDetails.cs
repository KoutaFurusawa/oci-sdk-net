using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A load balancer IP address.
    /// </summary>
    public class IpAddressDetails
    {
        /// <summary>
        /// An IP address.
        /// <para>Required: yes</para>
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Whether the IP address is public or private.
        /// If "true", the IP address is public and accessible from the internet.
        /// If "false", the IP address is private and accessible only from within the associated VCN.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsPublic { get; set; }
    }
}
