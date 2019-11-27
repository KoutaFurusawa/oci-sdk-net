using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Request
{
    /// <summary>
    /// GetBackend Request
    /// </summary>
    public class GetBackendRequest
    {
        /// <summary>
        /// The unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the load balancer associated with the backend set and servers.
        /// <para>Required: yes</para>
        /// </summary>
        public string LoadBalancerId { get; set; }

        /// <summary>
        /// The name of the backend set associated with the backend servers.
        /// <para>Required: yes</para>
        /// </summary>
        public string BackendSetName { get; set; }

        /// <summary>
        /// The IP address and port of the backend server to retrieve.
        /// <para>Required: yes</para>
        /// </summary>
        public string BackendName { get; set; }
    }
}
