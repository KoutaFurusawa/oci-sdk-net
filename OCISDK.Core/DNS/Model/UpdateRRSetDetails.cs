using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// UpdateRRSetDetails
    /// </summary>
    public class UpdateRRSetDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<RecordDetails> Items { get; set; }
    }
}
