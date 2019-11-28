using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// Specifies a volume group which is a collection of volumes. For more information, see Volume Groups.
    /// 
    /// Warning: Oracle recommends that you avoid using any confidential information when you supply string values using the API.
    /// </summary>
    public class VolumeGroup
    {
        /// <summary>
        /// The availability domain of the volume group.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the volume group.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name for the volume group. 
        /// Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID for the volume group.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The current state of a volume group.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The aggregate size of the volume group in MBs.
        /// <para>Required: yes</para>
        /// </summary>
        public int SizeInMBs { get; set; }

        /// <summary>
        /// The aggregate size of the volume group in GBs.
        /// <para>Required: no</para>
        /// </summary>
        public int? SizeInGBs { get; set; }

        /// <summary>
        /// The volume group source. The source is either another a list of volume IDs in the same availability domain, another volume group, or a volume group backup.
        /// </summary>
        public VolumeGroupSourceDetails SourceDetails { get; set; }

        /// <summary>
        /// The date and time the volume group was created. Format defined by RFC3339.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeCreated { get; set; }

        /// <summary>
        /// OCIDs for the volumes in this volume group.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> VolumeIds { get; set; }

        /// <summary>
        /// Specifies whether the newly created cloned volume group's data has finished copying from the source volume group or backup.
        /// </summary>
        public bool? IsHydrated { get; set; }

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

