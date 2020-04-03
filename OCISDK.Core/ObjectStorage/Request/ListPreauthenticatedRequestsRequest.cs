using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// ListPreauthenticatedRequests request
    /// </summary>
    public class ListPreauthenticatedRequestsRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The name of the bucket. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// User-specified object name prefixes can be used to query and return a list of pre-authenticated requests.
        /// <para>Required: no</para>
        /// </summary>
        public string ObjectNamePrefix { get; set; }

        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The page at which to start retrieving results.
        /// <para>Required: no</para>
        /// </summary>
        public string Page { get; set; }

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

            if (!string.IsNullOrEmpty(ObjectNamePrefix))
            {
                sb = sb.Append($"objectNamePrefix={ObjectNamePrefix}");
                chainStr = "&";
            }

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
