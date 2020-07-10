using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Specifications for the putting of a table row.
    /// </summary>
    public class UpdateRowDetails
    {
        /// <summary>
        /// The OCID of the table's compartment. Required if the tableNameOrId path parameter is a table name. 
        /// Optional if tableNameOrId is an OCID. If tableNameOrId is an OCID, and compartmentId is supplied, 
        /// the latter must match the identified table's compartmentId.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The map of values from a row.
        /// <para>Required: yes</para>
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Specifies a condition for the put operation.
        /// <para>Required: no</para>
        /// </summary>
        public string Option { get; set; }

        /// <summary>
        /// If true, and the put fails due to an option setting, then the existing row will be returned.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsGetReturnRow { get; set; }

        /// <summary>
        /// Timeout setting for the put.
        /// <para>Required: no</para>
        /// </summary>
        public int? TimeoutInMs { get; set; }

        /// <summary>
        /// Time-to-live for the row, in days.
        /// <para>Required: no</para>
        /// </summary>
        public int? Ttl { get; set; }

        /// <summary>
        /// If true, set time-to-live for this row to the table's default.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsTtlUseTableDefault { get; set; }

        /// <summary>
        /// Sets the number of generated identity values that are requested from the server during a put. 
        /// If present and greater than 0, this value takes precedence over a default value for the table.
        /// <para>Required: no</para>
        /// </summary>
        public int? IdentityCacheSize { get; set; }

        /// <summary>
        /// If present and true, the presented row value must exactly match the table's schema. Otherwise, 
        /// rows with missing non-key fields or extra fields can be written successfully.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsExactMatch { get; set; }
    }
}
