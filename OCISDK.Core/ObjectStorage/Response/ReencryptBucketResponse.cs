﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// ReencryptBucket response
    /// </summary>
    public class ReencryptBucketResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the asynchronous request.
        /// If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcWorkRequestId { get; set; }

        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }
    }
}
