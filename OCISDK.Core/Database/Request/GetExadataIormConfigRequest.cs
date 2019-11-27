using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Request
{
    /// <summary>
    /// GetExadataIormConfig Request
    /// </summary>
    public class GetExadataIormConfigRequest
    {
        /// <summary>
        /// The DB system OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbSystemId { get; set; }

        /// <summary>
        /// Unique identifier for the request.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}
