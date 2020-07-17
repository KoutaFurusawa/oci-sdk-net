using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Model
{
    /// <summary>
    /// Network policy, Consists of a list of Network Source ids.
    /// </summary>
    public class NetworkPolicy
    {
        /// <summary>
        /// Network Source ids
        /// <para>Required: no</para>
        /// </summary>
        public List<string> NetworkSources { get; set; }
    }
}
