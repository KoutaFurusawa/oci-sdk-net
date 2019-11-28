using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The properties that define a metric. For information about metrics, see Metrics Overview.
    /// </summary>
    public class MetricModel
    {
        /// <summary>
        /// The name of the metric.
        /// <para>Required: no</para>
        /// </summary>
        /// <example>CpuUtilization</example>
        public string Name { get; set; }

        /// <summary>
        /// The source service or application emitting the metric.
        /// <para>Required: no</para>
        /// </summary>
        /// <example>oci_computeagent</example>
        public string Namespace { get; set; }

        /// <summary>
        /// The OCID of the compartment containing the resources monitored by the metric.
        /// <para>Required: no</para>
        /// </summary>
        public string CompartmentId { get; set; }

        /// <summary>
        /// Qualifiers provided in a metric definition. Available dimensions vary by metric namespace.
        /// Each dimension takes the form of a key-value pair.
        /// </summary>
        public object Dimensions { get; set; }
    }
}
