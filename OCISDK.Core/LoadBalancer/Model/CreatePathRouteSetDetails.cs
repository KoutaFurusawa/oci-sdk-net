using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A named set of path route rules to add to the load balancer.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class CreatePathRouteSetDetails
    {
        /// <summary>
        /// The name for this set of path route rules. It must be unique and it cannot be changed. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The set of path route rules.
        /// <para>Required: yes</para>
        /// </summary>
        public List<PathRoute> PathRoutes { get; set; }
    }
}
