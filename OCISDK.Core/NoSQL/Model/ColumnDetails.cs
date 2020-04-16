using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// A column of a table.
    /// </summary>
    public class ColumnDetails
    {
        /// <summary>
        /// The column name.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The column type.
        /// <para>Required: no</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The column nullable flag.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsNullable { get; set; }

        /// <summary>
        /// The column default value.
        /// <para>Required: no</para>
        /// </summary>
        public string DefaultValue { get; set; }
    }
}
