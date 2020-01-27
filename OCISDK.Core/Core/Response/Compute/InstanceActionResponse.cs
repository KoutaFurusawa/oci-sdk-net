﻿using OCISDK.Core.Core.Model.Compute;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.Compute
{
    /// <summary>
    /// InstanceAction response
    /// </summary>
    public class InstanceActionResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single Instance resource.
        /// </summary>
        public Instance Instance { get; set; }
    }
}
