using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.VirtualNetwork
{
    /// <summary>
    /// ListCpeDeviceShapes request
    /// </summary>
    public class ListCpeDeviceShapesRequest
    {
        /// <summary>
        /// For list pagination. The maximum number of results per page, or items to return in a paginated "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// For list pagination. The value of the opc-next-page response header from the previous "List" call.
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            string chainStr = "";

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={Limit.Value}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(Page))
            {
                sb.Append($"{chainStr}page={Page}");
            }

            return sb.ToString();
        }
    }
}
