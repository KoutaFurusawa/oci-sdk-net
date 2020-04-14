using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Specifications for the new index.
    /// </summary>
    public class CreateIndexDetails
    {
        /// <summary>
        /// Index name.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The OCID of the table's compartment. Required if the tableNameOrId path parameter is a table name. 
        /// Optional if tableNameOrId is an OCID. If tableNameOrId is an OCID, and compartmentId is supplied, 
        /// the latter must match the identified table's compartmentId.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A set of keys for a secondary index.
        /// <para>Required: yes</para>
        /// </summary>
        public List<IndexKeyDetails> Keys { get; set; }

        /// <summary>
        /// If true, the operation completes successfully even when the index exists. Otherwise, an attempt to 
        /// create an index that already exists will return an error.
        /// <para>Required: no</para>
        /// </summary>
        public bool IsIfNotExists { get; set; }
    }
}
