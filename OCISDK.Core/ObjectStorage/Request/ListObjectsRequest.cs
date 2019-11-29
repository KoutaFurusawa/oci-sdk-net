using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// ListObjects Request
    /// </summary>
    public class ListObjectsRequest
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
        /// <example>my-new-bucket1</example>
        public string BucketName { get; set; }

        /// <summary>
        /// The string to use for matching against the start of object names in a list query.
        /// <para>Required: no</para>
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Object names returned by a list query must be greater or equal to this parameter.
        /// <para>Required: no</para>
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Object names returned by a list query must be strictly less than this parameter.
        /// <para>Required: no</para>
        /// </summary>
        public string End { get; set; }

        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// When this parameter is set, only objects whose names do not contain the delimiter character 
        /// (after an optionally specified prefix) are returned in the objects key of the response body. 
        /// Scanned objects whose names contain the delimiter have the part of their name up to the first occurrence 
        /// of the delimiter (including the optional prefix) returned as a set of prefixes. 
        /// Note that only '/' is a supported delimiter character at this time.
        /// <para>Required: no</para>
        /// </summary>
        public string Delimiter { get; set; }

        /// <summary>
        /// Object summary in list of objects includes the 'name' field. This parameter can also include 
        /// 'size' (object size in bytes), 'md5', and 'timeCreated' (object creation date and time) fields. 
        /// Value of this parameter should be a comma-separated, case-insensitive list of those field names. 
        /// For example 'name,timeCreated,md5'.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Fields { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            
            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            } else
            {
                sb.Append($"&limit=100");
            }
            if (!string.IsNullOrEmpty(this.Prefix))
            {
                sb.Append($"&prefix={this.Prefix}");
            }
            if (!string.IsNullOrEmpty(this.Start))
            {
                sb.Append($"&start={this.Start}");
            }
            if (!string.IsNullOrEmpty(this.End))
            {
                sb.Append($"&end={this.End}");
            }
            if (!string.IsNullOrEmpty(this.Delimiter))
            {
                sb.Append($"&delimiter={this.Delimiter}");
            }

            if (Fields.Count > 0)
            {
                sb.Append($"&fields=");
                foreach (var f in Fields)
                {
                    sb.Append($"{f},");
                }
                sb = sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}
