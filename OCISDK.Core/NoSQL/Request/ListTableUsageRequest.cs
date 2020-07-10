using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// ListTableUsage request
    /// </summary>
    public class ListTableUsageRequest
    {
        /// <summary>
        /// A table name within the compartment, or a table OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string TableNameOrId { get; set; }

        /// <summary>
        /// The ID of a table's compartment.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The start time to use for the request. If no time range is set for this request, the most recent complete usage record is returned.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeStart { get; set; }

        /// <summary>
        /// The end time to use for the request.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeEnd { get; set; }

        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// request optional query get.
        /// </summary>
        /// <returns></returns>
        public string GetOptionalQuery()
        {
            StringBuilder sb = new StringBuilder();
            string chainC = "";

            if (!string.IsNullOrEmpty(CompartmentId))
            {
                sb.Append($"compartmentId={CompartmentId}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(TimeStart))
            {
                sb.Append($"{chainC}timeStart={TimeStart}");
            }

            if (!string.IsNullOrEmpty(TimeEnd))
            {
                sb.Append($"{chainC}timeEnd={TimeEnd}");
            }

            if (Limit.HasValue)
            {
                sb.Append($"{chainC}limit={Limit.Value}");
            }

            if (!string.IsNullOrEmpty(Page))
            {
                sb.Append($"{chainC}page={Page}");
            }

            return sb.ToString();
        }
    }
}
