using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A hostname resource associated with a load balancer for use by one or more listeners.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class HostnameDetails
    {
        /// <summary>
        /// A friendly name for the hostname resource. It must be unique and it cannot be changed. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A virtual hostname. For more information about virtual hostname string construction, see Managing Request Routing.
        /// <para>Required: yes</para>
        /// </summary>
        public string Hostname { get; set; }
    }
}