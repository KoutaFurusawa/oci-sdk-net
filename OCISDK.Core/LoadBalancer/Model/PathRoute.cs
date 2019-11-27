using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A "path route rule" to evaluate an incoming URI path, and then route a matching request to the specified backend set.
    /// 
    /// Path route rules apply only to HTTP and HTTPS requests. They have no effect on TCP requests.
    /// </summary>
    public class PathRoute
    {
        /// <summary>
        /// The path string to match against the incoming URI path.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 2048</para>
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The type of matching to apply to incoming URIs.
        /// <para>Required: yes</para>
        /// </summary>
        public PathMatchType PathMatchType { get; set; }

        /// <summary>
        /// The name of the target backend set for requests where the incoming URI matches the specified path.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 32</para>
        /// </summary>
        public string BackendSetName { get; set; }
    }
}
