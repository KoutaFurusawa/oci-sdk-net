using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.WorkRequest
{
    /// <summary>
    /// ListWorkRequestLogs Request
    /// </summary>
    public class ListWorkRequestLogsRequest
    {
        /// <summary>
        /// The OCID of the work request.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string WorkRequestId { get; set; }

        /// <summary>
        /// For list pagination. The maximum number of results per page, or items to return in a paginated "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// For list pagination. The value of the opc-next-page response header from the previous "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
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

            string ch = "";
            
            if (this.Limit.HasValue)
            {
                sb.Append($"{ch}limit={this.Limit.Value}");
                ch = "&";
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"{ch}page={this.Page}");
                ch = "&";
            }

            if (!(SortOrder is null))
            {
                sb.Append($"{ch}sortOrder={SortOrder.Value}");
            }

            return sb.ToString();
        }
    }
}
