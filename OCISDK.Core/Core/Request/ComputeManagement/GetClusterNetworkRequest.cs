using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.ComputeManagement
{
    /// <summary>
    /// GetClusterNetwork request
    /// </summary>
    public class GetClusterNetworkRequest
    {
        /// <summary>
        /// The OCID of the cluster network.
        /// <para>Required: yes</para>
        /// </summary>
        public string ClusterNetworkId { get; set; }
    }
}
