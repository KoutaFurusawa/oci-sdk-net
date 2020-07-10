using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// TableCollection
    /// </summary>
    public class TableCollection
    {
        /// <summary>
        /// A page of TableSummary objects.
        /// <para>Required: no</para>
        /// </summary>
        public List<TableSummary> Items { get; set; }
    }
}
