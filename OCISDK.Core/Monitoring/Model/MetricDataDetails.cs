using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// A metric object containing raw metric data points to be posted to the Monitoring service.
    /// </summary>
    public class MetricDataDetails
    {
        /// <summary>
        /// The source service or application emitting the metric.
        /// A valid namespace value starts with an alphabetical character and includes only alphanumeric characters and underscores. 
        /// The "oci_" prefix is reserved. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// The OCID of the compartment to use for metrics.
        /// <para>Required: yes</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// The name of the metric.
        /// A valid name value starts with an alphabetical character and includes only 
        /// alphanumeric characters, dots, underscores, hyphens, and dollar signs. The oci_ prefix is reserved. 
        /// Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Qualifiers provided in a metric definition. Available dimensions vary by metric namespace. Each dimension takes the form of a key-value pair. 
        /// A valid dimension key includes only printable ASCII, excluding periods (.) and spaces. 
        /// The character limit for a dimension key is 256. A valid dimension value includes only Unicode characters. The character limit for a dimension value is 256. 
        /// Empty strings are not allowed for keys or values. Avoid entering confidential information.
        /// <para>Required: yes</para>
        /// </summary>
        public object Dimensions { get; set; }

        /// <summary>
        /// Properties describing metrics. These are not part of the unique fields identifying the metric. Each metadata item takes the form of a key-value pair. 
        /// The character limit for a metadata key is 256. The character limit for a metadata value is 256.
        /// <para>Required: no</para>
        /// </summary>
        public object Metadata { get; set; }

        /// <summary>
        /// A list of metric values with timestamps. At least one data point is required per call.
        /// <para>Required: yes</para>
        /// </summary>
        public List<Datapoint> Datapoints { get; set; }
    }
}
