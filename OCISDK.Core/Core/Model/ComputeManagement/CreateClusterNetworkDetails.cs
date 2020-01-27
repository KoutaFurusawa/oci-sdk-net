using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// The data to create a cluster network.
    /// </summary>
    public class CreateClusterNetworkDetails
    {
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
        public List<CreateClusterNetworkInstancePoolDetails> InstancePools { get; set; }

        /// <summary>
        /// The placement configuration for the instance pools in the cluster network.
        /// <para>Required: no</para>
        /// </summary>
        public ClusterNetworkPlacementConfigurationDetails PlacementConfiguration { get; set; }

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
