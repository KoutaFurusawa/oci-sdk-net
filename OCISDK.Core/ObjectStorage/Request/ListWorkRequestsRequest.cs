using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// ListWorkRequests request
    /// </summary>
    public class ListWorkRequestsRequest
    {
        /// <summary>
        /// The ID of the compartment in which to list buckets.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// bukcet name
        /// </summary>
        public string BucketName { get; set; }

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
            StringBuilder sb = new StringBuilder($"compartmentId={CompartmentId}");

            if (Limit.HasValue)
            {
                sb = sb.Append($"&limit={Limit.Value}");
            }

            if (!string.IsNullOrEmpty(Page))
            {
                sb = sb.Append($"&page={Page}");
            }

            if (!string.IsNullOrEmpty(BucketName))
            {
                sb = sb.Append($"&bucketName={BucketName}");
            }

            return sb.ToString();
        }
    }
}
