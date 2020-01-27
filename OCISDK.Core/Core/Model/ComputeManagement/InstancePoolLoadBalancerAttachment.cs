using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// Represents a load balancer that is attached to an instance pool.
    /// </summary>
    public class InstancePoolLoadBalancerAttachment
    {
        /// <summary>
        /// The OCID of the load balancer attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the instance pool of the load balancer attachment.
        /// <para>Required: yes</para>
        /// </summary>
        public string InstancePoolId { get; set; }

        /// <summary>
        /// The OCID of the load balancer attached to the instance pool.
        /// <para>Required: yes</para>
        /// </summary>
        public string LoadBalancerId { get; set; }

        /// <summary>
        /// The name of the backend set on the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string BackendSetName { get; set; }

        /// <summary>
        /// The port value used for the backends.
        /// <para>Required: yes</para>
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Indicates which VNIC on each instance in the instance pool should be used to associate with the load balancer.
        /// Possible values are "PrimaryVnic" or the displayName of one of the secondary VNICs on the instance configuration 
        /// that is associated with the instance pool.
        /// <para>Required: yes</para>
        /// </summary>
        public string VnicSelection { get; set; }

        /// <summary>
        /// The status of the interaction between the instance pool and the load balancer.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }
    }
}
