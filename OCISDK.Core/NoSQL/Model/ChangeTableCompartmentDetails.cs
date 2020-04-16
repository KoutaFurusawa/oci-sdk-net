using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Specification of both from and to compartments.
    /// </summary>
    public class ChangeTableCompartmentDetails
    {
        /// <summary>
        /// The OCID of the table's current compartment. Required if the tableNameOrId path parameter is a table name. 
        /// Optional if tableNameOrId is an OCID. If tableNameOrId is an OCID, and fromCompartmentId is supplied, the 
        /// latter must match the identified table's current compartmentId.
        /// <para>Required: no</para>
        /// </summary>
        public string FromCompartmentId { get; set; }

        /// <summary>
        /// The OCID of the table's new compartment.
        /// <para>Required: no</para>
        /// </summary>
        public string ToCompartmentId { get; set; }
    }
}
