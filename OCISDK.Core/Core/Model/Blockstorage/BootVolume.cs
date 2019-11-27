
using OCISDK.Core.Core.Model.Compute;
using System;
using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// BootVolume Reference
    /// A detachable boot volume device that contains the image used to boot a Compute instance. 
    /// For more information, see Overview of Boot Volumes.
    /// 
    /// author: koutaro furusawa
    /// </summary>
    public class BootVolume
    {
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
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string ImageId { get; set; }

        /// <summary>
        /// Specifies whether the boot volume's data has finished copying from the source boot volume or boot volume backup.
        /// </summary>
        public bool? IsHydrated { get; set; }

        /// <summary>
        /// The current state of a boot volume.
        /// <para>Allowed values are:
        /// PROVISIONING
        /// RESTORING
        /// AVAILABLE
        /// TERMINATING
        /// TERMINATED
        /// FAULTY</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The size of the boot volume in GBs.
        /// </summary>
        public int? SizeInGBs { get; set; }

        /// <summary>
        /// The size of the volume in MBs. The value must be a multiple of 1024.
        /// This field is deprecated. Please use sizeInGBs.
        /// </summary>
        [Obsolete("This field is deprecated. Please use sizeInGBs.")]
        public int SizeInMBs { get; set; }

        /// <summary>
        /// Details for creating an instance
        /// <para>Required: no</para>
        /// </summary>
        public InstanceSourceDetails SourceDetails { get; set; }

        /// <summary>
        /// The date and time the instance was created, in the format defined by RFC3339.
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the source volume group.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string VolumeGroupId { get; set; }

        /// <summary>
        /// The OCID of the source volume group.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }

        /// <summary>
        /// Free-form tags for this resource. Each tag is a simple key-value pair with no predefined name, type, or namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, string> FreeformTags { get; set; }

        /// <summary>
        /// Defined tags for this resource. Each key is predefined and scoped to a namespace. 
        /// For more information, see Resource Tags.
        /// <para>Required: no</para>
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> DefinedTags { get; set; }
    }
}
