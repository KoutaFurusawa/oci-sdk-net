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
        public LifecycleStateParam LifecycleState { get; set; }
        
        /// <summary>
        /// LifecycleState ExpandableEnum
        /// </summary>
        public class LifecycleStateParam : ExpandableEnum<LifecycleStateParam>
        {
            public LifecycleStateParam(string value) : base(value) { }

            public static implicit operator LifecycleStateParam(string value)
            {
                return Parse(value);
            }

            public static readonly LifecycleStateParam ACTIVE = new LifecycleStateParam("ACTIVE");

            public static readonly LifecycleStateParam CREATING = new LifecycleStateParam("CREATING");

            public static readonly LifecycleStateParam DELETED = new LifecycleStateParam("DELETED");

            public static readonly LifecycleStateParam DELETING = new LifecycleStateParam("DELETING");

            public static readonly LifecycleStateParam FAILED = new LifecycleStateParam("FAILED");
        }

        public SortByParam SortBy { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class SortByParam : ExpandableEnum<SortByParam>
        {
            public SortByParam(string value) : base(value) { }

            public static implicit operator SortByParam(string value)
            {
                return Parse(value);
            }

            public static readonly SortByParam Name = new SortByParam("name");

            public static readonly SortByParam ZoneType = new SortByParam("zoneType");

            public static readonly SortByParam TimeCreated = new SortByParam("timeCreated");
        }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

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
                sb.Append($"&timeCreatedLessThan={this.TimeCreatedLessThan}");
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }

            if (!String.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            if (!(LifecycleState is null))
            {
                sb.Append($"&lifecycleState={LifecycleState.Value}");
            }

            if (!(SortBy is null))
            {
                sb.Append($"&sortBy={SortBy.Value}");
            }

            if (!(SortOrder is null))
            {
                sb.Append($"&sortOrder={SortOrder.Value}");
            }

            return sb.ToString();
        }
    }
}
