using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Identity.Request
{
    /// <summary>
    /// ListBulkActionResourceTypes request
    /// </summary>
    public class ListBulkActionResourceTypesRequest
    {
        /// <summary>
        /// The type of bulk action.
        /// <para>Required: yes</para>
        /// </summary>
        public string BulkActionType { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var options = $"bulkActionType={this.BulkActionType}";

            if (!String.IsNullOrEmpty(this.Page))
            {
                options += $"&page={this.Page}";
            }
            if (this.Limit.HasValue)
            {
                options += $"&limit={this.Limit.Value}";
            }

            return options;
        }
    }
}
