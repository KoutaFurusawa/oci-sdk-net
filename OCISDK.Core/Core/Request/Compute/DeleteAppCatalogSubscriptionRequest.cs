using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// DeleteAppCatalogSubscription request
    /// </summary>
    public class DeleteAppCatalogSubscriptionRequest
    {
        /// <summary>
        /// The OCID of the listing.
        /// <para>Required: yes</para>
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Listing Resource Version.
        /// <para>Required: yes</para>
        /// </summary>
        public string ResourceVersion { get; set; }

        /// <summary>
        /// get query string
        /// </summary>
        /// <returns></returns>
        public string GetQuery()
        {
            return $"listingId={ListingId}&compartmentId={CompartmentId}&resourceVersion={ResourceVersion}";
        }
    }
}
