using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// The secondary VNIC object for the placement configuration for an instance pool.
    /// </summary>
    public class InstancePoolPlacementSecondaryVnicSubnet
    {
        /// <summary>
        /// The display name of the VNIC. This is also use to match against the instance configuration defined secondary VNIC.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The subnet OCID for the secondary VNIC.
        /// <para>Required: yes</para>
        /// </summary>
        public string SubnetId { get; set; }
    }
}
