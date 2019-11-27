using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Database.Request
{
    /// <summary>
    /// ListDbVersions Request
    /// </summary>
    public class ListDbVersionsRequest
    {
        /// <summary>
        /// The compartment OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The maximum number of items to return per page.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The pagination token to continue listing from.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 256</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// If provided, filters the results to the set of database versions which are supported for the given shape.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DbSystemShape { get; set; }

        /// <summary>
        /// The DB system OCID. If provided, filters the results to the set of database versions which are supported for the DB system.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 255</para>
        /// </summary>
        public string DbSystemId { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            if (!String.IsNullOrEmpty(this.DbSystemShape))
            {
                sb.Append($"&dbSystemShape={this.DbSystemShape}");
            }
            
            if (!String.IsNullOrEmpty(this.DbSystemId))
            {
                sb.Append($"&dbSystemId={this.DbSystemId}");
            }
            
            return sb.ToString();
        }
    }
}
