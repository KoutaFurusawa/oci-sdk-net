using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Listing Resource Version
    /// </summary>
    public class AppCatalogListingResourceVersion
    {
        /// <summary>
        /// List of accessible ports for instances launched with this listing resource version.
        /// <para>Required: no</para>
        /// </summary>
        public List<int> AccessiblePorts { get; set; }

        /// <summary>
        /// Allowed actions for the listing resource.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> AllowedActions { get; set; }

        /// <summary>
        /// List of regions that this listing resource version is available.
        /// For information about Regions, see Regions.
        /// <para>Required: no</para>
        /// </summary>
        /// <example>["us-ashburn-1", "us-phoenix-1"]</example>
        public List<string> AvailableRegions { get; set; }

        /// <summary>
        /// Array of shapes compatible with this resource.
        /// You may enumerate all available shapes by calling [ListShapes] (#listShapes).
        /// <para>Required: no</para>
        /// </summary>
        /// <example>["VM.Standard1.1", "VM.Standard1.2"]</example>
        public List<string> CompatibleShapes { get; set; }

        /// <summary>
        /// The OCID of the listing this resource version belongs to.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// OCID of the listing resource.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingResourceId { get; set; }

        /// <summary>
        /// Resource Version.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string ListingResourceVersion { get; set; }

        /// <summary>
        /// Date and time the listing was published, in RFC3339 format.
        /// <para>Required: no</para> 
        /// </summary>
        /// <example>2018-03-20T12:32:53.532Z</example>
        public string TimePublished { get; set; }
    }
}
