using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// DeleteRow request
    /// </summary>
    public class DeleteRowRequest
    {
        /// <summary>
        /// A table name within the compartment, or a table OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string TableNameOrId { get; set; }

        /// <summary>
        /// The ID of a table's compartment. When a table is identified by name, the compartmentId is often needed to provide context for interpreting the name.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// An array of strings, each of the format "column-name:value", representing the primary key of the row.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> Key { get; set; }

        /// <summary>
        /// If true, and the operation fails due to an option setting (ifVersion et al), then the existing row will be returned.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsGetReturnRow { get; set; }

        /// <summary>
        /// Timeout setting for this operation.
        /// <para>Required: no</para>
        /// <para>Default: 5000</para>
        /// </summary>
        public int? TimeoutInMs { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a previous 
        /// GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// request optional query get.
        /// </summary>
        /// <returns></returns>
        public string GetOptionalQuery()
        {
            StringBuilder sb = new StringBuilder();

            var chainC = "";
            foreach (var k in Key)
            {
                sb.Append($"{chainC}key[]={k}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(CompartmentId))
            {
                sb.Append($"&compartmentId={CompartmentId}");
            }

            if (IsGetReturnRow.HasValue)
            {
                sb.Append($"&isGetReturnRow={IsGetReturnRow.Value}");
            }

            if (TimeoutInMs.HasValue)
            {
                sb.Append($"&timeoutInMs={TimeoutInMs.Value}");
            }

            return sb.ToString();
        }
    }
}
