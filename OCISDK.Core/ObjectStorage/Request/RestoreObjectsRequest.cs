using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// RestoreObjects request
    /// </summary>
    public class RestoreObjectsRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The name of the bucket. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single RestoreObjectsDetails resource.
        /// </summary>
        public RestoreObjectsDetails RestoreObjectsDetails { get; set; }
    }
}
