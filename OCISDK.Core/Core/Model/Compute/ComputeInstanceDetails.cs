using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Compute Instance Configuration instance details.
    /// </summary>
    public class ComputeInstanceDetails
    {
        /// <summary>
        /// The type of instance details.
        /// <para>The type of instance details. </para>
        /// </summary>
        public string InstanceType { get; set; }

        /// <summary>
        /// <para>blockVolumes</para>
        /// </summary>
        public List<InstanceConfigurationBlockVolumeDetails> BlockVolumes { get; set; }

        /// <summary>
        /// <para>blockVolumes</para>
        /// </summary>
        public InstanceConfigurationLaunchInstanceDetails LaunchDetails { get; set; }

        /// <summary>
        /// <para>blockVolumes</para>
        /// </summary>
        public List<InstanceConfigurationAttachVnicDetails> SecondaryVnics { get; set; }
    }
}
