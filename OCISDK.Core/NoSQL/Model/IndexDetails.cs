using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Information about an index.
    /// </summary>
    public class IndexDetails
    {
        /// <summary>
        /// Index name.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Compartment Identifier.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the table to which this index belongs.
        /// <para>Required: no</para>
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// the OCID of the table to which this index belongs.
        /// <para>Required: no</para>
        /// </summary>
        public string TableId { get; set; }

        /// <summary>
        /// A set of keys for a secondary index.
        /// <para>Required: no</para>
        /// </summary>
        public List<IndexKeyDetails> Keys { get; set; }

        /// <summary>
        /// The state of an index.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// /A message describing the current state in more detail.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleDetails { get; set; }
    }
}
