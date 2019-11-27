using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// InstanceConfigurationInstanceSourceDetails
    /// </summary>
    public class InstanceConfigurationInstanceSourceDetails
    {
        /// <summary>
        /// The source type for the instance. Use image when specifying the image OCID. Use bootVolume when specifying the boot volume OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// The OCID of the boot volume used to boot the instance.
        /// <para>Required: no</para>
        /// </summary>
        public string BootVolumeId { get; set; }

        /// <summary>
        /// The size of the boot volume in GBs. The minimum value is 50 GB and the maximum value is 16384 GB (16TB).
        /// <para>Required: no</para>
        /// </summary>
        public int? BootVolumeSizeInGBs { get; set; }

        /// <summary>
        /// The OCID of the image used to boot the instance.
        /// <para>Required: no</para>
        /// </summary>
        public string ImageId { get; set; }
    }
}
