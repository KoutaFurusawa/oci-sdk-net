using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// ChangeVolumeGroupCompartmentDetails
    /// </summary>
    public class ChangeVolumeGroupCompartmentDetails
    {
        /// <summary>
        /// The OCID of the compartment to move the volume group to.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }
    }
}
