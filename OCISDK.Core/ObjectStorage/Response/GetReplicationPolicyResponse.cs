﻿using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// GetReplicationPolicy response
    /// </summary>
    public class GetReplicationPolicyResponse
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
        /// The response body will contain a single ReplicationPolicy resource.
        /// </summary>
        public ReplicationPolicy ReplicationPolicy { get; set; }
    }
}
