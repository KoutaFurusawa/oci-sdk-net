﻿using OCISDK.Core.Core.Model.Blockstorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Blockstorage
{
    /// <summary>
    /// UpdateVolumeGroupBackup Request
    /// </summary>
    public class UpdateVolumeGroupBackupRequest
    {
        /// <summary>
        /// The Oracle Cloud ID (OCID) that uniquely identifies the volume group backup.
        /// <para>Required: yes</para>
        /// </summary>
        public string VolumeGroupBackupId { get; set; }

        /// <summary>
        /// For optimistic concurrency control. In the PUT or DELETE call for a resource, 
        /// set the if-match parameter to the value of the etag from a previous GET or 
        /// POST response for that resource. The resource will be updated or deleted 
        /// only if the etag you provide matches the resource's current etag value.
        /// <para>Required: no</para>
        /// <para>if-match header parameter</para>
        /// </summary>
        public string IfMatch { get; set; }

        /// <summary>
        /// The request body must contain a single UpdateVolumeGroupBackupDetails resource.
        /// </summary>
        public UpdateVolumeGroupBackupDetails UpdateVolumeGroupBackupDetails { get; set; }
    }
}
