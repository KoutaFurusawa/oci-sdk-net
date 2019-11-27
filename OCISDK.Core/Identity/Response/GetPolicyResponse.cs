﻿using OCISDK.Core.Identity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Response
{
    /// <summary>
    /// GetPolicy Response
    /// </summary>
    public class GetPolicyResponse
    {
        /// <summary>
        /// response header parameter ETag
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// response header parameter opcRequestId
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single Policy resource.
        /// </summary>
        public Policy Policy { get; set; }
    }
}
