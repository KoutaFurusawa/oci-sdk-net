﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// UploadPart response
    /// </summary>
    public class UploadPartResponse
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
        /// The base64-encoded MD5 hash of the request body, as computed by the server.
        /// </summary>
        public string OpcContentMd5 { get; set; }

        /// <summary>
        /// The entity tag (ETag) for the object.
        /// </summary>
        public string ETag { get; set; }
    }
}
