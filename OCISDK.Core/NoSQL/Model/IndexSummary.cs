using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Model
{
    /// <summary>
    /// Information about an index.
    /// </summary>
    public class IndexSummary
    {
        /// <summary>
        /// Index name.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

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
