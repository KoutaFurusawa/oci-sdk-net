using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// The result of query preparation.
    /// </summary>
    public class PreparedStatement
    {
        /// <summary>
        /// A base64-encoded, compiled and parameterized version of a SQL statement.
        /// <para>Required: no</para>
        /// </summary>
        public string Statement { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public RequestUsage Usage { get; set; }
    }
}
