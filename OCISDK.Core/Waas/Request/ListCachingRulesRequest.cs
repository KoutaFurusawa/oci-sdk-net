using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Request
{
    /// <summary>
    /// ListCachingRules request
    /// </summary>
    public class ListCachingRulesRequest
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
        /// The maximum number of items to return in a paginated call. In unspecified, defaults to 20.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The value of the opc-next-page response header from the previous paginated call.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }
        
        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder();
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
            
            return sb.ToString();
        }
    }
}
