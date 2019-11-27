using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.Core.Model.Blockstorage;

namespace OCISDK.Core.Core.Response.Blockstorage
{
    /// <summary>
    /// CopyVolumeBackup Response
    /// </summary>
    public class CopyVolumeBackupResponse
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
        /// The response body will contain a single VolumeBackup resource.
        /// </summary>
        public VolumeBackup VolumeBackup { get; set; }
    }
}
