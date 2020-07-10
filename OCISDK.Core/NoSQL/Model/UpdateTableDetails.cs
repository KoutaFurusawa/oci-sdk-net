using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// The information to be updated.
    /// </summary>
    public class UpdateTableDetails
    {
        /// <summary>
        /// The OCID of the table's current compartment. Required if the tableNameOrId path parameter is a table name. 
        /// Optional if tableNameOrId is an OCID. If tableNameOrId is an OCID, and compartmentId is supplied, the latter 
        /// must match the identified table's compartmentId.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Complete ALTER TABLE DDL statement.
        /// <para>Required: no</para>
        /// </summary>
        public string DdlStatement { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public TableLimits TableLimits { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
