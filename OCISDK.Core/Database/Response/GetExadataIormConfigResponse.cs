using OCISDK.Core.Database.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Response
{
    /// <summary>
    /// GetExadataIormConfig Response
    /// </summary>
    public class GetExadataIormConfigResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request.
        /// If you need to contact Oracle about a particular request,
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single ExadataIormConfig resource.
        /// </summary>
        public ExadataIormConfigDetails ExadataIormConfig { get; set; }
    }
}
