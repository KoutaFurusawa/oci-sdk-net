using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A shape is a template that determines the total pre-provisioned bandwidth (ingress plus egress) for the load balancer.
    /// 
    /// Note that the pre-provisioned maximum capacity applies to aggregated connections, not to a single client attempting to use the full bandwidth.
    /// </summary>
    public class LoadBalancerShapeDetails
    {
        /// <summary>
        /// The name of the shape.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }
    }
}
