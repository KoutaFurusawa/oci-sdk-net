using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// ListAppCatalogListingResourceVersions request
    /// </summary>
    public class ListAppCatalogListingResourceVersionsRequest
    {
        /// <summary>
        /// The OCID of the listing.
        /// <para>Required: yes</para>
        /// </summary>
        public string ListingId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC). The DISPLAYNAME sort order is case sensitive.
        /// <para>Required: no</para>
        /// <para>Allowed values are:
        /// ASC
        /// , DESC</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();
            string chainStr = "";

            if (this.Limit.HasValue)
            {
                sb.Append($"limit={this.Limit.Value}");
                chainStr = "&";
            }
            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"{chainStr}page={this.Page}");
                chainStr = "&";
            }
            if (!(SortOrder is null))
            {
                sb.Append($"{chainStr}sortOrder={SortOrder.Value}");
            }

            return sb.ToString();
        }
    }
}
