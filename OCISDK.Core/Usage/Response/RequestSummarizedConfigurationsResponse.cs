using System;
using System.Collections.Generic;
using System.Text;
using OCISDK.Core.Usage.Model;

namespace OCISDK.Core.Usage.Response
{
    /// <summary>
    /// RequestSummarizedConfigurations response
    /// </summary>
    public class RequestSummarizedConfigurationsResponse
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular 
        /// request, please provide the request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// The response body will contain a single ConfigurationAggregation resource.
        /// </summary>
        public ConfigurationAggregation ConfigurationAggregation { get; set; }
    }
}
