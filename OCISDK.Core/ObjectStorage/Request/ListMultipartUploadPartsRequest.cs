using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// ListMultipartUploadParts request
    /// </summary>
    public class ListMultipartUploadPartsRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The name of the bucket. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// The name of the object. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string ObjectName { get; set; }

        /// <summary>
        /// The upload ID for a multipart upload.
        /// <para>Required: yes</para>
        /// </summary>
        public string UploadId { get; set; }

        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The page at which to start retrieving results.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1024</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// create optional query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"uploadId={UploadId}");

            if(Limit.HasValue)
            {
                sb.Append($"&limit={Limit.Value}");
            }

            if(!string.IsNullOrEmpty(Page))
            {
                sb.Append($"&page={Page}");
            }

            return sb.ToString();
        }
    }
}
