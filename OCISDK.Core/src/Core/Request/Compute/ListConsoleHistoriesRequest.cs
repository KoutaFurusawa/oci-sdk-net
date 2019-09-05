using OCISDK.Core.src.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OCISDK.Core.src.Core.Request.Compute
{
    public class ListConsoleHistoriesRequest
    {
        /// <summary>
        /// The name of the availability domain.
        /// <para>Required: no</para>
        /// </summary>
        public string AvailabilityDomain { get; set; }

        /// <summary>
        /// The OCID of the compartment.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
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
        /// The OCID of the instance.
        /// <para>Required: no</para>
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Allowed values are: TIMECREATED, DISPLAYNAME</para>
        /// </summary>
        public SortByParam? SortBy { get; set; }

        public enum SortByParam
        {
            [DisplayName("TIMECREATED")]
            TIMECREATED,
            [DisplayName("DISPLAYNAME")]
            DISPLAYNAME
        }

        /// <summary>
        /// <para>Required: no</para>
        /// <para>Allowed values are: ASC, DESC</para>
        /// </summary>
        public SortOrder? SortOrder { get; set; }

        /// <summary>
        /// A filter to only return resources that match the given lifecycle state. The state value is case-insensitive.
        /// <para>Required: no</para>
        /// </summary>
        public string LifecycleState { get; set; }

        public string GetOptionQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"availabilityDomain={this.AvailabilityDomain}");

            sb.Append($"&compartmentId={this.CompartmentId}");

            if (!String.IsNullOrEmpty(this.InstanceId))
            {
                sb.Append($"&instanceId={this.InstanceId}");
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

            if (!String.IsNullOrEmpty(this.LifecycleState))
            {
                sb.Append($"&lifecycleState={this.LifecycleState}");
            }

            return sb.ToString();
        }
    }
}
