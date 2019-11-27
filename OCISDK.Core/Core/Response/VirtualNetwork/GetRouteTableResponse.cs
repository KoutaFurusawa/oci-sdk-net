using OCISDK.Core.Core.Model.VirtualNetwork;

namespace OCISDK.Core.Core.Response.VirtualNetwork
{
    /// <summary>
    /// GetRouteTable Response
    /// </summary>
    public class GetRouteTableResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a RouteTable resource.
        /// </summary>
        public RouteTable RouteTable { get; set; }
    }
}
