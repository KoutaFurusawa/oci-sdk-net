using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// InstanceConfigurationAttachVnicDetails
    /// </summary>
    public class InstanceConfigurationAttachVnicDetails
    {
        /// <summary>
        /// Details for creating a new VNIC.
        /// <para>Required: no</para>
        /// </summary>
        public InstanceConfigurationCreateVnicDetails CreateVnicDetails { get; set; }

        /// <summary>
        /// A user-friendly name for the attachment. Does not have to be unique, and it cannot be changed.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Which physical network interface card (NIC) the VNIC will use. 
        /// Defaults to 0. Certain bare metal instance shapes have two active physical NICs (0 and 1). 
        /// If you add a secondary VNIC to one of these instances, you can specify which NIC the VNIC will use. 
        /// For more information, see Virtual Network Interface Cards (VNICs).
        /// </summary>
        public int? NicIndex { get; set; }
    }
}
