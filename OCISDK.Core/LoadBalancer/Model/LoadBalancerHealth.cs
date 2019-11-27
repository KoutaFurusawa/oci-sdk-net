using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The health status details for the specified load balancer.
    /// 
    /// This object does not explicitly enumerate backend sets with a status of OK. However, they are included in the totalBackendSetCount sum.
    /// </summary>
    public class LoadBalancerHealth
    {
        /// <summary>
        /// The overall health status of the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// A list of backend sets that are currently in the WARNING health state. 
        /// The list identifies each backend set by the friendly name you assigned when you created it.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> WarningStateBackendSetNames { get; set; }

        /// <summary>
        /// A list of backend sets that are currently in the CRITICAL health state. 
        /// The list identifies each backend set by the friendly name you assigned when you created it.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> CriticalStateBackendSetNames { get; set; }

        /// <summary>
        /// A list of backend sets that are currently in the UNKNOWN health state.
        /// The list identifies each backend set by the friendly name you assigned when you created it.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> UnknownStateBackendSetNames { get; set; }

        /// <summary>
        /// The total number of backend sets associated with this load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public int TotalBackendSetCount { get; set; }
    }
}
