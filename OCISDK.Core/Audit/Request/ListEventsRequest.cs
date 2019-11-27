﻿using System.Text;

namespace OCISDK.Core.Audit.Request
{
    /// <summary>
    /// ListEvents Request
    /// </summary>
    public class ListEventsRequest
    {
        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Returns events that were processed at or after this start date and time, expressed in RFC 3339 timestamp format.
        /// <para>For example, a start value of 2017-01-15T11:30:00Z will retrieve a list of all events processed since 30 minutes 
        /// after the 11th hour of January 15, 2017, in Coordinated Universal Time (UTC).
        /// You can specify a value with granularity to the minute. Seconds (and milliseconds, if included) must be set to 0.
        /// </para>
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>2017-01-15T11:30:00Z</example>
        public string StartTime { get; set; }

        /// <summary>
        /// Returns events that were processed at or after this start date and time, expressed in RFC 3339 timestamp format.
        /// <para>For example, a start value of 2017-01-01T00:00:00Z and an end value of 2017-01-02T00:00:00Z will retrieve a list 
        /// of all events processed on January 1, 2017. Similarly, a start value of 2017-01-01T00:00:00Z and an end value of 
        /// 2017-02-01T00:00:00Z will result in a list of all events processed between January 1, 2017 and January 31, 2017. 
        /// You can specify a value with granularity to the minute. Seconds (and milliseconds, if included) must be set to 0.
        /// </para>
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>2017-01-15T11:30:00Z</example>
        public string EndTime { get; set; }

        /// <summary>
        /// For list pagination. The value of the opc-next-page response header from the previous "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, 
        /// please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// option
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder();
            sb.Append($"compartmentId={this.CompartmentId}");
            sb.Append($"&startTime={this.StartTime}");
            sb.Append($"&endTime={this.EndTime}");

            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            return sb.ToString();
        }
    }
}
