using OCISDK.Core.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.Blockstorage
{
    /// <summary>
    /// UpdateVolumeGroup Response
    /// </summary>
    public class UpdateVolumeGroupResponse
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
        /// The response body will contain a single VolumeGroup resource.
        /// </summary>
        public VolumeGroup VolumeGroup { get; set; }
    }
}
