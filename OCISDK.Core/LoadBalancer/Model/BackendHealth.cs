using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The health status of the specified backend server as reported by the primary and standby load balancers.
    /// </summary>
    public class BackendHealth
    {
        /// <summary>
        /// The general health status of the specified backend server as reported by the primary and standby load balancers.
        /// <para>Required: yes</para>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// A list of the most recent health check results returned for the specified backend server.
        /// <para>Required: yes</para>
        /// </summary>
        public List<HealthCheckResult> HealthCheckResults { get; set; }
    }
}
