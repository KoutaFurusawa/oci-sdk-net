using OCISDK.Core.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Response.Blockstorage
{
    /// <summary>
    /// UpdateVolumeGroupBackup Response
    /// </summary>
    public class UpdateVolumeGroupBackupResponse
    {
        /// <summary>
        /// For optimistic concurrency control. See if-match.
        /// </summary>
        public string ETag { get; set; }

        /// <summary>
        /// The response body will contain a single VolumeGroupBackup resource.
        /// </summary>
        public VolumeGroupBackup VolumeGroupBackup { get; set; }
    }
}
