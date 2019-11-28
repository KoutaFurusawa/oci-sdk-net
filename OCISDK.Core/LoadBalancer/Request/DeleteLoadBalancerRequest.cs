using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Request
{
    /// <summary>
    /// DeleteLoadBalancer Request
    /// </summary>
    public class DeleteLoadBalancerRequest
    {
        /// <summary>
        /// The unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the load balancer to delete.
        /// <para>Required: yes</para>
        /// </summary>
        public string LoadBalancerId { get; set; }
    }
}
