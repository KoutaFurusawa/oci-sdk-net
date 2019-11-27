using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Response
{
    /// <summary>
    /// ChangeLoadBalancerCompartment Response
    /// </summary>
    public class ChangeLoadBalancerCompartmentResponse
    {
        /// <summary>
        /// The OCID of the work request.
        /// </summary>
        public string OpcWorkRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}
