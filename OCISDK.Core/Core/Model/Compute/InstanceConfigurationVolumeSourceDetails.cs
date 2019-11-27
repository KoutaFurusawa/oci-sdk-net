using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// InstanceConfigurationVolumeSourceDetails Reference
    /// </summary>
    public class InstanceConfigurationVolumeSourceDetails
    {
        /// <summary>
        /// See InstanceConfigurationVolumeSourceDetails for more information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The OCID of the volume backup.
        /// <para>Required: no</para>
        /// </summary>
        public string Id { get; set; }
    }
}
