using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Waas.Request
{
    /// <summary>
    /// ListWaasPolicies request
    /// </summary>
    public class ListWaasPoliciesRequest
    {
        /// <summary>
        /// The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the compartment. This number is generated when the compartment is created.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

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
        /// <para>Required: no</para>
        /// <para>Allowed values are: TIMECREATED, DISPLAYNAME</para>
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
            /// parase
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator SortByParam(string value)
            {
                return Parse(value);
            }
            
            /// <summary>
            /// id
            /// </summary>
            public static readonly SortByParam ID = new SortByParam("id");

            /// <summary>
            /// displayName
            /// </summary>
            public static readonly SortByParam DISPLAYNAME = new SortByParam("displayName");

            /// <summary>
            /// timeCreated
            /// </summary>
            public static readonly SortByParam TIMECREATED = new SortByParam("timeCreated");
        }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// Filter policies using a list of policy OCIDs.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> Id { get; set; }

        /// <summary>
        /// Filter policies using a list of display names.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> DisplayName { get; set; }

        /// <summary>
        /// Filter policies using a list of lifecycle states.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> LifecycleState { get; set; }

        /// <summary>
        /// A filter that matches policies created on or after the specified date and time.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreatedGreaterThanOrEqualTo { get; set; }

        /// <summary>
        /// A filter that matches policies created before the specified date-time.
        /// <para>Required: no</para>
        /// </summary>
        public string TimeCreatedLessThan { get; set; }

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

            if (Id.Count > 0)
            {
                if (Id.Count == 1)
                {
                    sb.Append($"&id={Id[0]}");
                }
                else
                {
                    foreach (var i in Id)
                    {
                        sb.Append($"&id[]={i}");
                    }
                }
            }

            if (DisplayName.Count > 0)
            {
                if (DisplayName.Count == 1)
                {
                    sb.Append($"&displayName={DisplayName[0]}");
                }
                else
                {
                    foreach (var n in DisplayName)
                    {
                        sb.Append($"&displayName[]={n}");
                    }
                }
            }

            if (LifecycleState.Count > 0)
            {
                if (LifecycleState.Count == 1)
                {
                    sb.Append($"&lifecycleState={LifecycleState[0]}");
                }
                else
                {
                    foreach (var l in LifecycleState)
                    {
                        sb.Append($"&lifecycleState[]={l}");
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.TimeCreatedGreaterThanOrEqualTo))
            {
                sb.Append($"&timeCreatedGreaterThanOrEqualTo={this.TimeCreatedGreaterThanOrEqualTo}");
            }

            if (!string.IsNullOrEmpty(this.TimeCreatedLessThan))
            {
                sb.Append($"&timeCreatedLessThan={this.TimeCreatedLessThan}");
            }

            return sb.ToString();
        }
    }
}
