using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Request
{
    /// <summary>
    /// GetAlarmHistory Request
    /// </summary>
    public class GetAlarmHistoryRequest
    {
        /// <summary>
        /// Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of an alarm.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AlarmId { get; set; }

        /// <summary>
        /// The type of history entries to retrieve. 
        /// State history (STATE_HISTORY) or state transition history (STATE_TRANSITION_HISTORY). 
        /// If not specified, entries of both types are retrieved.
        /// <para>Required: no</para>
        /// </summary>
        public string AlarmHistorytype { get; set; }

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
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// A filter to return only alarm history entries with timestamps occurring on or after the specified date and time. Format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimestampGreaterThanOrEqualTo { get; set; }

        /// <summary>
        /// A filter to return only alarm history entries with timestamps occurring before the specified date and time. Format defined by RFC3339.
        /// <para>Required: no</para>
        /// </summary>
        public string TimestampLessThan { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder();
            var chainC = "";
            
            if (!string.IsNullOrEmpty(this.AlarmHistorytype))
            {
                sb.Append($"{chainC}alarmHistorytype={this.AlarmHistorytype}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(this.TimestampGreaterThanOrEqualTo))
            {
                sb.Append($"{chainC}timestampGreaterThanOrEqualTo={this.TimestampGreaterThanOrEqualTo}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(this.TimestampLessThan))
            {
                sb.Append($"{chainC}timestampLessThan={this.TimestampLessThan}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"{chainC}page={this.Page}");
                chainC = "&";
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"{chainC}limit={this.Limit.Value}");
            }

            return sb.ToString();
        }
    }
}
