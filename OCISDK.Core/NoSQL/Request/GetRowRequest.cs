using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// GetRow request
    /// </summary>
    public class GetRowRequest
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
        /// Consistency requirement for a read operation.
        /// <para>Required: no</para>
        /// </summary>
        public string Consistency { get; set; }

        /// <summary>
        /// Timeout setting for this operation.
        /// <para>Required: no</para>
        /// </summary>
        public int? TimeoutInMs { get; set; }

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

            if (!string.IsNullOrEmpty(Consistency))
            {
                sb.Append($"&consistency={Consistency}");
            }

            if (TimeoutInMs.HasValue)
            {
                sb.Append($"&timeoutInMs={TimeoutInMs.Value}");
            }

            return sb.ToString();
        }
    }
}
