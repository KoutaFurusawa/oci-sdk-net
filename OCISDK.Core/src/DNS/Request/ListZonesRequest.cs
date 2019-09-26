using OCISDK.Core.src.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.src.DNS.Request
{
    public class ListZonesRequest
    {
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
        /// The compartment OCID.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A case-sensitive filter for zone names. 
        /// Will match any zone with a name that equals the provided value.
        /// <para>Required: no</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Search by zone name. Will match any zone whose name (case-insensitive) contains the provided value.
        /// <para>Required: no</para>
        /// </summary>
        public string NameContains { get; set; }

        /// <summary>
        /// Search by zone type, PRIMARY or SECONDARY. Will match any zone whose type equals the provided value.
        /// <para>Required: no</para>
        /// </summary>
        public string ZoneType { get; set; }

        /// <summary>
        /// An RFC 3339 timestamp that states all returned resources were created on or after the indicated time.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreatedGreaterThanOrEqualTo { get; set; }

        /// <summary>
        /// An RFC 3339 timestamp that states all returned resources were created before the indicated time.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreatedLessThan { get; set; }

        /// <summary>
        /// The state of a resource.
        /// </summary>
        public LifecycleStateParam? LifecycleState { get; set; }

        public enum LifecycleStateParam
        {
            [DisplayName("ACTIVE")]
            ACTIVE,
            [DisplayName("CREATING")]
            DCREATINGESC,
            [DisplayName("DELETED")]
            DELETED,
            [DisplayName("DELETING")]
            DELETING,
            [DisplayName("FAILED")]
            FAILED
        }

        public SortByParam? SortBy { get; set; }

        public enum SortByParam
        {
            [DisplayName("name")]
            Name,
            [DisplayName("zoneType")]
            ZoneType,
            [DisplayName("timeCreated")]
            TimeCreated
        }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder? SortOrder { get; set; }

        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");

            if (!String.IsNullOrEmpty(this.Name))
            {
                sb.Append($"&name={this.Name}");
            }

            if (!String.IsNullOrEmpty(this.NameContains))
            {
                sb.Append($"&nameContains={this.NameContains}");
            }

            if (!String.IsNullOrEmpty(this.ZoneType))
            {
                sb.Append($"&zoneType={this.ZoneType}");
            }

            if (!String.IsNullOrEmpty(this.TimeCreatedGreaterThanOrEqualTo))
            {
                sb.Append($"&timeCreatedGreaterThanOrEqualTo={this.TimeCreatedGreaterThanOrEqualTo}");
            }

            if (!String.IsNullOrEmpty(this.TimeCreatedLessThan))
            {
                sb.Append($"&T\timeCreatedLessThan={this.TimeCreatedLessThan}");
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            if (this.LifecycleState.HasValue)
            {
                sb.Append($"&lifecycleState={EnumAttribute.GetDisplayName(this.LifecycleState.Value)}");
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
