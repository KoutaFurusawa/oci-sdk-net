using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// CreateBootVolumeDetails
    /// </summary>
    public class CreateBootVolumeDetails
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
        /// The size of the boot volume in GBs.
        /// <para>Required: no</para>
        /// </summary>
        public int SizeInGBs { get; set; }

        /// <summary>
        /// Specifies the boot volume source details for a new boot volume. 
        /// The volume source is either another boot volume in the same availability domain or a 
        /// boot volume backup. This is a mandatory field for a boot volume.
        /// <para>Required: yes</para>
        /// </summary>
        public BootVolumeSourceDetails SourceDetails { get; set; }

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
