using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// Configuration details for the connection between the client and backend servers.
    /// </summary>
    public class ConnectionConfiguration
    {
        /// <summary>
        /// The maximum idle time, in seconds, allowed between two successive receive or two successive send operations 
        /// between the client and backend servers. 
        /// A send operation does not reset the timer for receive operations. A receive operation does not reset the timer 
        /// for send operations.
        /// <para>Required: yes</para>
        /// </summary>
        public int IdleTimeout { get; set; }
    }
}