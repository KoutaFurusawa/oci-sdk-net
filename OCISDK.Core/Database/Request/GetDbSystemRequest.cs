using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Request
{
    /// <summary>
    /// GetDbSystem Request
    /// </summary>
    public class GetDbSystemRequest
    {
        /// <summary>
        /// The DB system OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbSystemId { get; set; }
    }
}
