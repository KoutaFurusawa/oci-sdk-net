using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace OCISDK.Core.UnpublishedService.UsageCosts.Request
{
    /// <summary>
    /// ListUsageCosts Request
    /// </summary>
    public class ListUsageCostsRequest
    {
        /// <summary>
        /// opc-request-id
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// TenantId
        /// <para>Required: yes</para>
        /// </summary>
        public string TenancyId { get; set; }

        /// <summary>
        /// compartmentId
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// startTime
        /// <para>Required: yes</para>
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// endTime
        /// <para>Required: yes</para>
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// granularity
        /// <para>Required: yes</para>
        /// <para>HOURLY, DAILY</para>
        /// </summary>
        public string Granularity { get; set; }

        /// <summary>
        /// tag
        /// <para>Required: no</para>
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// optional
        /// </summary>
        /// <returns></returns>
        public string GetOptionalQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"startTime={Uri.EscapeDataString(StartTime)}");

            sb.Append($"&endTime={Uri.EscapeDataString(EndTime)}");

            sb.Append($"&granularity={Granularity}");

            if (!string.IsNullOrEmpty(CompartmentId))
            {
                sb.Append($"&compartmentId={CompartmentId}");
            }

            if (!string.IsNullOrEmpty(Tag))
            {
                sb.Append($"&tag={Uri.EscapeDataString(Tag)}");
            }

            return sb.ToString();
        }
    }
}
