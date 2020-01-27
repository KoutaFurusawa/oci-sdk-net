using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// Summary information for a cluster network.
    /// </summary>
    public class ClusterNetworkSummary
    {
        /// <summary>
        /// The OCID of the cluster network.
        /// <para>Required: yes</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the cluster netowrk.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The instance pools in the cluster network.
        /// Each cluster network can have one instance pool.
        /// <para>Required: no</para>
        /// </summary>
        public List<InstancePoolSummary> InstancePools { get; set; }
        
        /// <summary>
        /// The current state of the cluster network.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The date and time the resource was created, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The date and time the resource was updated, in the format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeUpdated { get; set; }

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
