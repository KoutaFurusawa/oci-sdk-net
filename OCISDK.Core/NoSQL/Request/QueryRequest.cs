using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.NoSQL.Model;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// Query request
    /// </summary>
    public class QueryRequest
    {
        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// <para>Default: 1000</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.
        /// <para>Required: no</para>
        /// <para>Default: null</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single QueryDetails resource.
        /// </summary>
        public QueryDetails QueryDetails { get; set; }

        /// <summary>
        /// request optional query get.
        /// </summary>
        /// <returns></returns>
        public string GetOptionalQuery()
        {
            StringBuilder sb = new StringBuilder();
            string chainC = "";

            if (Limit.HasValue)
            {
                sb.Append($"limit={Limit}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(Page))
            {
                sb.Append($"{chainC}page={Page}");
            }

            return sb.ToString();
        }
    }
}
