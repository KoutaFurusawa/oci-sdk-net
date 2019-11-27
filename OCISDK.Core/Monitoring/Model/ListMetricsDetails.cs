using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Model
{
    /// <summary>
    /// The request details for retrieving metric definitions. 
    /// Specify optional properties to filter the returned results. 
    /// Use an asterisk (*) as a wildcard character, placed anywhere in the string. 
    /// For example, to search for all metrics with names that begin with "disk", specify "name" as "disk*". 
    /// If no properties are specified, then all metric definitions within the request scope are returned.
    /// </summary>
    public class ListMetricsDetails
    {
        /// <summary>
        /// The metric name to use when searching for metric definitions.
        /// <para>Required: no</para>
        /// </summary>
        /// <example>CpuUtilization</example>
        public string Name { get; set; }

        /// <summary>
        /// The source service or application to use when searching for metric definitions.
        /// <para>Required: no</para>
        /// </summary>
        /// <example>oci_computeagent</example>
        public string Namespace { get; set; }

        /// <summary>
        /// Qualifiers that you want to use when searching for metric definitions.
        /// Available dimensions vary by metric namespace.
        /// Each dimension takes the form of a key-value pair.
        /// <para>Required: no</para>
        /// </summary>
        public object DimensionFilters { get; set; }

        /// <summary>
        /// Group metrics by these fields in the response.
        /// For example, to list all metric namespaces available in a compartment, groupBy the "namespace" field.
        /// <para>Required: no</para>
        /// </summary>
        public List<string> GroupBy { get; set; }

        /// <summary>
        /// The field to use when sorting returned metric definitions. Only one sorting level is provided.
        /// <para>Required: no</para>
        /// <para>Allowed values are: NAMESPACE / NAME</para>
        /// </summary>
        /// <example>NAMESPACE</example>
        public string SortBy { get; set; }
    }
}
