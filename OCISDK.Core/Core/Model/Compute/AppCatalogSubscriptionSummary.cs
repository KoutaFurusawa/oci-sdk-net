using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Model.Compute
{
    /// <summary>
    /// a subscription summary for a listing resource version.
    /// </summary>
    public class AppCatalogSubscriptionSummary
    {
        /// <summary>
        /// The compartmentID of the subscription.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The display name of the listing.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The ocid of the listing resource.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// Listing resource id.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingResourceId { get; set; }

        /// <summary>
        /// Listing resource version.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ListingResourceVersion { get; set; }

        /// <summary>
        /// Name of the publisher who published this listing.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// The short summary to the listing.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Date and time at which the subscription was created, in RFC3339 format. 
        /// <para>Required: no</para>
        /// </summary>
        /// <example>2018-03-20T12:32:53.532Z</example>
        public string TimeCreated { get; set; }
    }
}
