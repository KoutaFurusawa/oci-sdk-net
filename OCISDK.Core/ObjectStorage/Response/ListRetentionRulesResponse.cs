using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// ListRetentionRules response
    /// </summary>
    public class ListRetentionRulesResponse
    {
        /// <summary>
        /// Echoes back the value passed in the opc-client-request-id header, for use by clients when debugging.
        /// </summary>
        public string OpcClientRequestId { get; set; }

        /// <summary>
        /// Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, provide this request ID.
        /// </summary>
        public string OpcRequestId { get; set; }

        /// <summary>
        /// Paginating a list of retention rules. If the opc-next-page header appears in the response, it indicates that this is a partial list of retention 
        /// rules and there are additional rules to get. Include the value of this header as the page parameter in a subsequent GET request to get the next set of 
        /// retention rules. Repeat this process to retrieve the entire list of retention rules.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain a single RetentionRuleCollection resource.
        /// </summary>
        public RetentionRuleCollection RetentionRuleCollection { get; set; }
    }
}
