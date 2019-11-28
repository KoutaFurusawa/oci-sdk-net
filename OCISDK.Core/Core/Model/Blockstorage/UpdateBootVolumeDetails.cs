using System.Collections.Generic;

namespace OCISDK.Core.Core.Model.Blockstorage
{
    /// <summary>
    /// UpdateBootVolumeDetails
    /// </summary>
    public class UpdateBootVolumeDetails
    {
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
        public int? SizeInGBs { get; set; }

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
