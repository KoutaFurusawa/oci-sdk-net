using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A health status summary for the specified load balancer.
    /// </summary>
    public class LoadBalancerHealthSummary
    {
        /// <summary>
        /// The OCID of the load balancer the health status is associated with.
        /// <para>Required: yes</para>
        /// </summary>
        public string LoadBalancerId { get; set; }

        /// <summary>
        /// The overall health status of the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string Status { get; set; }
    }
}
