using OCISDK.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Model
{
    /// <summary>
    /// Details for the '/usage' query.
    /// </summary>
    public class RequestSummarizedUsagesDetails
    {
        /// <summary>
        /// The compartment depth level.
        /// <para>Required: no</para>
        /// </summary>
        public double? CompartmentDepth { get; set; }

        /// <summary>
        /// filters
        /// <para>Required: no</para>
        /// </summary>
        public FilterDetails Filter { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class GranularityParam : ExpandableEnum<GranularityParam>
        {
            /// <summary>
            /// SortBy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public GranularityParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator GranularityParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// HOURLY
            /// </summary>
            public static readonly GranularityParam HOURLY = new GranularityParam("HOURLY");

            /// <summary>
            /// DAILY
            /// </summary>
            public static readonly GranularityParam DAILY = new GranularityParam("DAILY");

            /// <summary>
            /// MONTHLY
            /// </summary>
            public static readonly GranularityParam MONTHLY = new GranularityParam("MONTHLY");

            /// <summary>
            /// TOTAL
            /// </summary>
            public static readonly GranularityParam TOTAL = new GranularityParam("TOTAL");
        }

        /// <summary>
        /// The usage granularity. HOURLY - Hourly data aggregation. DAILY - Daily data aggregation. MONTHLY - Monthly data 
        /// aggregation. TOTAL - Not yet supported.
        /// <para>Required: yes</para>
        /// </summary>
        public string Granularity { get; set; }

        /// <summary>
        /// Aggregate the result by. example: ["service"]
        /// <para>Required: no</para>
        /// </summary>
        public List<string> GroupBy { get; set; }

        /// <summary>
        /// SortBy ExpandableEnum
        /// </summary>
        public class QueryTypeParam : ExpandableEnum<QueryTypeParam>
        {
            /// <summary>
            /// SortBy ExpandableEnum
            /// </summary>
            /// <param name="value"></param>
            public QueryTypeParam(string value) : base(value) { }

            /// <summary>
            /// parse
            /// </summary>
            /// <param name="value"></param>
            public static implicit operator QueryTypeParam(string value)
            {
                return Parse(value);
            }

            /// <summary>
            /// USAGE
            /// </summary>
            public static readonly QueryTypeParam USAGE = new QueryTypeParam("USAGE");

            /// <summary>
            /// COST
            /// </summary>
            public static readonly QueryTypeParam COST = new QueryTypeParam("COST");
        }

        /// <summary>
        /// The query usage type. Usage - Query the usage data. Cost - Query the cost/billing data.
        /// <para>Required: no</para>
        /// </summary>
        public string QueryType { get; set; }

        /// <summary>
        /// Tenant ID
        /// <para>Required: yes</para>
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// The usage end time.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeUsageEnded { get; set; }

        /// <summary>
        /// The usage start time.
        /// <para>Required: yes</para>
        /// </summary>
        public string TimeUsageStarted { get; set; }
    }
}
