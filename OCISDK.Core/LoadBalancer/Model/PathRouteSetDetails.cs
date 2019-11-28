using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// A named set of path route rules. For more information, see Managing Request Routing.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class PathRouteSetDetails
    {
        /// <summary>
        /// The unique name for this set of path route rules. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 32</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The set of path route rules.
        /// <para>Required: yes</para>
        /// <para>Min Items: 0, Max Items: 20</para>
        /// </summary>
        public List<PathRoute> PathRoutes { get; set; }
    }
}
