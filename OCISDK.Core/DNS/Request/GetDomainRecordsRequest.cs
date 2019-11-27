using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.DNS.Request
{
    /// <summary>
    /// GetDomainRecords Request
    /// </summary>
    public class GetDomainRecordsRequest
    {
        /// <summary>
        /// The If-None-Match header field makes the request method conditional on the absence of any current representation of 
        /// the target resource, when the field-value is *, or having a selected representation with an entity-tag that does not 
        /// match any of those listed in the field-value.
        /// <para>Required: no</para>
        /// </summary>
        public string IfNoneMatch { get; set; }

        /// <summary>
        /// The If-Modified-Since header field makes a GET or HEAD request method conditional on the selected representation's 
        /// modification date being more recent than the date provided in the field-value. Transfer of the selected representation's 
        /// data is avoided if that data has not changed.
        /// <para>Required: no</para>
        /// </summary>
        public string IfModifiedSince { get; set; }

        /// <summary>
        /// The name or OCID of the target zone.
        /// <para>Required: yes</para>
        /// </summary>
        public string ZoneNameOrId { get; set; }

        /// <summary>
        /// Search by domain. Will match any record whose domain (case-insensitive) equals the provided value.
        /// <para>Required: yes</para>
        /// </summary>
        public string Domain { get; set; }

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
        /// The version of the zone for which data is requested.
        /// <para>Required: no</para>
        /// </summary>
        public string ZoneVersion { get; set; }
        
        /// <summary>
        /// Search by record type. Will match any record whose type (case-insensitive) equals the provided value.
        /// <para>Required: no</para>
        /// </summary>
        public string Rtype { get; set; }

        /// <summary>
        /// The field by which to sort records.
        /// <para>Required: no</para>
        /// </summary>
        public SortByParam SortBy { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class SortByParam : ExpandableEnum<SortByParam>
        {
            /// <summary>
            /// SortBy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public SortByParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator SortByParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// rtype
            /// </summary>
            public static readonly SortByParam RType = new SortByParam("rtype");

            /// <summary>
            /// ttl
            /// </summary>
            public static readonly SortByParam TTL = new SortByParam("ttl");
        }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// The OCID of the compartment the resource belongs to.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder();
            var chainStr = "";
            
            if (!String.IsNullOrEmpty(this.CompartmentId))
            {
                sb.Append($"compartmentId={this.CompartmentId}");
                chainStr = "&";
            }

            if (!String.IsNullOrEmpty(this.ZoneVersion))
            {
                sb.Append($"{chainStr}zoneVersion={this.ZoneVersion}");
                chainStr = "&";
            }
            
            if (!String.IsNullOrEmpty(this.Rtype))
            {
                sb.Append($"{chainStr}rtype={this.Rtype}");
                chainStr = "&";
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"{chainStr}limit={this.Limit.Value}");
                chainStr = "&";
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"{chainStr}page={this.Page}");
                chainStr = "&";
            }

            if (!(SortBy is null))
            {
                sb.Append($"{chainStr}sortBy={this.SortBy.Value}");
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
