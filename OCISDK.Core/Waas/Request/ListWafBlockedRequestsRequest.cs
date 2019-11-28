using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Request
{
    /// <summary>
    /// ListWafBlockedRequests request
    /// </summary>
    public class ListWafBlockedRequestsRequest
    {
        /// <summary>
        /// The unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the WAAS policy.
        /// <para>Required: yes</para>
        /// </summary>
        public string WaasPolicyId { get; set; }

        /// <summary>
        /// A filter that limits returned events to those occurring on or after a date and time, specified in RFC 3339 format. 
        /// If unspecified, defaults to 30 minutes before receipt of the request.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeObservedGreaterThanOrEqualTo { get; set; }

        /// <summary>
        /// A filter that limits returned events to those occurring before a date and time, specified in RFC 3339 format.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeObservedLessThan { get; set; }

        /// <summary>
        /// The maximum number of items to return in a paginated call. In unspecified, defaults to 10.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The value of the opc-next-page response header from the previous paginated call.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// Filter stats by the Web Application Firewall feature that triggered the block action. 
        /// If unspecified, data for all WAF features will be returned.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> WafFeature { get; set; }

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
                sb.Append($"limit={this.Limit.Value}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"{chainStr}page={this.Page}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.TimeObservedGreaterThanOrEqualTo))
            {
                sb.Append($"{chainStr}timeObservedGreaterThanOrEqualTo={this.TimeObservedGreaterThanOrEqualTo}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.TimeObservedLessThan))
            {
                sb.Append($"{chainStr}timeObservedLessThan={this.TimeObservedLessThan}");
                chainStr = "&";
            }

            if (WafFeature.Count > 0)
            {
                if (WafFeature.Count == 1)
                {
                    sb.Append($"{chainStr}wafFeature={WafFeature[0]}");
                    chainStr = "&";
                }
                else
                {
                    foreach (var i in WafFeature)
                    {
                        sb.Append($"{chainStr}wafFeature[]={i}");
                        chainStr = "&";
                    }
                }
            }
            
            return sb.ToString();
        }
    }
}
