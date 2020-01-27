using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// The location for where the instance pools in a cluster network will place instances.
    /// </summary>
    public class ClusterNetworkPlacementConfigurationDetails
    {
        /// <summary>
        /// The availability domain to place instances.
        /// <para>Required: yes</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The OCID of the primary subnet to place instances.
        /// <para>Required: yes</para>
        /// </summary>
        public string PrimarySubnetId { get; set; }

        /// <summary>
        /// The set of secondary VNIC data for instances in the pool.
        /// <para>Required: no</para>
        /// </summary>
        public List<InstancePoolPlacementSecondaryVnicSubnet> SecondaryVnicSubnets { get; set; }
    }
}
