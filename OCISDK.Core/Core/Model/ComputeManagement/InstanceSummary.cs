using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// Condensed instance data when listing instances in an instance pool.
    /// </summary>
    public class InstanceSummary
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// Avoid entering confidential information.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string FaultDomain { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// The current state of the instance pool instance.
        /// <para>Required: yes</para>
        /// <para>Max Length: 255, Min Length: 1</para>
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The date and time the instance was created, in the format defined by RFC3339.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The load balancer backends that are configured for the instance pool instance.
        /// <para>Required: no</para>
        /// </summary>
        public List<InstancePoolInstanceLoadBalancerBackend> LoadBalancerBackends { get; set; }

    }
}
