using OCISDK.Core.ObjectStorage.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.ObjectStorage.Response
{
    /// <summary>
    /// ListWorkRequestLogs response
    /// </summary>
    public class ListWorkRequestLogsResponse
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
        /// Paginating a list of pre-authenticated requests. In the GET request, set the limit to the number of pre-authenticated requests that you want 
        /// returned in the response. If the opc-next-page header appears in the response, then this is a partial list and there are additional pre-authenticated 
        /// requests to get. Include the header's value as the page parameter in the subsequent GET request to get the next batch of pre-authenticated requests. 
        /// Repeat this process to retrieve the entire list of pre-authenticated requests.
        /// </summary>
        public string OpcNextPage { get; set; }

        /// <summary>
        /// The response body will contain an array of PreauthenticatedRequestSummary resources.
        /// </summary>
        public List<WorkRequestLogEntry> Items { get; set; }
    }
}
