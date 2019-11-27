using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The set of aggregated data returned for a metric. For information about metrics, see Metrics Overview.
    /// Limits information for returned data follows.
    /// * Data points: 100,000.
    /// * Metric streams* within data points: 2,000.
    /// * Time range returned for 1-hour resolution: 90 days.
    /// * Time range returned for 5-minute resolution: 30 days.
    /// * Time range returned for any other resolution: 7 days.
    /// 
    /// A metric stream is an individual set of aggregated data for a metric, typically specific to a single resource. 
    /// Metric streams cannot be aggregated across metric groups. 
    /// A metric group is the combination of a given metric, metric namespace, and tenancy for the purpose of determining limits. 
    /// For more information about metric-related concepts, see Monitoring Concepts.
    /// </summary>
    public class MetricData
    {
        /// <summary>
        /// The reference provided in a metric definition to indicate the source service or application that emitted the metric.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        /// <example>oci_computeagent</example>
        public string Namespace { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the resources from which the aggregated data was returned.
        /// <para>Required: yes</para>
        /// <para>Min Length: 1, Max Length: 255</para>
        /// </summary>
        /// <example>CpuUtilization</example>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Qualifiers provided in the definition of the returned metric. Available dimensions vary by metric namespace. Each dimension takes the form of a key-value pair.
        /// <para>Required: yes</para>
        /// </summary>
        /// <example>"resourceId": "ocid1.instance.region1.phx.exampleuniqueID"</example>
        public object Dimensions { get; set; }

        /// <summary>
        /// The references provided in a metric definition to indicate extra information about the metric.
        /// <para>Required: no</para>
        /// </summary>
        /// <example>"unit": "bytes"</example>
        public object Metadata { get; set; }

        /// <summary>
        /// The time between calculated aggregation windows. 
        /// Use with the query interval to vary the frequency at which aggregated data points are returned. 
        /// For example, use a query interval of 5 minutes with a resolution of 1 minute to retrieve five-minute aggregations at a one-minute frequency. 
        /// The resolution must be equal or less than the interval in the query. The default resolution is 1m (one minute). Supported values: 1m-60m (also 1h).
        /// </summary>
        /// <example>5m</example>
        public string Resolution { get; set; }

        /// <summary>
        /// The list of timestamp-value pairs returned for the specified request. 
        /// Metric values are rolled up to the start time specified in the request. 
        /// For important limits information related to data points, see MetricData Reference at the top of this page.
        /// </summary>
        public List<AggregatedDatapoint> AggregatedDatapoints { get; set; }
    }
}
