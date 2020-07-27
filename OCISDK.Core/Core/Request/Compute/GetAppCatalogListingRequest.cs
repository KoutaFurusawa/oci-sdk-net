using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// GetAppCatalogListing request
    /// </summary>
    public class GetAppCatalogListingRequest
    {
        /// <summary>
        /// The OCID of the listing.
        /// <para>Required: yes</para>
        /// </summary>
        public string ListingId { get; set; }
    }
}
