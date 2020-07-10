using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// GetRetentionRule response
    /// </summary>
    public class GetRetentionRuleResponse
    {
        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The entity tag (ETag) for the retention rule.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// The time the retention rule was last modified, as described in RFC 2616
        /// </summary>
        public string LastModified { get; set; }

        /// <summary>
        /// The response body will contain a single RetentionRule resource.
        /// </summary>
        public RetentionRule RetentionRule { get; set; }
    }
}
