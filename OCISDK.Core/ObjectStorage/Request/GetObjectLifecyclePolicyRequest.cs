using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// GetObjectLifecyclePolicy request
    /// </summary>
    public class GetObjectLifecyclePolicyRequest
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
    }
}
