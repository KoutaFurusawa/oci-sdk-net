using OCISDK.Core.Core.Model.ComputeManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.ComputeManagement
{
    /// <summary>
    /// CreateClusterNetwork response
    /// </summary>
    public class CreateClusterNetworkResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. 
        /// If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the work request. Use GetWorkRequest with this ID to track the status of the request.
        /// </summary>
        public string OpcWorkRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single ClusterNetwork resource.
        /// </summary>
        public ClusterNetwork ClusterNetwork { get; set; }
    }
}
