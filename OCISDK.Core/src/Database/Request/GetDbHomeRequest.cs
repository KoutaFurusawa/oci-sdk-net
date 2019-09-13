using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Database.Request
{
    public class GetDbHomeRequest
    {
        /// <summary>
        /// The database home OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbHomeId { get; set; }
    }
}
