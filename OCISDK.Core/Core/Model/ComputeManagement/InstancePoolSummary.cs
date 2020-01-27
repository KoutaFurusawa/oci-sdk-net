using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// Summary information for an instance pool.
    /// </summary>
    public class InstancePoolSummary
    {
        /// <summary>
        /// The OCID of the instance pool.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the instance pool.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The user-friendly name. Does not have to be unique.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the instance configuration associated with the instance pool.
        /// <para>Required: yes</para>
        /// </summary>
        public string InstanceConfigurationId { get; set; }

        /// <summary>
        /// The current state of the instance pool.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The availability domain to place instances.
        /// <para>Required: yes</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The number of instances that should be in the instance pool.
        /// <para>Required: yes</para>
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The date and time the instance pool was created, in the format defined by RFC3339. Example: 2016-08-25T21:10:29.600Z
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }
        
        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
