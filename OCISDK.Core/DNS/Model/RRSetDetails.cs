using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// A collection of DNS records of the same domain and type. For more information about record types, see Resource Record (RR) TYPEs.
    /// </summary>
    public class RRSetDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<RecordDetails> Items { get; set; }
    }
}