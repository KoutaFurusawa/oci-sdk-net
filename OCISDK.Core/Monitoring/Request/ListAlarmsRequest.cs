using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Request
{
    /// <summary>
    /// ListAlarms Request
    /// </summary>
    public class ListAlarmsRequest
    {
        /// <summary>
        /// Customer part of the request identifier token. If you need to contact Oracle about a particular request, please provide the complete request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the resources monitored by the metric that you are searching for. 
        /// Use tenancyId to search in the root compartment.
        /// <para>Required: yes</para>
        /// <para>Minimum: 1, Maximum: 255</para>
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
        /// A filter to return only resources that match the given display name exactly. 
        /// Use this filter to list an alarm by name. Alternatively, when you know the alarm OCID, use the GetAlarm operation.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A filter to return only alarms that match the given lifecycle state exactly. 
        /// When not specified, only alarms in the ACTIVE lifecycle state are listed.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The field to use when sorting returned alarm definitions. Only one sorting level is provided.
        /// <para>Required: no</para>
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// The sort order to use when sorting returned alarm definitions. Ascending (ASC) or descending (DESC).
        /// <para>Required: no</para>
        /// </summary>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// When true, returns resources from all compartments and subcompartments. 
        /// The parameter can only be set to true when compartmentId is the tenancy OCID (the tenancy is the root compartment). 
        /// A true value requires the user to have tenancy-level permissions. 
        /// If this requirement is not met, then the call is rejected. When false, returns resources from only the compartment specified in compartmentId. 
        /// Default is false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? CompartmentIdInSubtree { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder($"compartmentId={this.CompartmentId}");
            
            if (!string.IsNullOrEmpty(this.DisplayName))
            {
                sb.Append($"&displayName={this.DisplayName}");
            }

            if (!string.IsNullOrEmpty(this.LifecycleState))
            {
                sb.Append($"&lifecycleState={this.LifecycleState}");
            }

            if (!string.IsNullOrEmpty(this.SortBy))
            {
                sb.Append($"&sortBy={this.SortBy}");
            }

            if (!(SortOrder is null))
            {
                sb.Append($"&sortOrder={SortOrder.Value}");
            }

            if (CompartmentIdInSubtree.HasValue)
            {
                sb.Append($"&compartmentIdInSubtree={this.CompartmentIdInSubtree.Value}");
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
