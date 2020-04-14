using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Results of ListIndexes.
    /// </summary>
    public class IndexCollection
    {
        /// <summary>
        /// A page of IndexSummary objects.
        /// <para>Required: no</para>
        /// </summary>
        public List<IndexSummary> Items;
    }
}
