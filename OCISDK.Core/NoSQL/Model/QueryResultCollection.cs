using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// The result of a query.
    /// </summary>
    public class QueryResultCollection
    {
        /// <summary>
        /// Array of objects representing query results.The map of values from a row.
        /// <para>Required: no</para>
        /// </summary>
        public List<object> Items { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public RequestUsage Usage { get; set; }
    }
}
