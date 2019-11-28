using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Request
{
    /// <summary>
    /// ListWorkRequests Request
    /// </summary>
    public class ListWorkRequestsRequest
    {
        /// <summary>
        /// The unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The maximum number of items to return per page.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The pagination token to continue listing from.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The OCID of the load balancer associated with the work requests to retrieve.
        /// <para>Required: yes</para>
        /// </summary>
        public string LoadBalancerId { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            var chainStr = "";
            
            if (this.Limit.HasValue)
            {
                sb.Append($"limit={this.Limit.Value}");
                chainStr = "&";
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"{chainStr}page={this.Page}");
            }

            return sb.ToString();
        }
    }
}
