using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.src.DNS.Model
{
    public class PatchDomainRecordsDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<RecordOperation> Items { get; set; }
    }
}