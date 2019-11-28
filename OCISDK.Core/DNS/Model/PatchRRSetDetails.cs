using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// PatchRRSetDetails
    /// </summary>
    public class PatchRRSetDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<RecordOperation> Items { get; set; }
    }
}
