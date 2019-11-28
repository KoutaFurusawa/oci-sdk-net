using OCISDK.Core.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// ChangeBootVolumeBackupCompartment Request
    /// </summary>
    public class ChangeBootVolumeBackupCompartmentRequest
    {
        /// <summary>
        /// The OCID of the boot volume backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string BootVolumeBackupId { get; set; }

        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The request body must contain a single ChangeBootVolumeBackupCompartmentDetails resource.
        /// </summary>
        public ChangeBootVolumeBackupCompartmentDetails ChangeBootVolumeBackupCompartmentDetails { get; set; }
    }
}
