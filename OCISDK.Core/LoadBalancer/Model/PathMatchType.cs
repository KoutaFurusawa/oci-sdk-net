using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The type of matching to apply to incoming URIs.
    /// </summary>
    public class PathMatchType
    {
        /// <summary>
        /// Specifies how the load balancing service compares a PathRoute object's path string against the incoming URI.
        /// <para>Required: yes</para>
        /// </summary>
        public string MatchType { get; set; }
    }
}
