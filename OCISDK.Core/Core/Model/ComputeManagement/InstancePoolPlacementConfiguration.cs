using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// The location for where an instance pool will place instances.
    /// </summary>
    public class InstancePoolPlacementConfiguration
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
        /// The fault domains to place instances.
        /// 
        /// If you don't provide any values, the system makes a best effort to distribute instances across all fault domains based on capacity.
        /// 
        /// To distribute the instances evenly across selected fault domains, provide a set of fault domains. For example, you might want instances 
        /// to be evenly distributed if your applications require high availability.
        /// 
        /// To get a list of fault domains, use the ListFaultDomains operation in the Identity and Access Management Service API.
        /// 
        /// <para>Required: no</para>
        /// </summary>
        public List<string> FaultDomains { get; set; }

        /// <summary>
        /// The set of secondary VNIC data for instances in the pool.
        /// <para>Required: no</para>
        /// </summary>
        public List<InstancePoolPlacementSecondaryVnicSubnet> SecondaryVnicSubnets { get; set; }
    }
}
