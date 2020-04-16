using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// The result of a DeleteRow operation.
    /// </summary>
    public class DeleteRowResult
    {
        /// <summary>
        /// Convey the success or failure of the operation.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsSuccess { get; set; }

        /// <summary>
        /// The version string associated with the existing row. Returned if the delete fails due to options setting in the request.
        /// <para>Required: no</para>
        /// </summary>
        public string ExistingVersion { get; set; }

        /// <summary>
        /// The map of values from a row.
        /// <para>Required: no</para>
        /// </summary>
        public object ExistingValue { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public RequestUsage RequestUsage { get; set; }
    }
}
