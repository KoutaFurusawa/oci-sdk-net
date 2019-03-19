/// <summary>
/// ListDhcpResponse class
/// 
/// author: koutaro furusawa
/// </summary>

using OCISDK.Core.src.Core.Model.VirtualNetwork;
using System.Collections.Generic;

namespace OCISDK.Core.src.Core.Response.VirtualNetwork
{
    public class ListDhcpResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// For list pagination.
        /// When this header appears in the response, additional pages of results remain.
        /// For important details about how pagination works
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// A list of Vcn instances.
        /// </summary>
        public List<DhcpOptions> Items { get; set; }
    }
}
