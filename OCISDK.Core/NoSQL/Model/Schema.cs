using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// The table schema information as a JSON object.
    /// </summary>
    public class Schema
    {
        /// <summary>
        /// The columns of a table.
        /// <para>Required: yes</para>
        /// </summary>
        public List<ColumnDetails> Columns { get; set; }

        /// <summary>
        /// A list of column names that make up a key.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> PrimaryKey { get; set; }

        /// <summary>
        /// A list of column names that make up a key.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> ShardKey { get; set; }

        /// <summary>
        /// The default Time-to-Live for the table, in days.
        /// <para>Required: yes</para>
        /// </summary>
        public int Ttl { get; set; }
    }
}
