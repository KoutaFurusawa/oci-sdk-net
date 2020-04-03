using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// ListWorkRequestErrors request
    /// </summary>
    public class ListWorkRequestErrorsRequest
    {
        /// <summary>
        /// The page at which to start retrieving results.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The ID of the asynchronous request.
        /// <para>Required: yes</para>
        /// </summary>
        public string WorkRequestId { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// get optional
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            string chainStr = "";

            if (Limit.HasValue)
            {
                sb = sb.Append($"{chainStr}limit={Limit.Value}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(Page))
            {
                sb = sb.Append($"{chainStr}page={Page}");
            }

            return sb.ToString();
        }
    }
}
