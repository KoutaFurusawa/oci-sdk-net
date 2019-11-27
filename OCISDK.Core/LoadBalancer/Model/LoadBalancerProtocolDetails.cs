using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A protocol that defines the type of traffic accepted by a listener.
    /// </summary>
    public class LoadBalancerProtocolDetails
    {
        /// <summary>
        /// The name of a protocol.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }
    }
}
