using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Summary of the table.
    /// </summary>
    public class TableSummary
    {
        /// <summary>
        /// Unique identifier that is immutable.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Human-friendly table name, immutable.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Compartment Identifier.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The time the the table was created. An RFC3339 formatted datetime string.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The time the the table's metadata was last updated. An RFC3339 formatted datetime string.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeUpdated { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public TableLimits TableLimits { get; set; }

        /// <summary>
        /// The state of a table.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// A message describing the current state in more detail.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleDetails { get; set; }

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
