using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// Listing details.
    /// </summary>
    public class AppCatalogListing
    {
        /// <summary>
        /// Listing's contact URL.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ContactUrl { get; set; }

        /// <summary>
        /// Description of the listing.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Name of the listing.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the listing.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// Publisher's logo URL.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string PublisherLogoUrl { get; set; }

        /// <summary>
        /// Name of the publisher who published this listing.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// Summary of the listing.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Date and time the listing was published, in RFC3339 format.
        /// <para>Required: no</para> 
        /// </summary>
        /// <example>2018-03-20T12:32:53.532Z</example>
        public string TimePublished { get; set; }
    }
}
