using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.ComputeManagement
{
    /// <summary>
    /// The data to create an instance pool in a cluster network.
    /// </summary>
    public class CreateClusterNetworkInstancePoolDetails
    {
        /// <summary>
        /// The user-friendly name. Does not have to be unique.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the instance configuration associated with the instance pool.
        /// <para>Required: yes</para>
        /// <para>Max Length: 255, Min Length: 1</para>
        /// </summary>
        public string InstanceConfigurationId { get; set; }

        /// <summary>
        /// The number of instances that should be in the instance pool.
        /// 
        /// If the required number of instances is not available or if some instances fail to launch, the cluster network is not created.
        /// <para>Required: yes</para>
        /// </summary>
        public long Size { get; set; }

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
