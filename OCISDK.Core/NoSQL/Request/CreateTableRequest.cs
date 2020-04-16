using OCISDK.Core.NoSQL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// CreateTable request
    /// </summary>
    public class CreateTableRequest
    {
        /// <summary>
        /// A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of 
        /// executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting 
        /// operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation 
        /// request might be rejected.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRetryToken { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single CreateTableDetails resource.
        /// </summary>
        public CreateTableDetails CreateTableDetails { get; set; }
    }
}
