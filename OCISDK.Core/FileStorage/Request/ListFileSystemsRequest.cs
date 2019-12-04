using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.FileStorage.Request
{
    /// <summary>
    /// ListFileSystems request
    /// </summary>
    public class ListFileSystemsRequest
    {
        /// <summary>
        /// Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the availability domain.
        /// <para>Required: yes</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

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
        /// A user-friendly name. It does not have to be unique, and it is changeable.
        /// <para>Required: no</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Filter results by OCID. Must be an OCID of the correct type for the resouce type.
        /// <para>Required: no</para>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Allowed values are:
        /// TIMECREATED
        /// , DISPLAYNAME</para>
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
            /// TIMECREATED
            /// </summary>
            public static readonly SortByParam TIMECREATED = new SortByParam("TIMECREATED");

            /// <summary>
            /// DISPLAYNAME
            /// </summary>
            public static readonly SortByParam DISPLAYNAME = new SortByParam("DISPLAYNAME");
        }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Allowed values are:
        /// ASC
        /// , DESC</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// </summary>
        public LifecycleStates LifecycleState { get; set; }

        /// <summary>
        /// LifecycleState ExpandableEnum
        /// </summary>
        public class LifecycleStates : ExpandableEnum<LifecycleStates>
        {
            /// <summary>
            /// LifecycleState ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public LifecycleStates(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator LifecycleStates(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// CREATING
            /// </summary>
            public static readonly LifecycleStates CREATING = new LifecycleStates("CREATING");

            /// <summary>
            /// ACTIVE
            /// </summary>
            public static readonly LifecycleStates ACTIVE = new LifecycleStates("ACTIVE");

            /// <summary>
            /// DELETING
            /// </summary>
            public static readonly LifecycleStates DELETING = new LifecycleStates("DELETING");

            /// <summary>
            /// DELETED
            /// </summary>
            public static readonly LifecycleStates DELETED = new LifecycleStates("DELETED");

            /// <summary>
            /// FAILED
            /// </summary>
            public static readonly LifecycleStates FAILED = new LifecycleStates("FAILED");
        }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"compartmentId={this.CompartmentId}");

            sb.Append($"&availabilityDomain={this.AvailabilityDomain}");

            if (!string.IsNullOrEmpty(this.Id))
            {
                sb.Append($"&id={this.Id}");
            }

            if (!string.IsNullOrEmpty(this.DisplayName))
            {
                sb.Append($"&displayName={this.DisplayName}");
            }

            if (!(LifecycleState is null))
            {
                sb.Append($"&lifecycleState={LifecycleState.Value}");
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }

            if (!string.IsNullOrEmpty(this.Page))
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
