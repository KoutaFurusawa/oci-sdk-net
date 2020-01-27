using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.ComputeManagement
{
    /// <summary>
    /// TerminateClusterNetwork request
    /// </summary>
    public class TerminateClusterNetworkRequest
    {
        /// <summary>
        /// The OCID of the cluster network.
        /// <para>Required: yes</para>
        /// </summary>
        public string ClusterNetworkId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, set the 
        /// if-match parameter to the value of the etag from a previous GET or POST response for 
        /// that resource. The resource will be updated or deleted only if the etag you provide 
        /// matches the resource's current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }
    }
}
