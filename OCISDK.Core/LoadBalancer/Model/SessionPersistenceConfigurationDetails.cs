using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The configuration details for implementing session persistence based on a user-specified cookie name (application cookie stickiness).
    /// 
    /// Session persistence enables the Load Balancing service to direct any number of requests that originate from a single logical client to a single backend web server. 
    /// For more information, see Session Persistence.
    /// 
    /// To disable application cookie stickiness on a running load balancer, use the UpdateBackendSet operation and specify null for the SessionPersistenceConfigurationDetails object.
    /// </summary>
    public class SessionPersistenceConfigurationDetails
    {

        /// <summary>
        /// The name of the cookie used to detect a session initiated by the backend server. 
        /// Use '*' to specify that any cookie set by the backend causes the session to persist.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 4096</para>
        /// </summary>
        public string CookieName { get; set; }

        /// <summary>
        /// Whether the load balancer is prevented from directing traffic from a persistent session client to a different backend server if the original server is unavailable. 
        /// Defaults to false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? DisableFallback { get; set; }
    }
}
