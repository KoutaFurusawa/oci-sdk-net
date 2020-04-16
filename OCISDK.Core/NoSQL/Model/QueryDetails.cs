using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// All the information surrounding a query, including the query statement, limits, consistency, and so forth.
    /// </summary>
    public class QueryDetails
    {
        /// <summary>
        /// Compartment OCID, to provide context for a table name in the given statement.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A NoSQL SQL query statement; or a Base64-encoded prepared statement.
        /// <para>Required: yes</para>
        /// </summary>
        public string Statement { get; set; }

        /// <summary>
        /// If true, the statement is a prepared statement.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsPrepared { get; set; }

        /// <summary>
        /// Consistency requirement for a read operation.
        /// <para>Required: no</para>
        /// <para>Default: EVENTUAL</para>
        /// <para>Allowed values are: EVENTUAL, ABSOLUTE</para>
        /// </summary>
        public string Consistency { get; set; }

        /// <summary>
        /// A limit on the total amount of data read during this operation, in KB.
        /// <para>Required: no</para>
        /// <para>Default: 0</para>
        /// </summary>
        public int? MaxReadInKBs { get; set; }

        /// <summary>
        /// A map of prepared statement variables to values.
        /// <para>Required: no</para>
        /// </summary>
        public object Variables { get; set; }

        /// <summary>
        /// Timeout setting for the query.
        /// <para>Required: no</para>
        /// <para>Default: 5000</para>
        /// </summary>
        public int? TimeoutInMs { get; set; }
    }
}
