using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Request
{
    /// <summary>
    /// GetHealthChecker Request
    /// </summary>
    public class GetHealthCheckerRequest
    {
        /// <summary>
        /// The unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the load balancer associated with the health check policy to be retrieved.
        /// <para>Required: yes</para>
        /// </summary>
        public string LoadBalancerId { get; set; }

        /// <summary>
        /// The name of the backend set associated with the health check policy to be retrieved.
        /// <para>Required: yes</para>
        /// </summary>
        public string BackendSetName { get; set; }
    }
}
