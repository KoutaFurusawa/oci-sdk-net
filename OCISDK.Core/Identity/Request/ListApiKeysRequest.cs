using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListApiKeys request
    /// </summary>
    public class ListApiKeysRequest
    {
        /// <summary>
        /// The OCID of the user.
        /// <para>Required: yes</para>
        /// </summary>
        public string UserId { get; set; }
    }
}
