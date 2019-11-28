using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.DNS.Model
{
    /// <summary>
    /// PatchZoneRecordsDetails
    /// </summary>
    public class PatchZoneRecordsDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<RecordOperation> Items { get; set; }
    }
}