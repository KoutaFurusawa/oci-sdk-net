using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A policy that determines how traffic is distributed among backend servers.
    /// For more information on load balancing policies, see How Load Balancing Policies Work.
    /// </summary>
    public class LoadBalancerPolicyDetails
    {
        /// <summary>
        /// The name of a load balancing policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }
    }
}
