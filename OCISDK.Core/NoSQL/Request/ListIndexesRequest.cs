using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.NoSQL.Request
{
    /// <summary>
    /// ListIndexes request
    /// </summary>
    public class ListIndexesRequest
    {
        /// <summary>
        /// A table name within the compartment, or a table OCID.
        /// <para>Required: yes</para>
        /// </summary>
        public string TableNameOrId { get; set; }

        /// <summary>
        /// The ID of a table's compartment. When a table is identified by name, the compartmentId is often needed to provide context for interpreting the name.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// A shell-globbing-style (*?[]) filter for names.
        /// <para>Required: no</para>
        /// <para>Default: *</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Filter list by the lifecycle state of the item.
        /// <para>Required: no</para>
        /// <para>Default: ALL</para>
        /// </summary>
        public string LifecycleState { get; set; }

        /// <summary>
        /// The maximum number of items to return.
        /// <para>Required: no</para>
        /// <para>Minimum: 1, Maximum: 1000</para>
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.
        /// <para>Required: no</para>
        /// <para>Min Length: 1, Max Length: 1024</para>
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// The sort order to use, either 'ASC' or 'DESC'.
        /// <para>Required: no</para>
        /// </summary>
        public string SortOrder { get; set; }

        /// <summary>
        /// The field to sort by. Only one sort order may be provided. Default order for timeCreated is descending. 
        /// Default order for name is ascending. If no value is specified timeCreated is default.
        /// <para>Required: no</para>
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// The client request ID for tracing.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// request optional query get.
        /// </summary>
        /// <returns></returns>
        public string GetOptionalQuery()
        { 
            StringBuilder sb = new StringBuilder();
            string chainC = "";

            if (!string.IsNullOrEmpty(CompartmentId))
            {
                sb.Append($"compartmentId={CompartmentId}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(Name))
            {
                sb.Append($"{chainC}name={Name}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(LifecycleState))
            {
                sb.Append($"{chainC}lifecycleState={LifecycleState}");
                chainC = "&";
            }

            if (Limit.HasValue)
            {
                sb.Append($"{chainC}limit={Limit.Value}");
                chainC = "&";
            }

            if(!string.IsNullOrEmpty(Page))
            {
                sb.Append($"{chainC}page={Page}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(SortOrder))
            {
                sb.Append($"{chainC}sortOrder={SortOrder}");
                chainC = "&";
            }

            if (!string.IsNullOrEmpty(SortBy))
            {
                sb.Append($"{chainC}sortBy={SortBy}");
            }

            return sb.ToString();
        }
    }
}
