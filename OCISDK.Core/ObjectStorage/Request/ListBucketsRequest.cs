using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// ListBuckets Request
    /// </summary>
    public class ListBucketsRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The ID of the compartment in which to list buckets.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The page at which to start retrieving results.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Bucket summary includes the 'namespace', 'name', 'compartmentId', 'createdBy', 'timeCreated', and 'etag' fields. 
        /// This parameter can also include 'approximateCount' (approximate number of objects) and 'approximateSize' 
        /// (total approximate size in bytes of all objects). For example 'approximateCount,approximateSize'.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Fields { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append($"&compartmentId={this.CompartmentId}");

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }
            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }
            if (Fields != null)
            {
                Fields.ForEach(f => {
                    sb.Append($"&fields[]={f}");
                });
            }

            return sb.ToString();
        }
    }
}
