using OCISDK.Core.LoadBalancer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Response
{
    /// <summary>
    /// ListLoadBalancerHealths Response
    /// </summary>
    public class ListLoadBalancerHealthsResponse
    {
        /// <summary>
        /// For list pagination. When this header appears in the response, additional pages of results remain.
        /// For important details about how pagination works, see List Pagination.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain an array of LoadBalancerHealthSummary resources.
        /// </summary>
        public List<LoadBalancerHealthSummary> Items { get; set; }
    }
}
