using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Creates a new block volume. Please see CreateVolumeDetails
    /// </summary>
    public class InstanceConfigurationCreateVolumeDetails
    {
        /// <summary>
        /// The availability domain of the volume.
        /// <para>Required: no</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// If provided, specifies the ID of the volume backup policy to assign to the newly created volume. 
        /// If omitted, no policy will be assigned.
        /// <para>Required: no</para>
        /// </summary>
        public string BackupPolicyId { get; set; }

        /// <summary>
        /// The OCID of the compartment that contains the volume.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The size of the volume in GBs.
        /// <para>Required: no</para>
        /// </summary>
        public int? SizeInGBs { get; set; }

        /// <summary>
        /// Specifies the volume source details for a new Block volume. 
        /// The volume source is either another Block volume in the same availability domain or a Block volume backup. 
        /// This is an optional field. If not specified or set to null, the new Block volume will be empty. 
        /// When specified, the new Block volume will contain data from the source volume or backup.
        /// </summary>
        public InstanceConfigurationVolumeSourceDetails SourceDetails { get; set; }

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
