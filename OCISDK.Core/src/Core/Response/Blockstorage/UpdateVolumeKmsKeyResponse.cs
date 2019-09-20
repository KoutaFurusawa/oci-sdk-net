﻿using OCISDK.Core.src.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.src.Core.Response.Blockstorage
{
    public class UpdateVolumeKmsKeyResponse
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
        /// The response body will contain a single VolumeKmsKey resource.
        /// </summary>
        public VolumeKmsKey VolumeKmsKey { get; set; }
    }
}