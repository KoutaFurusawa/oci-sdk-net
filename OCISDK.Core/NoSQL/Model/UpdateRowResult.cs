using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// The result of an UpdateRow operation.
    /// </summary>
    public class UpdateRowResult
    {
        /// <summary>
        /// An opaque version string associated with the row.
        /// <para>Required: no</para>
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The version string associated with the existing row. Returned if the put fails due to options setting in the request.
        /// <para>Required: no</para>
        /// </summary>
        public string ExistingVersion { get; set; }

        /// <summary>
        /// The map of values from a row.
        /// <para>Required: no</para>
        /// </summary>
        public object ExistingValue { get; set; }

        /// <summary>
        /// The value generated if the operation created a new value for an identity column. If the table has no identity column, this value is null. 
        /// If it has an identity column, and a value was generated for that column, it is non-null.
        /// <para>Required: no</para>
        /// </summary>
        public string GeneratedValue { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public RequestUsage Usage { get; set; }
    }
}
