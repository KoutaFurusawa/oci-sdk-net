using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// A detachable block volume device that allows you to dynamically expand the storage capacity of an instance. 
    /// For more information, see Overview of Cloud Volume Storage.
    /// 
    /// To use any of the API operations, you must be authorized in an IAM policy. If you're not authorized, talk to an administrator. 
    /// If you're an administrator who needs to write policies to give users access, see Getting Started with Policies.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class VolumeDetails
    {
        /// <summary>
        /// The availability domain of the volume.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>\
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the volume.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the volume.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Specifies whether the cloned volume's data has finished copying from the source volume or backup.
        /// <para>Required: no</para>
        /// </summary>
        public bool? IsHydrated { get; set; }

        /// <summary>
        /// The OCID of the KMS key which is the master encryption key for the volume.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string KmsKeyId { get; set; }

        /// <summary>
        /// The current state of a volume.
        /// <para>Required: yes</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The size of the volume, in GBs.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 16384</para>
        /// </summary>
        public int? SizeInGBs { get; set; }

        /// <summary>
        /// The size of the volume in MBs. The value must be a multiple of 1024. This field is deprecated. Please use sizeInGBs.
        /// <para>Required: no</para>
        /// <para>Minimum: 1024, Maximum: 16777216</para>
        /// </summary>
        [Obsolete("This field is deprecated. Please use sizeInGBs.")]
        public int? SizeInMBs { get; set; }

        /// <summary>
        /// The volume source, either an existing volume in the same availability domain or a volume backup. If null, an empty volume is created.
        /// <para>Required: no</para>
        /// </summary>
        public VolumeSourceDetails VolumeSourceDetails { get; set; }

        /// <summary>
        /// The date and time the volume was created. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// The OCID of the source volume group.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string VolumeGroupId { get; set; }

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
