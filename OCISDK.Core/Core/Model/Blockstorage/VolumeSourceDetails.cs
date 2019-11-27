using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// VolumeSourceDetails
    /// </summary>
    public class VolumeSourceDetails
    {
        /// <summary>
        /// This resource has one or more subtypes based on the value of the type attribute:
        /// Allowed values are:
        /// * volumeBackup
        /// * volume
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// volumeBackup: The OCID of the volume backup.
        /// volume: The OCID of the volume.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }
    }
}
