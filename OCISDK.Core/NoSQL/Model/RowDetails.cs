using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// The result of GetRow.
    /// </summary>
    public class RowDetails
    {
        /// <summary>
        /// The map of values from a row.
        /// <para>Required: no</para>
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// The expiration time of the row. A zero value indicates that the row does not expire. An RFC3339 formatted datetime string.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeOfExpiration { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public RequestUsage Usage { get; set; }
    }
}
