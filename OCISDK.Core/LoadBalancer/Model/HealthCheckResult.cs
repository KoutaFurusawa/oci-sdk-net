using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// Information about a single backend server health check result reported by a load balancer.
    /// </summary>
    public class HealthCheckResult
    {
        /// <summary>
        /// The OCID of the subnet hosting the load balancer that reported this health check status.
        /// <para>Required: yes</para>
        /// </summary>
        public string SubnetId { get; set; }

        /// <summary>
        /// The IP address of the health check status report provider.
        /// This identifier helps you differentiate same-subnet load balancers that report health check status.
        /// <para>Required: yes</para>
        /// </summary>
        public string SourceIpAddress { get; set; }

        /// <summary>
        /// The date and time the data was retrieved, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// The result of the most recent health check.
        /// <para>Required: yes</para>
        /// </summary>
        public string HealthCheckStatus { get; set; }
    }
}
