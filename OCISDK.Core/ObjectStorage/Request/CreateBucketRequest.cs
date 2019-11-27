using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// CreateBucket Request
    /// </summary>
    public class CreateBucketRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single CreateBucketDetails resource.
        /// </summary>
        public CreateBucketDetails CreateBucketDetails { get; set; }
    }
}
