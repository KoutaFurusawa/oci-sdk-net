using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The request details for retrieving aggregated data. Use the query and optional properties to filter the returned results.
    /// </summary>
    public class SummarizeMetricsDataDetails
    {
        /// <summary>
        /// The source service or application to use when searching for metric data points to aggregate.
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>oci_computeagent</example>
        public string Namespace { get; set; }

        /// <summary>
        /// The Monitoring Query Language (MQL) expression to use when searching for metric data points to aggregate. 
        /// The query must specify a metric, statistic, and interval. 
        /// Supported values for interval: 1m-60m (also 1h). You can optionally specify dimensions and grouping functions. 
        /// Supported grouping functions: grouping(), groupBy().
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 1000</para>
        /// </summary>
        /// <example>CpuUtilization[1m].sum()</example>
        public string Query { get; set; }

        /// <summary>
        /// The beginning of the time range to use when searching for metric data points. 
        /// Format is defined by RFC3339. The response includes metric data points for the startTime. 
        /// Default value: the timestamp 3 hours before the call was sent.
        /// <para>Required: no</para>
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// The end of the time range to use when searching for metric data points. 
        /// Format is defined by RFC3339. The response excludes metric data points for the endTime. 
        /// Default value: the timestamp representing when the call was sent.
        /// <para>Required: no</para>
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// The time between calculated aggregation windows. Use with the query interval to vary the frequency at which aggregated data points are returned. 
        /// For example, use a query interval of 5 minutes with a resolution of 1 minute to retrieve five-minute aggregations at a one-minute frequency. 
        /// The resolution must be equal or less than the interval in the query. 
        /// The default resolution is 1m (one minute). Supported values: 1m-60m (also 1h).
        /// </summary>
        /// <example>5m</example>
        public string Resolution { get; set; }
    }
}
