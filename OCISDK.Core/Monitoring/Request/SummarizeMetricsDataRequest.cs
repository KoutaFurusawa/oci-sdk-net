using OCISDK.Core.Monitoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Monitoring.Request
{
    /// <summary>
    /// SummarizeMetricsData Request
    /// </summary>
    public class SummarizeMetricsDataRequest
    {
        /// <summary>
        /// Customer part of the request identifier token. 
        /// If you need to contact Oracle about a particular request, please provide the complete request ID.
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
        /// When true, returns resources from all compartments and subcompartments. 
        /// The parameter can only be set to true when compartmentId is the tenancy OCID (the tenancy is the root compartment). 
        /// A true value requires the user to have tenancy-level permissions. 
        /// If this requirement is not met, then the call is rejected. 
        /// When false, returns resources from only the compartment specified in compartmentId. Default is false.
        /// <para>Required: no</para>
        /// </summary>
        public bool? CompartmentIdInSubtree { get; set; }

        /// <summary>
        /// The request body must contain a single SummarizeMetricsDataDetails resource.
        /// </summary>
        public SummarizeMetricsDataDetails SummarizeMetricsDataDetails { get; set; }

        /// <summary>
        /// option query
        /// </summary>
        /// <returns></returns>
        public string GetOptionQuery()
        {
            var sb = new StringBuilder($"compartmentId={this.CompartmentId}");
            
            if (CompartmentIdInSubtree.HasValue)
            {
                sb.Append($"&compartmentIdInSubtree={this.CompartmentIdInSubtree.Value}");
            }

            return sb.ToString();
        }
    }
}
