using OCISDK.Core.SupportManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.SupportManagement.Response
{
    /// <summary>
    /// ValidateUser response
    /// </summary>
    public class ValidateUserResponse
    {
        /// <summary>
        /// The entity tag that allows optimistic concurrency control. For more information, see REST APIs.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular 
        /// request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single ValidationResponse resource.
        /// </summary>
        public ValidationResponseDetails ValidationResponse { get; set; }
    }
}
