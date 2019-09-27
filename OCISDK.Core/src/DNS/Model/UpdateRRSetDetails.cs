using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.DNS.Model
{
    public class UpdateRRSetDetails
    {
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public List<RecordDetails> Items { get; set; }
    }
}
