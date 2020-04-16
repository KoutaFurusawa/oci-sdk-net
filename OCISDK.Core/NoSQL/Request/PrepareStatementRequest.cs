using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// PrepareStatement request
    /// </summary>
    public class PrepareStatementRequest
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
            StringBuilder sb = new StringBuilder();
            sb.Append($"compartmentId={CompartmentId}");

            if(!string.IsNullOrEmpty(Statement))
            {
                sb.Append($"&statement={Statement}");
            }

            return sb.ToString();
        }
    }
}
