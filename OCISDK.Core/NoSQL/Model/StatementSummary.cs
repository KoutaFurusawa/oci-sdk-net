using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Information derived from parsing a NoSQL SQL statement.
    /// </summary>
    public class StatementSummary
    {
        /// <summary>
        /// The operation represented in the statement, e.g. CREATE_TABLE.
        /// <para>Required: no</para>
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// The table name from the SQL statement.
        /// <para>Required: no</para>
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// The index name from the SQL statement, if present.
        /// <para>Required: no</para>
        /// </summary>
        public string IndexName { get; set; }

        /// <summary>
        /// True if the statement includes "IF EXISTS."
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsIfExists { get; set; }

        /// <summary>
        /// True if the statement includes "IF NOT EXISTS."
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsIfNotExists { get; set; }

        /// <summary>
        /// If present, indicates a syntax error in the statement.
        /// <para>Required: no</para>
        /// </summary>
        public string SyntaxError { get; set; }
    }
}
