using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// VolumeGroupSourceDetails
    /// </summary>
    public class VolumeGroupSourceDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The OCID of the volume group backup to restore from.
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeGroupBackupId { get; set; }

        /// <summary>
        /// The OCID of the volume group to clone from.
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeGroupId { get; set; }

        /// <summary>
        /// OCIDs for the volumes in this volume group.
        /// <para>Max Items: 64</para>
        /// </summary>
        public List<string> VolumeIds { get; set; }
    }
}
