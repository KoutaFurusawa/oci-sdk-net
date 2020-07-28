using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Listing Resource Version summary
    /// </summary>
    public class AppCatalogListingResourceVersionSummary
    {
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
