using OCISDK.Core.src.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.src.Database.Request
{
    public class ListDatabasesRequest
    {
        /// <summary>
        /// The compartment OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A database home OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DbHomeId { get; set; }

        /// <summary>
        /// The maximum number of items to return per page.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The pagination token to continue listing from.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The field to sort by. You can provide one sort order (sortOrder). 
        /// Default order for TIMECREATED is descending. Default order for DBNAME is ascending. 
        /// The DBNAME sort order is case sensitive.
        /// <para>Required: no</para>
        /// <para>Allowed values are: DBNAME, TIMECREATED</para>
        /// </summary>
        public SortByParam? SortBy { get; set; }

        public enum SortByParam
        {
            [DisplayName("DBNAME")]
            DBNAME,
            [DisplayName("TIMECREATED")]
            TIMECREATED
        }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// A filter to return only resources that match the given lifecycle state exactly.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// A filter to return only resources that match the entire database name given. The match is not case sensitive.
        /// <para>Required: no</para>
        /// </summary>
        public string DbName { get; set; }

        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");

            sb.Append($"&dbHomeId={this.DbHomeId}");
            
            if (!String.IsNullOrEmpty(this.DbName))
            {
                sb.Append($"&dbName={this.DbName}");
            }

            if (!String.IsNullOrEmpty(this.LifecycleState))
            {
                sb.Append($"&lifecycleState={this.LifecycleState}");
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            if (this.SortBy.HasValue)
            {
                sb.Append($"&sortBy={EnumAttribute.GetDisplayName(this.SortBy.Value)}");
            }

            if (this.SortOrder.HasValue)
            {
                sb.Append($"&sortOrder={EnumAttribute.GetDisplayName(this.SortOrder.Value)}");
            }

            return sb.ToString();
        }
    }
}
