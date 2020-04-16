using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// SummarizeStatement request
    /// </summary>
    public class SummarizeStatementRequest
    {
        /// <summary>
        /// The ID of a table's compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A NoSQL SQL statement.
        /// <para>Required: yes</para>
        /// </summary>
        public string Statement { get; set; }

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
            return $"compartmentId={CompartmentId}&statement={Statement}";
        }
    }
}
