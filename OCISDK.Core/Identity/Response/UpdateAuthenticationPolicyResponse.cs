﻿using OCISDK.Core.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// UpdateAuthenticationPolicy response
    /// </summary>
    public class UpdateAuthenticationPolicyResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular 
        /// request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single AuthenticationPolicy resource.
        /// </summary>
        public AuthenticationPolicy AuthenticationPolicy { get; set; }
    }
}
