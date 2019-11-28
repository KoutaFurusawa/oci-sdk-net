using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// UpdateStateDetails Reference
    /// </summary>
    public class UpdateStateDetails
    {
        /// <summary>
        /// Update state to blocked or unblocked. Only "false" is supported (for changing the state to unblocked).
        /// <para>Required: no</para>
        /// </summary>
        public bool? Blocked { get; set; }
    }
}
