using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.Usage.Request
{
    /// <summary>
    /// RequestSummarizedConfigurations request
    /// </summary>
    public class RequestSummarizedConfigurationsRequest
    {
        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular 
        /// request, please provide the request ID.
        /// <para>Required: no</para>
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// tenant id
        /// <para>Required: yes</para>
        /// </summary>
        public string TenantId { get; set; }
    }
}
