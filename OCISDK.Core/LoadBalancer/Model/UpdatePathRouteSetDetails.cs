using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// An updated set of path route rules that overwrites the existing set of rules.
    /// </summary>
    public class UpdatePathRouteSetDetails
    {
        /// <summary>
        /// The set of path route rules.
        /// <para>Required: yes</para>
        /// </summary>
        public List<PathRoute> PathRoutes { get; set; }
    }
}
