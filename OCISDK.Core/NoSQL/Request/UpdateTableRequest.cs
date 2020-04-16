using OCISDK.Core.NoSQL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// UpdateTable request
    /// </summary>
    public class UpdateTableRequest
    {
        /// <summary>
        /// A table name within the compartment, or a table OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string TableNameOrId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the 
        /// value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted 
        /// only if the etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateTableDetails resource.
        /// </summary>
        public UpdateTableDetails UpdateTableDetails { get; set; }
    }
}
