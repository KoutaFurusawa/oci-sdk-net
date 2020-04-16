using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// The usage metrics for a request.
    /// </summary>
    public class RequestUsage
    {
        /// <summary>
        /// Read Units consumed by this operation.
        /// <para>Required: no</para>
        /// </summary>
        public int? ReadUnitsConsumed { get; set; }

        /// <summary>
        /// Write Units consumed by this operation.
        /// <para>Required: no</para>
        /// </summary>
        public int? WriteUnitsConsumed { get; set; }
    }
}
