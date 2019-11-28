using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Request
{
    /// <summary>
    /// UpdateNamespaceMetadata Request
    /// </summary>
    public class UpdateNamespaceMetadataRequest
    {
        /// <summary>
        /// The Object Storage namespace used for the request.
        /// <para>Required: yes</para>
        /// </summary>
        public string NamespaceName { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateNamespaceMetadataDetails resource.
        /// </summary>
        public UpdateNamespaceMetadataDetails UpdateNamespaceMetadataDetails { get; set; }
    }
}
