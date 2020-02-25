using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Budgets.Request
{
    /// <summary>
    /// ListAlertRules Request
    /// </summary>
    public class ListAlertRulesRequest
    {
        /// <summary>
        /// The unique Budget OCID
        /// <para>Required: yes</para>
        /// </summary>
        public string BudgetId { get; set; }

        /// <summary>
        /// For list pagination. The maximum number of results per page, or items to return in a paginated "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// For list pagination. The value of the opc-next-page response header from the previous "List" call. 
        /// For important details about how pagination works, see List Pagination.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 512</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The sort order to use, either ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

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
            /// timeCreated
            /// </summary>
            public static readonly SortByParam TimeCreated = new SortByParam("timeCreated");

            /// <summary>
            /// displayName
            /// </summary>
            public static readonly SortByParam DisplayName = new SortByParam("displayName");
        }

        /// <summary>
        /// The current state of the resource to filter by.
        /// <para>Required: no</para>
        /// </summary>
        public LifecycleStateParam LifecycleState { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class LifecycleStateParam : ExpandableEnum<LifecycleStateParam>
        {
            /// <summary>
            /// SortBy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public LifecycleStateParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator LifecycleStateParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// ACTIVE
            /// </summary>
            public static readonly LifecycleStateParam ACTIVE = new LifecycleStateParam("ACTIVE");

            /// <summary>
            /// INACTIVE
            /// </summary>
            public static readonly LifecycleStateParam INACTIVE = new LifecycleStateParam("INACTIVE");
        }

        /// <summary>
        /// A user-friendly name. Does not have to be unique, and it's changeable.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder($"budgetId={this.BudgetId}");

            if (!string.IsNullOrEmpty(this.DisplayName))
            {
                sb.Append($"&displayName={this.DisplayName}");
            }

            if (!(this.LifecycleState is null))
            {
                sb.Append($"&lifecycleState={this.LifecycleState.Value}");
            }

            if (!string.IsNullOrEmpty(this.SortBy))
            {
                sb.Append($"&sortBy={this.SortBy}");
            }

            if (!(SortOrder is null))
            {
                sb.Append($"&sortOrder={SortOrder.Value}");
            }
            if (!string.IsNullOrEmpty(this.Page))
            {
                sb.Append($"&page={this.Page}");
            }

            if (this.Limit.HasValue)
            {
                sb.Append($"&limit={this.Limit.Value}");
            }

            return sb.ToString();
        }
    }
}
