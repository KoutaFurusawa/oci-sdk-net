using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.DNS.Request
{
    /// <summary>
    /// ListSteeringPolicyAttachments Request
    /// </summary>
    public class ListSteeringPolicyAttachmentsRequest
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
        /// The OCID of a resource.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The displayName of a resource.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The OCID of the attached steering policy.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string SteeringPolicyId { get; set; }

        /// <summary>
        /// The OCID of the attached zone.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string ZoneId { get; set; }

        /// <summary>
        /// Search by domain. Will match any record whose domain (case-insensitive) equals the provided value.
        /// <para>Required: no</para>
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Search by domain. Will match any record whose domain (case-insensitive) contains the provided value.
        /// <para>Required: no</para>
        /// </summary>
        public string DomainContains { get; set; }

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
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }
        
        /// <summary>
        /// The field by which to sort steering policies. If unspecified, defaults to timeCreated.
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
            /// displayName
            /// </summary>
            public static readonly SortByParam DisplayName = new SortByParam("displayName");

            /// <summary>
            /// timeCreated
            /// </summary>
            public static readonly SortByParam TimeCreated = new SortByParam("timeCreated");

            /// <summary>
            /// domainName
            /// </summary>
            public static readonly SortByParam DomainName = new SortByParam("domainName");
        }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");

            if (!String.IsNullOrEmpty(this.Id))
            {
                sb.Append($"&id={this.Id}");
            }

            if (!String.IsNullOrEmpty(this.DisplayName))
            {
                sb.Append($"&displayName={this.DisplayName}");
            }

            if (!String.IsNullOrEmpty(this.SteeringPolicyId))
            {
                sb.Append($"&steeringPolicyId={this.SteeringPolicyId}");
            }

            if (!String.IsNullOrEmpty(this.ZoneId))
            {
                sb.Append($"&zoneId={this.ZoneId}");
            }

            if (!String.IsNullOrEmpty(this.Domain))
            {
                sb.Append($"&domain={this.Domain}");
            }

            if (!String.IsNullOrEmpty(this.DomainContains))
            {
                sb.Append($"&domainContains={this.DomainContains}");
            }

            if (!String.IsNullOrEmpty(this.TimeCreatedGreaterThanOrEqualTo))
            {
                sb.Append($"&timeCreatedGreaterThanOrEqualTo={this.TimeCreatedGreaterThanOrEqualTo}");
            }

            if (!String.IsNullOrEmpty(this.TimeCreatedLessThan))
            {
                sb.Append($"&timeCreatedLessThan={this.TimeCreatedLessThan}");
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
