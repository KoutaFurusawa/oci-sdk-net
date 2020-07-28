using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Core.Request.Compute
{
    /// <summary>
    /// ListAppCatalogListings request
    /// </summary>
    public class ListAppCatalogListingsRequest
    {
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
        /// A filter to return only the publisher that matches the given publisher name exactly.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// A filter to return only publishers that match the given publisher type exactly. Valid types are OCI, ORACLE, TRUSTED, STANDARD.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 64</para>
        /// </summary>
        public string PublisherType { get; set; }

        /// <summary>
        /// A filter to return only resources that match the given display name exactly.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

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
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.PublisherName))
            {
                sb.Append($"{chainStr}publisherName={this.PublisherName}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.PublisherType))
            {
                sb.Append($"{chainStr}publisherType={this.PublisherType}");
                chainStr = "&";
            }

            if (!string.IsNullOrEmpty(this.DisplayName))
            {
                sb.Append($"{chainStr}displayName={this.DisplayName}");
            }

            return sb.ToString();
        }
    }
}
