using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// DeleteIndex request
    /// </summary>
    public class DeleteIndexRequest
    {
        /// <summary>
        /// A table name within the compartment, or a table OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string TableNameOrId { get; set; }

        /// <summary>
        /// The name of a table's index.
        /// <para>Required: yes</para>
        /// </summary>
        public string IndexName { get; set; }

        /// <summary>
        /// The ID of a table's compartment. When a table is identified by name, the compartmentId is often needed to provide context for interpreting the name.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Set as true to select "if exists" behavior.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsIfExists { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a previous GET or POST response for that resource. 
        /// The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.
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
            string chainC = "";

            if (!string.IsNullOrEmpty(CompartmentId))
            {
                sb.Append($"compartmentId={CompartmentId}");
                chainC = "&";
            }

            if (IsIfExists.HasValue)
            {
                sb.Append($"{chainC}isIfExists={IsIfExists.Value}");
            }

            return sb.ToString();
        }
    }
}
