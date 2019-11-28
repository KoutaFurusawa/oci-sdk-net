using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// The listener's configuration. For more information on backend set configuration, see Managing Load Balancer Listeners.
    /// </summary>
    public class ListenerDetails
    {
        /// <summary>
        /// A friendly name for the listener. It must be unique and it cannot be changed.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the associated backend set.
        /// <para>Required: yes</para>
        /// </summary>
        public string DefaultBackendSetName { get; set; }

        /// <summary>
        /// The communication port for the listener.
        /// <para>Required: yes</para>
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// The protocol on which the listener accepts connection requests.
        /// To get a list of valid protocols, use the ListProtocols operation.
        /// <para>Required: yes</para>
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// An array of hostname resource names.
        /// <para>Required: no</para>
        /// <para>Length: 1–16</para>
        /// </summary>
        public List<string> HostnameNames { get; set; }

        /// <summary>
        /// The name of the set of path-based routing rules, PathRouteSet, applied to this listener's traffic.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 32</para>
        /// </summary>
        public string PathRouteSetName { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public SSLConfiguration SslConfiguration { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public ConnectionConfiguration ConnectionConfiguration { get; set; }

        /// <summary>
        /// The names of the rule sets to apply to the listener.
        /// <para>Required: no</para>
        /// <para>Length: 1–32</para>
        /// </summary>
        public List<string> RuleSetNames { get; set; }
    }
}