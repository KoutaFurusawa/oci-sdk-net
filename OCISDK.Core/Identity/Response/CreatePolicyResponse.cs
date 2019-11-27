﻿using OCISDK.Core.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// CreatePolicy Response
    /// </summary>
    public class CreatePolicyResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, 
        /// please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// response header parameter ETag
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The response body will contain a single Policy resource.
        /// </summary>
        public Policy Policy { get; set; }
    }
}
