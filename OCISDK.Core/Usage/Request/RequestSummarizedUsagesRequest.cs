using OCISDK.Core.Usage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Request
{
    /// <summary>
    /// RequestSummarizedUsages request
    /// </summary>
    public class RequestSummarizedUsagesRequest
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular 
        /// request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The page token representing the page at which to start retrieving results. This is usually 
        /// retrieved from a previous list call.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The request body must contain a single RequestSummarizedUsagesDetails resource.
        /// </summary>
        public RequestSummarizedUsagesDetails RequestSummarizedUsagesDetails { get; set; }

        /// <summary>
        /// optional value get
        /// </summary>
        /// <returns></returns>
        public string GetOptions()
        {
            string str = "";
            string chainStr = "";

            if (!string.IsNullOrEmpty(Page))
            {
                str = "page=" + Page;
                chainStr = "&";
            }

            if (Limit.HasValue)
            {
                str = str + chainStr + "limit=" + Limit.Value;
            }

            return str;
        }
    }
}
