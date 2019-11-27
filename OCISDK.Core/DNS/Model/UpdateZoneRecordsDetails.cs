using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// UpdateZoneRecordsDetails Reference
    /// </summary>
    public class UpdateZoneRecordsDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<RecordDetails> Items { get; set; }
    }
}
