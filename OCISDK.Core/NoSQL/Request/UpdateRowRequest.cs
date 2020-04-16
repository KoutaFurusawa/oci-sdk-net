using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.NoSQL.Model;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// UpdateRow request
    /// </summary>
    public class UpdateRowRequest
    {
        /// <summary>
        /// A table name within the compartment, or a table OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string TableNameOrId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter 
        /// to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or 
        /// deleted only if the etag you provide matches the resource's current etag value.
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateRowDetails resource.
        /// </summary>
        public UpdateRowDetails UpdateRowDetails { get; set; }
    }
}
