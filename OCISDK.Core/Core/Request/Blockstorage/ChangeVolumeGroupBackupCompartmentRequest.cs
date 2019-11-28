using OCISDK.Core.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// ChangeVolumeGroupBackupCompartment Request
    /// </summary>
    public class ChangeVolumeGroupBackupCompartmentRequest
    {
        /// <summary>
        /// The Oracle Cloud ID (OCID) that uniquely identifies the volume group backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeGroupBackupId { get; set; }

        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeVolumeGroupBackupCompartmentDetails resource.
        /// </summary>
        public ChangeVolumeGroupBackupCompartmentDetails ChangeVolumeGroupBackupCompartmentDetails { get; set; }
    }
}
