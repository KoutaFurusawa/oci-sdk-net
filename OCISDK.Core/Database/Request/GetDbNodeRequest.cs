using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Request
{
    /// <summary>
    /// GetDbNode request
    /// </summary>
    public class GetDbNodeRequest
    {
        /// <summary>
        /// The database node OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string DbNodeId { get; set; }
    }
}
