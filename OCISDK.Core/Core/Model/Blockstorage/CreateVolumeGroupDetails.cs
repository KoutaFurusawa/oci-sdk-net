using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// CreateVolumeGroupDetails
    /// </summary>
    public class CreateVolumeGroupDetails
    {
        /// <summary>
        /// The availability domain of the volume.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the volume.
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
        /// Specifies the volume group source details for a new volume group. 
        /// The volume source is either another a list of volume ids in the same availability domain, another volume group or a volume group backup.
        /// <para>Required: yes</para>
        /// </summary>
        public VolumeGroupSourceDetails SourceDetails { get; set; }

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
