using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.NoSQL.Model;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// ChangeTableCompartment request
    /// </summary>
    public class ChangeTableCompartmentRequest
    {
        /// <summary>
        /// A table name within the compartment, or a table OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string TableNameOrId { get; set; }

        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of 
        /// executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting 
        /// operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation 
        /// request might be rejected.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, set the if-match parameter to the value of the etag from a 
        /// previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's 
        /// current etag value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeTableCompartmentDetails resource.
        /// </summary>
        public ChangeTableCompartmentDetails ChangeTableCompartmentDetails { get; set; }
    }
}
