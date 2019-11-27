using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// Contains the details for the compartment to move the volume backup to.
    /// </summary>
    public class ChangeVolumeBackupCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment to move the volume backup to.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}
