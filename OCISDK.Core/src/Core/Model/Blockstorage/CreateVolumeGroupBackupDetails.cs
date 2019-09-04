﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.src.Core.Model.Blockstorage
{
    public class CreateVolumeGroupBackupDetails
    {
        /// <summary>
        /// The OCID of the compartment that will contain the volume group backup.
        /// This parameter is optional, by default backup will be created in the same compartment and source volume group.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name for the volume group backup.
        /// Does not have to be unique and it's changeable. Avoid entering confidential information.
        /// </summary>
        public string DisplayName { get; set; }
        
        /// <summary>
        /// The OCID of the volume group that needs to be backed up.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeGroupId { get; set; }

        /// <summary>
        /// The type of backup to create. If omitted, defaults to INCREMENTAL.
        /// <para>Required: no</para>
        /// </summary>
        public Types Type { get; set; }

        public enum Types
        {
            [DisplayName("FULL")]
            FULL,
            [DisplayName("INCREMENTAL")]
            INCREMENTAL
        }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}