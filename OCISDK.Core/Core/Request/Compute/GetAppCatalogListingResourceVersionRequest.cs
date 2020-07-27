using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// GetAppCatalogListingResourceVersion request
    /// </summary>
    public class GetAppCatalogListingResourceVersionRequest
    {
        /// <summary>
        /// The OCID of the listing.
        /// <para>Required: yes</para>
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// Listing Resource Version.
        /// <para>Required: yes</para>
        /// </summary>
        public string ResourceVersion { get; set; }
    }
}
