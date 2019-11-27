using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The configuration details for updating a backend server.
    /// </summary>
    public class UpdateBackendDetails
    {
        /// <summary>
        /// The load balancing policy weight assigned to the server. 
        /// Backend servers with a higher weight receive a larger proportion of incoming traffic. 
        /// For example, a server weighted '3' receives 3 times the number of new connections as a server weighted '1'. 
        /// For more information on load balancing policies, see How Load Balancing Policies Work.
        /// <para>Required: yes</para>
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Whether the load balancer should treat this server as a backup unit. 
        /// If true, the load balancer forwards no ingress traffic to this backend server unless all other backend servers not marked as "backup" fail the health check policy.
        /// 
        /// Note: You cannot add a backend server marked as backup to a backend set that uses the IP Hash policy.
        /// <para>Required: yes</para>
        /// </summary>
        public bool Backup { get; set; }

        /// <summary>
        /// Whether the load balancer should drain this server. Servers marked "drain" receive no new incoming traffic.
        /// <para>Required: yes</para>
        /// </summary>
        public bool Drain { get; set; }

        /// <summary>
        /// Whether the load balancer should treat this server as offline. Offline servers receive no incoming traffic.
        /// <para>Required: yes</para>
        /// </summary>
        public bool Offline { get; set; }
    }
}
