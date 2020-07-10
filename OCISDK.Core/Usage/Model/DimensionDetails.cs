using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Model
{
    /// <summary>
    /// The dimension used for filtering. example: [{value: "COMPUTE", key: "service"}]
    /// </summary>
    public class DimensionDetails
    {
        /// <summary>
        /// The dimension key.
        /// <para>Required: yes</para>
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The dimension value.
        /// <para>Required: yes</para>
        /// </summary>
        public string Value { get; set; }
    }
}
