using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// Represents the load balancer Backend that is configured for an instance pool instance.
    /// </summary>
    public class InstancePoolInstanceLoadBalancerBackend
    {
        /// <summary>
        /// The OCID of the load balancer attached to the instance pool.
        /// <para>Required: yes</para>
        /// </summary>
        public string LoadBalancerId { get; set; }

        /// <summary>
        /// The name of the backend set on the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string BackendSetName { get; set; }

        /// <summary>
        /// The name of the backend in the backend set.
        /// <para>Required: yes</para>
        /// </summary>
        public string BackendName { get; set; }

        /// <summary>
        /// The health of the backend as observed by the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string BackendHealthStatus { get; set; }
    }
}
