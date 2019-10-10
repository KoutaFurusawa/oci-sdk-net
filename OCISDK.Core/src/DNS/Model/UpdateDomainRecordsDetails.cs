using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.DNS.Model
{
    /// <summary>
    /// UpdateDomainRecordsDetails Reference
    /// </summary>
    public class UpdateDomainRecordsDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<RecordDetails> Items { get; set; }
    }
}
