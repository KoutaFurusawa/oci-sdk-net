﻿using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// GetObjectLifecyclePolicy response
    /// </summary>
    public class GetObjectLifecyclePolicyResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// The entity tag (ETag) for the object lifecycle policy.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The response body will contain a single ObjectLifecyclePolicy resource.
        /// </summary>
        public ObjectLifecyclePolicyDetails ObjectLifecyclePolicy { get; set; }
    }
}
