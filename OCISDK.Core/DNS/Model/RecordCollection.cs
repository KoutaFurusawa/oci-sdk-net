using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// A collection of DNS resource records.
    /// </summary>
    public class RecordCollection
    {
        /// <summary>
        /// A DNS resource record. For more information, see Supported DNS Resource Record Types.
        /// </summary>
        public List<RecordDetails> Items { get; set; }
    }
}
